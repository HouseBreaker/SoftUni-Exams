using Exam.Models.Interfaces;

namespace Exam.Models.Attacks
{
	public class PutridFart : IAttack
	{
		public void Attack(Blob sourceBlob, Blob targetBlob)
		{
			sourceBlob.Health -= targetBlob.Damage;
		}
	}
}