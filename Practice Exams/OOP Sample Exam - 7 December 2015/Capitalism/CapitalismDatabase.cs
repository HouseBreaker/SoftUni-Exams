using System;
using System.Collections.Generic;
using System.Linq;
using Capitalism.IO;
using Capitalism.Organizations;
using Capitalism.People;

namespace Capitalism
{
	public class CapitalismDatabase
	{
		private static List<Company> companies = new List<Company>();

		public static List<Company> Companies
		{
			get { return companies; }
			private set { companies = value; }
		}

		public static void CreateCompany(string name, string ceoName, decimal ceoSalary)
		{
			if (Companies.Any(a => a.Name == name))
			{
				IoWriter.WriteLine($"Company {name} already exists");
			}
			else
			{
				Companies.Add(new Company(name, new Ceo(ceoName, ceoSalary), new List<Department>()));
			}
		}

		public static void CreateDepartment(string companyName, string departmentName, string managerName)
		{
			if (Companies.Any(c => c.Name == companyName))
			{
				if (Companies.Exists(c => c.Departments.Any(d => d.Name == departmentName)))
				{
					IoWriter.WriteLine($"Department {departmentName} already exists in {companyName}");
				}
				else
				{
					Companies[Companies.FindIndex(c => c.Name == companyName)].Departments.Add(new Department(departmentName,
						new Manager(managerName)));
				}
			}
			else
			{
				IoWriter.WriteLine($"Company {companyName} does not exist");
			}
		}

		public static
			void CreateDepartment(string companyName, string departmentName, string managerName, string mainDepartmentName)
		{

		}
	}
}