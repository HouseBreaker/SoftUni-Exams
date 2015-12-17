using Capitalism.IO;

namespace Capitalism
{
	public class CapitalismEngine
	{
		CapitalismDatabase database;

		public CapitalismEngine(CapitalismDatabase database)
		{
			this.Database = database;
		}

		public CapitalismDatabase Database
		{
			get { return database; }
			set { database = value; }
		}

		public void RunEngine()
		{
			var input = new CommandParser(new Command(IoReader.ReadLine()));
			while (true)
			{
				if (input.Command.Type == "end")
					break;

				input.ParseCommand(new Command(IoReader.ReadLine()));
			}
		}
	}
}