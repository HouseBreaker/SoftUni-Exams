using System;
using Exam.Engine.Database;
using Exam.Engine.IO.Interfaces;

namespace Exam.Engine
{
	public class BlobEngine
	{
		public BlobDatabase BlobDatabase { get; }
		public IReader Input { get; }
		public IWriter Output { get; }

		public BlobEngine(BlobDatabase blobDatabase, IReader input, IWriter output)
		{
			BlobDatabase = blobDatabase;
			Input = input;
			Output = output;
		}

		public void Run()
		{
			string input = Input.ReadLine();
			while (input != "drop")
			{
				try
				{
					CommandParser.ParseCommand(input, Output, BlobDatabase);
				}
				catch (Exception ex)
				{
					Output.WriteLine(ex.Message);
				}

				input = Input.ReadLine();
			}
		}
	}
}
