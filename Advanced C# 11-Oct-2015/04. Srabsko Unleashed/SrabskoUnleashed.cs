using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_04
{
	class SrabskoUnleashed
	{           // venue
		static Dictionary<string, Dictionary<string, int>> info = new Dictionary<string, Dictionary<string, int>>();

		private static void Main()
		{
			var findSingers = new Regex(@"(?<singer>[\w ]+) @(?<venue>[\w ]+) (?<count>\d+) (?<price>\d+)");
			while (true)
			{
				var input = Console.ReadLine();

				// exit case
				if (input == "End")
				{
					break;
				}

				if (findSingers.IsMatch(input))
				{
					Match match = findSingers.Match(input);
					string venue = match.Groups["venue"].Value;
					string singer = match.Groups["singer"].Value;
					int ticketCount = int.Parse(match.Groups["count"].Value);
					int ticketPrice = int.Parse(match.Groups["price"].Value);

					if (!info.ContainsKey(venue))
					{
						info.Add(venue, new Dictionary<string, int>());
						info[venue].Add(singer, ticketCount*ticketPrice);
					}

					else if (info.ContainsKey(venue))
					{
						if (!info[venue].ContainsKey(singer))
						{
							info[venue].Add(singer, ticketCount*ticketPrice);
						}

						else if (info[venue].ContainsKey(singer))
						{
							info[venue][singer] += ticketCount*ticketPrice;
						}
					}
				}
			}


			foreach (var venue in info)
			{
				Console.WriteLine(venue.Key);
				var sortedPair = venue.Value.OrderByDescending(b => b.Value);
				foreach (var pair in sortedPair)
				{
					Console.Write("#  ");
					Console.WriteLine(pair.Key + " -> " + pair.Value);
					
				}
			}
		}
	}
}