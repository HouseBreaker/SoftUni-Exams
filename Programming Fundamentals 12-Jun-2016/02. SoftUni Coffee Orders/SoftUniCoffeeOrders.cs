namespace _02
{
	using System;
	using System.Collections.Generic;

	public class SoftUniCoffeeOrders
	{
		public static void Main(string[] args)
		{
			var ordersCount = int.Parse(Console.ReadLine());

			var total = 0m;
			for (int i = 0; i < ordersCount; i++)
			{
				var capsulePrice = decimal.Parse(Console.ReadLine());
				var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);
				var capsulesCount = long.Parse(Console.ReadLine());

				var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
				var price = daysInMonth * capsulesCount * capsulePrice;

				total += price;

				Console.WriteLine($"The price for the coffee is: ${price:F2}");
			}

			Console.WriteLine($"Total: ${total:F2}");
		}
	}
}
