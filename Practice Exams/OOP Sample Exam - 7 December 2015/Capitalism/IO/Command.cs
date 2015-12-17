using System;
using System.Linq;
using Capitalism.Utility;

namespace Capitalism.IO
{
	public class Command
	{
		private string type;
		private string[] args;

		public Command(string type, string[] args)
		{
			this.Type = type;
			this.Args = args;
		}

		public Command(string commandAsString)
		{
			var commandTokens = commandAsString.Split(' ');

			Type = commandTokens[0];

			Args = new string[commandTokens.Length];
			for (int i = 1; i < Args.Length; i++)
			{
				this.args[i] = commandTokens[i];
			}
		}

		public string Type
		{
			get { return type; }
			private set { type = Validation.ValidateStr(value, "commandType"); }
		}

		public string[] Args
		{
			get { return args; }
			private set { if (Args != null) args = value; }
		}

		public static Command ParseCommand(string line)
		{
			var tokens = IoReader.ReadLine().Split(' ');
			var type = tokens[0];

			return new Command(type, tokens.Skip(1).ToArray());
		}
	}
}