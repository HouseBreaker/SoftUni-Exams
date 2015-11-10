using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _01.Problem_1
{
	class ArrayManipulator
	{
		static int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

		static void Main()
		{
			while (true)
			{
				var command = Console.ReadLine();
				
				// exit case
				if (command == "end")
				{
					Console.WriteLine('[' + string.Join(", ", arr) + ']');
					break;
				}

				// exchange
				if (command.StartsWith("exchange"))
				{
					var index = int.Parse(command.Substring(command.LastIndexOf(' ') + 1));

					if (index > arr.Length - 1)
					{
						Console.WriteLine("Invalid index");
					}
					else
					{
						var firstHalf = arr.Take(index + 1);
						var secondHalf = arr.Skip(index + 1);

						arr = secondHalf.Concat(firstHalf).ToArray();
					}
						
					
				}

				// max even/odd
				try
				{
					if (command.StartsWith("max"))
					{
						var oddOrEven = command.Contains("odd") ? 1 : 0;

						var maxCommand = arr.Where(a => a%2 == oddOrEven).Max();
						Console.WriteLine(Array.LastIndexOf(arr, maxCommand));
					}
					else if (command.StartsWith("min"))
					{
						var oddOrEven = command.Contains("odd") ? 1 : 0;

						var minCommand = arr.Where(a => a % 2 == oddOrEven).Min();
						Console.WriteLine(Array.LastIndexOf(arr, minCommand));
					}
				}
				catch (InvalidOperationException)
				{
					Console.WriteLine("No matches");
				}
 
				// todo: first {count} even/odd
				

				if (command.StartsWith("first"))
				{
					var count = int.Parse(command.Split(' ')[1]);

					if (count > arr.Length)
					{
						Console.WriteLine("Invalid count");
					}
					else
					{
						var isOdd = command.EndsWith("odd") ? 1 : 0;
						
						var result = arr.Where(a => a%2 == isOdd).Take(count);
						Console.WriteLine('[' + string.Join(", ", result) + ']');
					}
				}
				else if (command.StartsWith("last"))
				{
					var count = int.Parse(command.Split(' ')[1]);

					if (count > arr.Length)
					{
						Console.WriteLine("Invalid count");
					}
					else
					{
						var isOdd = command.EndsWith("odd") ? 1 : 0;

						var result = arr.Where(a => a%2 == isOdd).Skip(count);
						if (result.Count() == 0)
						{
							result = arr.Where(a => a%2 == isOdd).Take(count);
						}
						Console.WriteLine('[' + string.Join(", ", result) + ']');
					}
				}

			}
		}
	}
}
