namespace Programming_Basics_17_July_2016
{
	using System;

	internal class Money
	{
		internal static void Main(string[] args)
		{
			var numberOfBitcoins = int.Parse(Console.ReadLine());
			var juans = double.Parse(Console.ReadLine());
			var commission = double.Parse(Console.ReadLine());

			var bitcoinsToLevs = numberOfBitcoins * 1168;
			var juansToLevs = juans * 0.15 * 1.76;
			var total = (bitcoinsToLevs + juansToLevs) / 1.95;

			var commissionMoney = total * commission * 0.01;
			total -= commissionMoney;

			Console.WriteLine(total);
		}
	}
}
