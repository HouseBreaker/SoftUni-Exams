using System;

class BookProblem
{
	static void Main()
	{
		int pageNum = int.Parse(Console.ReadLine());
		int campingDays = int.Parse(Console.ReadLine());
		int normalDaysRead = int.Parse(Console.ReadLine());
		int normalDays = 30 - campingDays;

		double result = normalDays * normalDaysRead;

		result = pageNum / result;

		if (normalDaysRead <= 0 || normalDays <= 0)
		{
			Console.WriteLine("never");
		}
		else
		{
			double years = result / 12;
			double months = result % 12;

			Console.WriteLine("{0} years {1} months", Math.Floor(years), Math.Ceiling(months));
		}
	}
}