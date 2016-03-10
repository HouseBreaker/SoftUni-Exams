namespace Vegetable_Ninja.Models
{
	using Vegetable_Ninja.Models.Vegetables;

	public class Field
	{
		private readonly IVegetable[,] fieldOfVegetables;

		public Field(int rows, int cols)
		{
			this.fieldOfVegetables = new IVegetable[rows, cols];

			// this.FieldOfNinjaMovement = new char[rows, cols];
		}

		public IVegetable this[int x, int y]
		{
			get
			{
				return this.fieldOfVegetables[x, y];
			}

			set
			{
				this.fieldOfVegetables[x, y] = value;
			}
		}

		public int GetLength(int dimension)
		{
			return this.fieldOfVegetables.GetLength(dimension);
		}

		// public char[,] FieldOfNinjaMovement { get; }
	}
}
