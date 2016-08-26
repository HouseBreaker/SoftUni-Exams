namespace Problem3
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	class MatchTickets
	{
		static void Main(string[] args)
		{
			const double VipTicketPrice = 499.99;
			const double NormalTicketPrice = 249.99;

			var budget = double.Parse(Console.ReadLine());
			var category = Console.ReadLine();
			var peopleInGroup = int.Parse(Console.ReadLine());

			var budgetPercentage = 0.0;
			if (peopleInGroup > 50)
			{
				budgetPercentage = 0.25;
			}
			else if (peopleInGroup >= 25 && peopleInGroup <= 49)
			{
				budgetPercentage = 0.40;
			}
			else if (peopleInGroup >= 10 && peopleInGroup <= 24)
			{
				budgetPercentage = 0.50;
			}
			else if (peopleInGroup >= 5 && peopleInGroup <= 9)
			{
				budgetPercentage = 0.60;
			}
			else if (peopleInGroup >= 1 && peopleInGroup <= 4)
			{
				budgetPercentage = 0.75;
			}

			var transportBudget = budget * budgetPercentage;
			var ticketsPrice = category == "VIP" ? VipTicketPrice * peopleInGroup : NormalTicketPrice * peopleInGroup;

			var subTotal = budget - transportBudget - ticketsPrice;
			if (subTotal >= 0)
			{
				Console.WriteLine($"Yes! You have {subTotal:F2} leva left.");
			}
			else
			{
				Console.WriteLine($"Not enough money! You need {Math.Abs(subTotal):F2} leva.");
			}
		}
	}
}