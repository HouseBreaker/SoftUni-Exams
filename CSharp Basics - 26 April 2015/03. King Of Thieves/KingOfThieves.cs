using System;

class KingOfThieves
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		char theChar = char.Parse(Console.ReadLine());

		for (int i = 0, count = 0; i < n; i++)
		{
			Console.WriteLine("{0}{1}{0}",
				new string('-', ((n - 1) / 2) - count),
				new string(theChar, 1 + 2 * count));
			if (i < (n / 2))
			{
				count++;
			}
			else
			{
				count--;
			}
		}
	}
}