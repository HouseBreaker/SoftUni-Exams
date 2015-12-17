using Capitalism.People.Abstract;

namespace Capitalism.People
{
	class ChiefTelephoneOfficer : Employee
	{
		public ChiefTelephoneOfficer(string name) : 
			base(name)
		{
			SalaryFactor = base.SalaryFactor - 0.02m;
		}
	}
}
