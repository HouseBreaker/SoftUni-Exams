using Exam.Models.Interfaces;

namespace Exam.Models.Behaviors
{
	public class InflatedBehavior : IBehavior
	{
		private const int HealthGained = 50;
		private const int HealthReducedByEveryTurn = 10;
		public bool HasBeenTriggered { get; set; }

		public void Trigger(Blob blob)
		{
			if (!HasBeenTriggered)
			{
				blob.Health += HealthGained + HealthReducedByEveryTurn;
				blob.BlobBehavior.HasBeenTriggered = true;
			}
		}

		public void EndTurnAction(Blob blob)
		{
			blob.Health -= HealthReducedByEveryTurn;
			if (blob.Health <= 0)
			{
				blob.Health = 0;
				blob.IsAlive = false;
			}
		}
	}
}
