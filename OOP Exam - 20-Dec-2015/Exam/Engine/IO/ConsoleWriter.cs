using System;
using Exam.Engine.IO.Interfaces;

namespace Exam.Engine.IO
{
	public class ConsoleWriter : IWriter
	{
		public void Write(string format, params object[] parameters)
		{
			Console.Write(format, parameters);
		}

		public void WriteLine(string format, params object[] parameters)
		{
			Console.WriteLine(format, parameters);
		}
	}
}
