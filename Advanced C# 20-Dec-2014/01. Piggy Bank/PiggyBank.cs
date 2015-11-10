using System;

	class PiggyBank
	{
		static void Main()
		{
			

			int price = int.Parse(Console.ReadLine());
			int partydays = int.Parse(Console.ReadLine());

			int daysinMonth = 30;
			int monthsinYear = 12;

			int normaldays = daysinMonth - partydays;

			int savednormal = normaldays * 2;
			int spentpartying = partydays * 5;
			int savedtotal = savednormal - spentpartying;

			int years = price / savedtotal / monthsinYear;
			double months = (double)price / savedtotal % monthsinYear;
			months = Math.Ceiling(months);


			if (partydays <= 8)
			{
				Console.WriteLine("{0} years, {1} months", years, months);
			}
			else
			{
				Console.WriteLine("never");
			}
		}
	}
