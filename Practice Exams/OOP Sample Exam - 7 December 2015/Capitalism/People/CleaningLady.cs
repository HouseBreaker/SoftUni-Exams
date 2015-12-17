using Capitalism.People.Abstract;

namespace Capitalism.People
{
	class CleaningLady : Employee
	{
		public CleaningLady(string name, string lastName) : 
			base(name)
		{
			SalaryFactor = base.SalaryFactor - 0.02m;
		}
	}
}