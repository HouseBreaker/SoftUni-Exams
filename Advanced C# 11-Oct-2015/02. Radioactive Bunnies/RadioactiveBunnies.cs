using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_02
{
	class RadioactiveBunnies
	{
		static char[,] matrix;
		static int lastResult;
		static string message;

		static void Main()
		{
			int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			matrix = new char[size[0], size[1]];

			ReadInput();

			var commands = Console.ReadLine();

			var playerIsAt = FindPlayerStartingPoint();

			var currentRow = playerIsAt[0];
			var currentCol = playerIsAt[1];

			foreach (char command in commands)
			{
				switch (command)
				{
					case 'U':
						if (CaveCircumstance(currentRow - 1, currentCol) == 0)
						{
							matrix[currentRow, currentCol] = '.';
							matrix[currentRow - 1, currentCol] = 'P';
							currentRow--;
						}
						break;

					case 'D':
						if (CaveCircumstance(currentRow + 1, currentCol) == 0)
						{
							matrix[currentRow, currentCol] = '.';
							matrix[currentRow + 1, currentCol] = 'P';
							currentRow++;
						}
						break;

					case 'L':
						if (CaveCircumstance(currentRow, currentCol - 1) == 0)
						{
							matrix[currentRow, currentCol] = '.';
							matrix[currentRow, currentCol - 1] = 'P';
							currentCol--;
						}

						break;

					case 'R':
						if (CaveCircumstance(currentRow, currentCol + 1) == 0)
						{
							matrix[currentRow, currentCol] = '.';
							matrix[currentRow, currentCol + 1] = 'P';
							currentCol++;
						}
						break;
				}
				MultiplyBunnies();

				if (lastResult == 1 || lastResult == 2)
				{
					PrintMatrix();
					Console.WriteLine(message);
					return;
				}
			}

		}

		static void MultiplyBunnies()
		{
			// find bunnies
			var bunnyList = FindBunnies();

			// spread them
			foreach (var bun in bunnyList)
			{
				SpreadBunny(bun[0] - 1, bun[1]); // up
				SpreadBunny(bun[0] + 1, bun[1]); // down

				SpreadBunny(bun[0], bun[1] - 1); // left
				SpreadBunny(bun[0], bun[1] + 1); // right
			}
		}

		static List<int[]> FindBunnies()
		{
			var bunnyList = new List<int[]>();
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (matrix[row, col] == 'B')
					{
						bunnyList.Add(new[] { row, col });
					}
				}
			}
			return bunnyList;
		}

		static void SpreadBunny(int row, int col)
		{
			try
			{
				matrix[row, col] = 'B';
			}
			catch (IndexOutOfRangeException)
			{

			}
		}

		static void ReadInput()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				string currentRow = Console.ReadLine();

				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}
		}

		static int[] FindPlayerStartingPoint()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (matrix[row, col] == 'P')
					{
						return new[] { row, col };
					}
				}
			}
			return new[] { 0, 1 };
		}

		static void PrintMatrix()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.Write(matrix[row, col]);
				}
				Console.WriteLine();
			}
		}

		static int CaveCircumstance(int row, int col)
		{
			try
			{
				if (matrix[row, col] == 'B')
				{
					message = ("dead: " + row + " " + col);
					lastResult = 1;

					return 1;
				}
			}
			catch (IndexOutOfRangeException)
			{
				if (row < 0)
				{
					row = 0;
				}
				else if (row > matrix.GetLength(0)-1)
				{
					row = matrix.GetLength(0)-1;
				}

				else if (col < 0)
				{
					col = 0;
				}
				else if (col > matrix.GetLength(1) - 1)
				{
					col = matrix.GetLength(1) - 1;
				}

				matrix[row, col] = '.';
				message = ("won: " + row + " " + col);
				lastResult = 2;
				return 2;
			}
			lastResult = 0;
			return 0;
		}
	}
}
