using System;
using System.Linq;

public class Bridges
{
	public static void Main()
	{
		int[] seq = "7 3 4 5 3 6 7 2 4 5 6 8 6 8".Split().Select(int.Parse).ToArray();

		int[] bridgesCount = CalcBridgesCount(seq);
		int maxCount = bridgesCount.Max();
		if (maxCount == 0)
		{
			Console.WriteLine("No bridges found");
		}
		else if (maxCount == 1)
		{
			Console.WriteLine("1 bridge found");
		}
		else
		{
			Console.WriteLine($"{maxCount} bridges found");
			Console.WriteLine(string.Join(" ", bridgesCount));
		}
	}

	static int[] CalcBridgesCount(int[] seq)
	{
		int[] bridgeCounts = new int[seq.Length];

		for (int index = 1; index < seq.Length; index++)
		{
			bridgeCounts[index] = bridgeCounts[index - 1];
			for (int prevIndex = index - 1; prevIndex >= 0; prevIndex--)
			{
				if (seq[index] == seq[prevIndex] &&
					bridgeCounts[prevIndex] + 1 >= bridgeCounts[index])
				{
					bridgeCounts[index] = bridgeCounts[prevIndex] + 1;
					break;
				}
			}
		}

		return bridgeCounts;
	}
}