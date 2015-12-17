using Capitalism.People;
using Capitalism.Utility;

namespace Capitalism.Organizations
{
	public class Department
	{
		private string name;
		private Manager manager;
		private string mainDepartmentName;

		public Department(string name, Manager manager, string mainDepartmentName)
		{
			this.Name = name;
			this.Manager = manager;
			this.MainDepartmentName = mainDepartmentName;
		}

		public Department(string name, Manager manager)
		{
			this.Name = name;
			this.Manager = manager;
		}

		public string Name
		{
			get { return name; }
			set { name = Validation.ValidateStr(value, "department name"); }
		}

		public Manager Manager
		{
			get { return manager; }
			set { manager = value; }
		}

		public string MainDepartmentName
		{
			get { return mainDepartmentName; }
			set { mainDepartmentName = value; }
		}
	}
}
