using Capitalism.People.Abstract;

namespace Capitalism.People
{
	class Salesman : Employee
	{
		public Salesman(string name, string lastName) : 
			base(name)
		{
			SalaryFactor = 1.15m;
		}
	}
}