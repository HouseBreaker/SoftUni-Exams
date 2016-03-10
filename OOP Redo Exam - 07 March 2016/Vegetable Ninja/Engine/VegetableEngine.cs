namespace Vegetable_Ninja.Engine
{
	using System;
	using System.Linq;
	using System.Text;

	using Vegetable_Ninja.IO;
	using Vegetable_Ninja.Models;
	using Vegetable_Ninja.Models.Ninjas;
	using Vegetable_Ninja.Models.Vegetables;

	public class VegetableEngine : IVegetableEngine
	{
		private Field field;

		public VegetableEngine(IReader reader, IWriter writer)
		{
			this.Reader = reader;
			this.Writer = writer;
		}

		public IReader Reader { get; }

		public IWriter Writer { get; }

		private Ninja ninja1;

		private Ninja ninja2;

		public void Run()
		{
			var ninja1Name = this.Reader.ReadLine();
			var ninja2Name = this.Reader.ReadLine();

			var fieldDimensions = this.Reader.ReadLine().Split().Select(int.Parse).ToArray();

			this.field = new Field(fieldDimensions[0], fieldDimensions[1]);

			var matrix = new char[fieldDimensions[0], fieldDimensions[1]];

			this.ReadInput(matrix);

			this.FindNinjas(matrix, ninja1Name, ninja2Name);

			this.FindVegetables(matrix);

			var commands = new StringBuilder();

			this.ReadCommands(commands);
			this.StartGame(commands);
		}

		private void StartGame(StringBuilder commands)
		{
			var currentCommandIndex = 0;

			bool isFirstNinjaTurn = true;

			while (true)
			{
				if (isFirstNinjaTurn)
				{
					this.ProcessNinjaTurn(this.ninja1, commands, ref currentCommandIndex);
				}
				else
				{
					this.ProcessNinjaTurn(this.ninja2, commands, ref currentCommandIndex);
				}

				this.GrowVegetables();
				isFirstNinjaTurn = !isFirstNinjaTurn;
			}
		}

		private void ProcessNinjaTurn(Ninja currentNinja, StringBuilder commands, ref int currentCommandIndex)
		{
			// Console.WriteLine("______________________");
			// Console.WriteLine($"{currentNinja.Name}'s turn");
			do
			{
				this.ProcessCommand(commands[currentCommandIndex], currentNinja);
				currentCommandIndex = IncrementCommandIndex(commands, currentCommandIndex);
			}
			while (currentNinja.Stamina != 0);

			currentNinja.EatCollectedVeggies();
		}

		private void GrowVegetables()
		{
			var ninja1Pos = this.ninja1.Position;
			var ninja2Pos = this.ninja2.Position;

			for (int row = 0; row < field.GetLength(0); row++)
			{
				for (int col = 0; col < field.GetLength(1); col++)
				{
					var ninja1IsntStandingHere = !(ninja1Pos.X == row || ninja1Pos.Y == col);
					var ninja2IsntStandingHere = ninja2Pos.X == row || ninja2Pos.Y == col;

					if (ninja1IsntStandingHere && !ninja2IsntStandingHere)
					{
						this.field[row, col].TickGrowth();
					}
				}
			}
		}

		private static int IncrementCommandIndex(StringBuilder commands, int currentCommandIndex)
		{
			if (currentCommandIndex < commands.Length - 1)
			{
				return currentCommandIndex + 1;
			}

			return 0;
		}

		private void ReadCommands(StringBuilder commands)
		{
			string line = this.Reader.ReadLine();
			while (line != string.Empty)
			{
				commands.Append(line);
				line = this.Reader.ReadLine();
			}
		}

		private void ProcessCommand(char command, Ninja currentNinja)
		{
			switch (command)
			{
				case 'L':
					// Console.WriteLine($"{currentNinja.Name} moved left");
					this.MoveNinja(currentNinja, 0, -1);
					break;
				case 'R':
					// Console.WriteLine($"{currentNinja.Name} moved right");
					this.MoveNinja(currentNinja, 0, 1);
					break;
				case 'U':
					// Console.WriteLine($"{currentNinja.Name} moved up");
					this.MoveNinja(currentNinja, -1, 0);
					break;
				case 'D':
					// Console.WriteLine($"{currentNinja.Name} moved down");
					this.MoveNinja(currentNinja, 1, 0);
					break;
			}
		}

		private void MoveNinja(Ninja currentNinja, int deltaX, int deltaY)
		{
			var movedPosition = new Position(currentNinja.Position.X + deltaX, currentNinja.Position.Y + deltaY);

			currentNinja.Stamina--;

			// bump into wall
			var bumpsIntoHorizontalWall = movedPosition.X < 0 || movedPosition.X > this.field.GetLength(0) - 1;
			var bumpsIntoVerticalWall = movedPosition.Y < 0 || movedPosition.Y > this.field.GetLength(1) - 1;

			if (bumpsIntoHorizontalWall || bumpsIntoVerticalWall)
			{
				// Console.WriteLine($"{currentNinja.Name} bumped into a wall");
				// Console.WriteLine($"{currentNinja.Name}: P: {currentNinja.Power} S: {currentNinja.Stamina}");

				return;
			}

			// step on vegetable
			currentNinja.Position = new Position(movedPosition.X, movedPosition.Y);

			// step on enemy
			var ninjasAreStandingInTheSameSpot = 
				this.ninja1.Position.X == this.ninja2.Position.X && 
				this.ninja1.Position.Y == this.ninja2.Position.Y;

			if (ninjasAreStandingInTheSameSpot)
			{
				NinjaBattle(this.ninja1, this.ninja2);
			}

			var vegetableAtPosition = this.field[movedPosition.X, movedPosition.Y];
			if (!vegetableAtPosition.HasBeenCollected)
			{
				currentNinja.CollectVegetable(vegetableAtPosition);
				// Console.WriteLine($"{currentNinja.Name} collected {vegetableAtPosition.GetType().Name}.");
			}

			// Console.WriteLine($"{currentNinja.Name}: P: {currentNinja.Power} S: {currentNinja.Stamina}");
		}

		private void NinjaBattle(Ninja ninja, Ninja otherNinja)
		{
			Ninja winner;

			if (ninja.Power >= otherNinja.Power)
			{
				winner = ninja;
			}
			else
			{
				winner = otherNinja;
			}

			this.Writer.WriteLine($"Winner: {winner}");
			this.Writer.WriteLine($"Power: {winner.Power}");
			this.Writer.WriteLine($"Stamina: {winner.Stamina}");

			Environment.Exit(0);
		}

		private void ReadInput(char[,] matrix)
		{
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				var line = this.Reader.ReadLine();

				for (int col = 0; col < cols; col++)
				{
					matrix[row, col] = line[col];
				}
			}
		}

		private void FindVegetables(char[,] matrix)
		{
			var rows = matrix.GetLength(0);
			var cols = matrix.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					switch (matrix[row, col])
					{
						case 'A':
							this.field[row, col] = new Asparagus();
							break;
						case 'B':
							this.field[row, col] = new Broccoli();
							break;
						case 'C':
							this.field[row, col] = new CherryBerry();
							break;
						case 'M':
							this.field[row, col] = new Mushroom();
							break;
						case 'R':
							this.field[row, col] = new Royal();
							break;
						case '-':
							this.field[row, col] = new BlankSpace();
							break;
						default:
							this.field[row, col] = new BlankSpace();
							break;
					}
				}
			}
		}

		private void FindNinjas(char[,] inputMatrix, string ninja1Name, string ninja2Name)
		{
			var ninja1Initial = ninja1Name[0];
			var ninja2Initial = ninja2Name[0];

			var rows = inputMatrix.GetLength(0);
			var cols = inputMatrix.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					var currentChar = inputMatrix[row, col];

					if (currentChar == ninja1Initial)
					{
						if (this.ninja1 == null)
						{
							this.ninja1 = new Ninja(ninja1Name, row, col);

							// this.field.FieldOfNinjaMovement[row, col] = ninja1Initial;

							// Console.WriteLine("ninja 1 is " + ninja1.Name);
						}
						else if (this.ninja2 == null)
						{
							this.ninja2 = new Ninja(ninja1Name, row, col);

							// this.field.FieldOfNinjaMovement[row, col] = ninja1Initial;

							// Console.WriteLine("ninja 2 is " + ninja2.Name);
						}
					}

					if (currentChar == ninja2Initial)
					{
						if (this.ninja1 == null)
						{
							this.ninja1 = new Ninja(ninja2Name, row, col);

							// this.field.FieldOfNinjaMovement[row, col] = ninja2Initial;

							// Console.WriteLine("ninja 1 is " + ninja1.Name);
						}
						else if (this.ninja2 == null)
						{
							this.ninja2 = new Ninja(ninja2Name, row, col);

							// this.field.FieldOfNinjaMovement[row, col] = ninja2Initial;

							// Console.WriteLine("ninja 2 is " + ninja2.Name);
						}
					}
				}
			}
		}
	}
}