using System;
using System.Linq;
using System.Text;
using Exam.Engine.Database;
using Exam.Engine.IO.Interfaces;
using Exam.Models;
using Exam.Models.Attacks;
using Exam.Models.Behaviors;
using Exam.Models.Interfaces;

namespace Exam.Engine
{
	public static class CommandParser
	{
		public static void ParseCommand(string input, IWriter output, BlobDatabase database)
		{
			var tokens = input.Split(' ').ToArray();
			var commandType = tokens[0];
			switch (commandType)
			{
				case "create":
					CreateCommand(database, tokens);
					break;
				case "attack":
					AttackCommand(database, tokens);
					break;
				case "pass":

					break;
				case "status":
					StatusCommand(output, database);
					break;
				case "report-events":
					//todo: report events
					break;
				default:
					throw new InvalidOperationException("Invalid Command.");
			}

			foreach (var blob in database)
			{
				if (blob.BlobBehavior.HasBeenTriggered)
				{
					blob.BlobBehavior.EndTurnAction(blob);
				}
			}
		}

		private static void CreateCommand(BlobDatabase database, string[] tokens)
		{
			var name = tokens[1];
			var health = int.Parse(tokens[2]);
			var damage = int.Parse(tokens[3]);
			var behaviourType = tokens[4];
			var attackType = tokens[5];

			var createdBlob = new Blob(name, health, damage,
				behaviourType == "Aggressive" ? (IBehavior) new AggressiveBehavior() : new InflatedBehavior(),
				attackType == "PutridFart" ? (IAttack) new PutridFart() : new Blobplode());

			database.Add(createdBlob);
		}

		private static void StatusCommand(IWriter output, BlobDatabase database)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var blob in database)
			{
				sb.AppendLine(blob.ToString());
			}
			output.Write(sb.ToString());
		}

		private static void AttackCommand(BlobDatabase database, string[] tokens)
		{
			var sourceBlob = database.First(a => a.Name == tokens[1]);
			var targetBlob = database.First(a => a.Name == tokens[2]);

			sourceBlob.Attack(targetBlob);


			if (sourceBlob.Health <= sourceBlob.InitialHealth / 2)
			{
				sourceBlob.BlobBehavior.Trigger(targetBlob);
			}

			if (targetBlob.Health <= targetBlob.InitialHealth/2)
			{
				targetBlob.BlobBehavior.Trigger(targetBlob);
			}

			if (targetBlob.Health <= 0)
			{
				targetBlob.IsAlive = false;
			}
		}
	}
}