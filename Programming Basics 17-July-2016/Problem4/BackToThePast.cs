namespace Problem4
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	internal class BackToThePast
	{
		internal static void Main(string[] args)
		{
			var inheritance = double.Parse(Console.ReadLine());
			var endingYear = int.Parse(Console.ReadLine());

			var totalSpent = 0.0;

			const int StartingYear = 1800;
			for (int currentYear = StartingYear; currentYear <= endingYear; currentYear++)
			{
				if (currentYear % 2 == 0)
				{
					totalSpent += 12000;
				}
				else
				{
					var spentThatYear = 12000 + (50 * (currentYear - StartingYear + 18));
					totalSpent += spentThatYear;
				}
			}

			if (totalSpent <= inheritance)
			{
				Console.WriteLine($"Yes! He will live a carefree life and will have {inheritance - totalSpent:F2} dollars left.");
			}
			else
			{
				Console.WriteLine($"He will need {totalSpent - inheritance:F2} dollars to survive.");
			}
		}
	}
}
