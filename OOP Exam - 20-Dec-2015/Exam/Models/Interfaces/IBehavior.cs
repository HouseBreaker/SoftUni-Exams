namespace Exam.Models.Interfaces
{
	public interface IBehavior
	{
		bool HasBeenTriggered { get; set; }
		void Trigger(Blob blob);
		void EndTurnAction(Blob blob);
	}
}
