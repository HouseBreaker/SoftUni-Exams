namespace Problem5
{
	using System;

	internal class Diamond
	{
		internal static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());

			Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n * 3));

			for (int i = 1; i <= n - 1; i++)
			{
				Console.WriteLine("{0}*{1}*{0}", new string('.', n - i), new string('.', (n * 3) + (i - 1) * 2));
			}

			Console.WriteLine(new string('*', n * 5));

			var numberOfDots = 1;
			var numberOfMiddleDots = (n * 5) - 4;
			for (int i = 0; i < n * 2; i++)
			{
				Console.WriteLine("{0}*{1}*{0}", new string('.', numberOfDots++), new string('.', numberOfMiddleDots));

				numberOfMiddleDots -= 2;
			}

			Console.WriteLine("{0}{1}{0}", new string('.', n * 2 + 1), new string('*', n - 2));
		}
	}
}