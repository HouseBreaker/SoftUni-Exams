using System;
using Exam.Models.Interfaces;

namespace Exam.Models.Behaviors
{
	public class AggressiveBehavior : IBehavior
	{
		private const int DamageReducedEveryTurn = 5;
		private const int DamageMultiplier = 2;

		public bool HasBeenTriggered { get; set; }

		public void Trigger(Blob blob)
		{
			if (!HasBeenTriggered)
			{
				blob.Damage *= DamageMultiplier;
				blob.Damage += DamageReducedEveryTurn;

				blob.BlobBehavior.HasBeenTriggered = true;
			}
		}

		public void EndTurnAction(Blob blob)
		{
			if (blob.Damage >= blob.InitialDamage + DamageReducedEveryTurn)
			{
				blob.Damage -= DamageReducedEveryTurn;
			}
		}
	}
}