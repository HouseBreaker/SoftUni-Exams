namespace Problem3
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;

	public static class FootballLeague
	{
		public static void Main(string[] args)
		{
			var key = Regex.Escape(Console.ReadLine());

			var topGoals = new Dictionary<string, long>();
			var teamPoints = new Dictionary<string, long>();

			var input = Console.ReadLine();
			while (input != "final")
			{
				var regexPattern =
					string.Format(@".*?{0}(?<team1>.*?){0}.*{0}(?<team2>.*){0}.*?(?<team1Goals>\d+):(?<team2Goals>\d+)", key);
				var decryptedString = Regex.Match(input, regexPattern, RegexOptions.CultureInvariant);

				var team1 = decryptedString.Groups["team1"].Value.ToUpper();
				var team2 = decryptedString.Groups["team2"].Value.ToUpper();

				team1 = new string(team1.Reverse().ToArray());
				team2 = new string(team2.Reverse().ToArray());

				var team1Goals = long.Parse(decryptedString.Groups["team1Goals"].Value);
				var team2Goals = long.Parse(decryptedString.Groups["team2Goals"].Value);

				var team1Points = 0L;
				var team2Points = 0L;

				if (team1Goals > team2Goals)
				{
					team1Points = 3;
				}
				else if (team2Goals > team1Goals)
				{
					team2Points = 3;
				}
				else if (team1Goals == team2Goals)
				{
					team1Points = 1;
					team2Points = 1;
				}

				teamPoints[team1] = teamPoints.ContainsKey(team1) ? teamPoints[team1] + team1Points : team1Points;
				teamPoints[team2] = teamPoints.ContainsKey(team2) ? teamPoints[team2] + team2Points : team2Points;

				topGoals[team1] = topGoals.ContainsKey(team1) ? topGoals[team1] + team1Goals : team1Goals;
				topGoals[team2] = topGoals.ContainsKey(team2) ? topGoals[team2] + team2Goals : team2Goals;

				input = Console.ReadLine();
			}

			var teamPointsStandings = teamPoints.OrderByDescending(a => a.Value).ThenBy(a => a.Key).ToArray();
			var topGoalsStandings = topGoals.OrderByDescending(a => a.Value).ThenBy(a => a.Key).Take(3).ToArray();

			Console.WriteLine("League standings:");
			for (int i = 0; i < teamPointsStandings.Length; i++)
			{
				var currentTeam = teamPointsStandings[i];
				var place = i + 1;

				Console.WriteLine($"{place}. {currentTeam.Key} {currentTeam.Value}");
			}

			Console.WriteLine("Top 3 scored goals:");
			foreach (var currentTeam in topGoalsStandings)
			{
				Console.WriteLine($"- {currentTeam.Key} -> {currentTeam.Value}");
			}
		}
	}
}