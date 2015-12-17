using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Group_Permutations
{
	class GroupPermutations
	{
		static string input = Console.ReadLine();
		static int n = input.Length;
		static Dictionary<char, int> letterCount = new Dictionary<char, int>();

		static char[] letters;

		static StringBuilder permutations = new StringBuilder();

		static void Main()
		{
			foreach (var letter in input)
			{
				if (letterCount.ContainsKey(letter))
				{
					letterCount[letter]++;
				}
				else
				{
					letterCount[letter] = 1;
				}
			}

			letters = letterCount.Keys.ToArray();

			Permute(0);

			Console.Write(permutations);
		}

		private static void Permute(int index)
		{
			if (index == letters.Length)
			{
				Print();
				return;
			}

			Permute(index + 1);
			for (int i = index + 1; i < letters.Length; i++)
			{
				Swap(ref letters[i], ref letters[index]);
				Permute(index + 1);
				Swap(ref letters[i], ref letters[index]);
			}
		}

		private static void Print()
		{
			foreach (var l in letters)
			{
				for (int i = 0; i < letterCount[l]; i++)
				{
					permutations.Append(l);
				}
			}
			permutations.AppendLine();
		}

		private static void Swap(ref char c1, ref char c2)
		{
			var temp = c1;
			c1 = c2;
			c2 = temp;
		}
	}
}