using Capitalism.People.Abstract;
using Capitalism.Utility;

namespace Capitalism.People
{
	public class Ceo : Manager
	{
		private decimal baseSalary;

		public decimal BaseSalary
		{
			get { return baseSalary; }
			private set { baseSalary = Validation.ValidateDec(value, "Base salary"); }
		}

		public Ceo(string name, decimal baseSalary) :
			base(name)
		{
			BaseSalary = baseSalary;
		}
	}
}