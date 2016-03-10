namespace Vegetable_Ninja.IO
{
	using System;

	public class ConsoleWriter : IWriter
	{
		public void Write(string format, params object[] args)
		{
			Console.Write(format, args);
		}

		public void WriteLine(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}
	}
}
