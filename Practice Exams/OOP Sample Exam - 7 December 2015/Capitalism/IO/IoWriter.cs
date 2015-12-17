using System;

namespace Capitalism.IO
{
	public static class IoWriter
	{
		public static void WriteLine(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}
	}
}
