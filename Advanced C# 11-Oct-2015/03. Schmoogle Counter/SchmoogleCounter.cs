using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_03
{
	internal static class SchmoogleCounter
	{
		private static void Main()
		{
			var lines = new List<string>();

			var ints = new List<string>();
			var doubles = new List<string>();

			while (true)
			{
				var line = Console.ReadLine();

				if (line == "//END_OF_CODE")
				{
					break;
				}

				lines.Add(line);
			}

			var regex = new Regex(@"(?<intOrDouble>int|double) (?<name>[a-zA-Z]*)( = .*)?(;|\))");

			foreach (var line in lines)
			{
				MatchCollection matchCollection = regex.Matches(line);

				foreach (Match match in matchCollection)
				{
					var intOrDouble = match.Groups["intOrDouble"].Value;
					var name = match.Groups["name"].Value;

                    if (intOrDouble == "int")
					{
						ints.Add(name);
					}
					else
					{
						doubles.Add(name);
					}
				}
			}

			ints.Sort();
			doubles.Sort();

			Console.Write("Doubles: ");
			Console.WriteLine(doubles.Count > 0 ? string.Join(", ", doubles) : "None");

			Console.Write("Ints: ");
			Console.WriteLine(ints.Count > 0 ? string.Join(", ", ints) : "None");
		}
	}
}