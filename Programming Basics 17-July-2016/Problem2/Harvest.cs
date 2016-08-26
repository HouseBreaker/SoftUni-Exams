namespace Problem2
{
	using System;

	internal class Harvest
	{
		internal static void Main(string[] args)
		{
			var wineryArea = int.Parse(Console.ReadLine());
			var grapesPerSquareMeter = double.Parse(Console.ReadLine());
			var litersNeeded = int.Parse(Console.ReadLine());
			var workers = int.Parse(Console.ReadLine());

			var totalGrapes = wineryArea * grapesPerSquareMeter;
			var totalWine = 0.4 * totalGrapes / 2.5;

			if (totalWine >= litersNeeded)
			{
				Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalWine)} liters.");

				var remainingWine = totalWine - litersNeeded;
				Console.WriteLine($"{Math.Ceiling(remainingWine)} liters left -> {Math.Ceiling(remainingWine / workers)} liters per person.");
			}
			else
			{
				Console.WriteLine($"It will be a tough winter! More {Math.Ceiling(litersNeeded - totalWine)} liters wine needed.");
			}
		}
	}
}