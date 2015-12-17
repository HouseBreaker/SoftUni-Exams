using System;
using System.Collections.Generic;
using System.Linq;

class Combination
{
	int Num;
	IEnumerable<Combination> Combinations;
	static List<List<int>> combinationsList = new List<List<int>>();

	static IEnumerable<Combination> GetCombinationTrees(int num, int max)
	{
		return Enumerable.Range(1, num)
			.Where(n => n <= max)
			.Select(n =>
				new Combination
				{
					Num = n,
					Combinations = GetCombinationTrees(num - n, num)
				});
	}

	static IEnumerable<IEnumerable<int>> BuildCombinations(
		IEnumerable<Combination> combinations)
	{
		if (combinations.Count() == 0)
		{
			return new[] {new int[0]};
		}
		else
		{
			return combinations.SelectMany(c =>
				BuildCombinations(c.Combinations)
					.Select(l => new[] {c.Num}.Concat(l))
				);
		}
	}

	public static IEnumerable<IEnumerable<int>> GetCombinations(int num)
	{
		var combinationsList = GetCombinationTrees(num, num);

		return BuildCombinations(combinationsList);
	}

	public static void AddCombinations(int num)
	{
		var allCombinations = GetCombinations(num);
		foreach (var c in allCombinations)
		{
			//Console.WriteLine(string.Join(" ", c));
			combinationsList.Add(c.ToList());
		}
	}

	static void Main()
	{
		int input = int.Parse(Console.ReadLine());
		for (int i = 1; i <= input; i++)
		{
			AddCombinations(i);
		}
		
		combinationsList = combinationsList.OrderBy(a => string.Join("", a)).ToList();

		foreach (var combination in combinationsList)
		{
			Console.WriteLine(string.Join(" ", combination));
		}
	}
}