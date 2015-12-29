using System;
using Exam.Models.Interfaces;

namespace Exam.Models.Attacks
{
	public class Blobplode : IAttack
	{
		public void Attack(Blob sourceBlob, Blob targetBlob)
		{
			sourceBlob.Health = (int) Math.Ceiling((double) sourceBlob.Health/2);

			if (!sourceBlob.BlobBehavior.HasBeenTriggered)
			{
				sourceBlob.BlobBehavior.Trigger(sourceBlob);
			}

			if (sourceBlob.Health < 1)
			{
				sourceBlob.Health = 1;
			}

			targetBlob.Health -= sourceBlob.Damage*2;
			if (targetBlob.Health < 0)
			{
				targetBlob.Health = 0;
			}
		}
	}
}