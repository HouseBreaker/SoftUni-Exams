using System;

class ChessboardGame
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		string input = Console.ReadLine();

		char[,] board = new char[n, n];
		int pointsWhite = 0;
		int pointsBlack = 0;

		int counter = 0;
		bool isWhite = true;

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				isWhite ^= isWhite;
				if (counter < input.Length)
				{
					board[i, j] = input[counter];
					counter++;

					if (board[i, j] >= 65 && board[i, j] <= 90)
					{
						if (isWhite)
						{
							pointsBlack += board[i, j];
						}
						else
						{
							pointsWhite += board[i, j];
						}
					}
					else if ((board[i, j] >= 48 && board[i, j] <= 57) ||
						board[i, j] >= 97 && board[i, j] <= 122)
					{
						if (isWhite)
						{
							pointsWhite += board[i, j];
						}
						else
						{
							pointsBlack += board[i, j];
						}
					}
				}
			}
		}

		if (pointsWhite > pointsBlack)
		{
			Console.WriteLine("The winner is: white team");
			Console.WriteLine(pointsWhite - pointsBlack);
		}
		else if (pointsWhite < pointsBlack)
		{
			Console.WriteLine("The winner is: black team");
			Console.WriteLine(pointsBlack - pointsWhite);
		}
		else if (pointsBlack == pointsWhite)
		{
			Console.WriteLine("Equal result: " + pointsWhite);
		}
	}
}