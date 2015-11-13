using System;
using System.Collections.Generic;
using System.Linq;

class Decrypt
{
	static List<string> stringList = new List<string>();
	static void Main()
	{
		string input = Console.ReadLine();
		int occurences = 0;


		while (input != "start" && input != "START")
		{
			input = Console.ReadLine();

		}

		do
		{
			input = Console.ReadLine();

			if (input == "end" || input == "END")
			{
				if (occurences == 0)
				{
					Console.WriteLine("No message received.");
				}
				else
				{
					Console.WriteLine("Total number of messages: " + occurences);
					for (int i = 0; i < stringList.Count; i++)
					{
						Console.WriteLine(stringList[i]);
					}
				}
			}
			else if (input != "")
			{
				DecryptString(input);
				occurences++;
			}
		}
		while (input != "end" && input != "END");


	}

	static void DecryptString(string input)
	{
		string decrypted = input;
		decrypted = new string(input.Reverse().ToArray());

		char[] dC = new char[input.Length];
		dC = decrypted.ToArray();

		for (int i = 0; i < input.Length; i++)
		{
			switch (dC[i])
			{
				case '+':
					dC[i] = ' '; break;
				case '%':
					dC[i] = ','; break;
				case '&':
					dC[i] = '.'; break;
				case '#':
					dC[i] = '?'; break;
				case '$':
					dC[i] = '!'; break;
			}
			//capital from A to Z
			if ((dC[i] >= 'A' && dC[i] <= 'M') || (dC[i] >= 'a' && dC[i] <= 'm'))
			{
				dC[i] += (char)13;
			}
			//noncapital from a to z
			else if ((dC[i] >= 'N' && dC[i] <= 'Z') || (dC[i] >= 'n' && dC[i] <= 'z'))
			{
				dC[i] -= (char)13;
			}
		}
		stringList.Add(new string(dC));
	}
}