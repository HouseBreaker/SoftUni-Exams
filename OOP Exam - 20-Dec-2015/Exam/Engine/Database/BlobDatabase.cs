using System;
using System.Collections;
using System.Collections.Generic;
using Exam.Models;

namespace Exam.Engine.Database
{
	public class BlobDatabase : IEnumerable<Blob>
	{
		private ICollection<Blob> Collection { get; }

		public Action<Blob> EndTurnActions { get; set; }

		public BlobDatabase()
		{
			Collection = new List<Blob>();
			EndTurnActions = delegate { };
		}

		public void Add(Blob blob)
		{
			Collection.Add(blob);
		}

		public IEnumerator<Blob> GetEnumerator()
		{
			return Collection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}