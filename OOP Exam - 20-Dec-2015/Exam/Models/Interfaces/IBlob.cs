namespace Exam.Models.Interfaces
{
	public interface IBlob
	{
		string Name { get; }
		int Health { get; set; }
		int Damage { get; set; }
		IBehavior BlobBehavior { get; }
		IAttack BlobAttack { get; }
	}
}
