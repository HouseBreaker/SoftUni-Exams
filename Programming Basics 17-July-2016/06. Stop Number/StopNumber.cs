using System;

namespace _06.Stop_Number
{
	internal class StopNumber
	{
		internal static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var m = int.Parse(Console.ReadLine());
			var s = int.Parse(Console.ReadLine());

			for (int currentNumber = m; currentNumber >= n; currentNumber--)
			{
				if (currentNumber % 2 == 0 && currentNumber % 3 == 0)
				{
					if (currentNumber == s)
					{
						break;
					}

					Console.Write(currentNumber + " ");
				}
			}
		}
	}
}
