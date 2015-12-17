using System.Collections.Generic;
using Capitalism.People;

namespace Capitalism.Organizations
{
	public class Company
	{
		private string name;
		private Ceo ceo;
		private ICollection<Department> departments;

		public Company(string name, Ceo ceo, ICollection<Department> departments)
		{
			this.name = name;
			this.ceo = ceo;
			this.departments = departments;
		}

		public string Name
		{
			get { return name; }
			private set { name = value; }
		}

		public Ceo Ceo
		{
			get { return ceo; }
			private set { ceo = value; }
		}

		public ICollection<Department> Departments
		{
			get { return departments; }
			private set { departments = value; }
		}
	}
}
