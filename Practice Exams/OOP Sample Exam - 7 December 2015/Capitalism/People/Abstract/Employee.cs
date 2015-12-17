using System;
using Capitalism.People.Interfaces;
using Capitalism.Utility;

namespace Capitalism.People.Abstract
{
	public abstract class Employee : IEmployee
	{
		private string name;
		private decimal salaryFactor = 1;

		protected Employee(string name)
		{
			Name = name;
			SalaryFactor = salaryFactor;
		}

		public string Name
		{
			get { return name; }
			private set { name = Validation.ValidateStr(value, "first name"); }
		}

		public decimal SalaryFactor
		{
			get { return salaryFactor; }
			protected set { salaryFactor = Validation.ValidateDec(value, "salary factor"); }
		}
	}
}