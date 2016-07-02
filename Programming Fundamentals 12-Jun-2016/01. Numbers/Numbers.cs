namespace _01
{
	using System;
	using System.Linq;

	public static class Numbers
	{
		public static void Main(string[] args)
		{
			var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
			
			var average = arr.Average();
			var results = arr.Where(a => a > average).OrderByDescending(a => a).Take(5).ToArray();

			Console.WriteLine(results.Any() ? string.Join(" ", results) : "No");
		}
	}
}
