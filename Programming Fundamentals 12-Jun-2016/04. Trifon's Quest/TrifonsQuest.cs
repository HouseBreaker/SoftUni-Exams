using System;
using System.Collections.Generic;

namespace _04
{
	using System.Linq;

	public class TrifonsQuest
	{
		private const char Fight = 'F';

		private const char Heal = 'H';

		private const char Trap = 'T';

		private const char Empty = 'E';

		private static long health;

		private static long turns = 0;

		private static char[,] matrix;

		public static void Main(string[] args)
		{
			health = long.Parse(Console.ReadLine());
			turns = 0;

			var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var rows = dimensions[0];
			var cols = dimensions[1];

			matrix = new char[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				var input = Console.ReadLine();
				for (int col = 0; col < cols; col++)
				{
					matrix[row, col] = input[col];
				}
			}

			for (int col = 0; col < cols; col++)
			{
				if (col % 2 == 0)
				{
					for (int row = 0; row < rows; row++)
					{
						ProcessCommand(row, col);
					}
				}
				else
				{
					for (int row = rows - 1; row >= 0; row--)
					{
						ProcessCommand(row, col);
					}
				}
			}

			Console.WriteLine("Quest completed!");
			Console.WriteLine($"Health: {health}");
			Console.WriteLine($"Turns: {turns}");
		}

		private static void ProcessCommand(int row, int col)
		{
			var currentCell = matrix[row, col];

			switch (currentCell)
			{
				case Fight:
					health -= turns / 2;
					break;
				case Heal:
					health += turns / 3;
					break;
				case Trap:
					turns += 2; // ?
					break;
				case Empty:
					break;
			}

			turns++;

			if (health <= 0)
			{
				Console.WriteLine($"Died at: [{row}, {col}]");
				Environment.Exit(0);
			}
		}
	}
}