using System;
using Exam.Engine.IO.Interfaces;

namespace Exam.Engine.IO
{

	public class ConsoleReader : IReader
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
