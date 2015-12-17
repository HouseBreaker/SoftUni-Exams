using System;

namespace Capitalism.IO
{
	public class CommandParser
	{
		private Command command;

		public CommandParser(Command command)
		{
			Command = command;
		}

		public Command Command
		{
			get { return command; }
			set { if (value != null) command = value; }
		}

		public void ParseCommand(Command command)
		{
			switch (command.Type)
			{
				case "create-company":
					CreateCompany(command);
					break;

				case "create-department":
					CreateDepartment(command);
					break;

				default:
					throw new InvalidOperationException("Invalid command.");
			}
		}


		private void CreateCompany(Command command)
		{
			var companyName = this.command.Args[0];
			var ceoName = this.command.Args[1] + ' ' + command.Args[2];
			var salary = decimal.Parse(this.command.Args[3]);

			CapitalismDatabase.CreateCompany(companyName, ceoName, salary);
		}


		private void CreateDepartment(Command command)
		{
			var companyName = this.command.Args[0];
			var departmentName = this.command.Args[1];
			var managerName = this.command.Args[2] + ' ' + command.Args[3];

			if (command.Args.Length == 4)
			{
				var mainDepartmentName = this.command.Args[4];
				CapitalismDatabase.CreateDepartment(companyName, departmentName, managerName, mainDepartmentName);
			}
			else
			{
				CapitalismDatabase.CreateDepartment(companyName, departmentName, managerName);
			}
		}
	}
}