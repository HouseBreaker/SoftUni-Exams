namespace Vegetable_Ninja.Models.Ninjas
{
	using System.Collections.Generic;

	using Vegetable_Ninja.Models.Vegetables;

	public class Ninja : INinja
	{
		private readonly List<IVegetable> collectedVeggies;

		private int stamina;

		public Ninja(string name, int positionX, int positionY)
		{
			this.Name = name;
			this.Power = 1;
			this.Stamina = 1;
			this.Position = new Position(positionX, positionY);
			this.collectedVeggies = new List<IVegetable>();
		}

		public string Name { get; }

		public int Power { get; set; }

		public int Stamina
		{
			get
			{
				return this.stamina;
			}

			set
			{
				this.stamina = value > 0 ? value : 0;
			}
		}

		public Position Position { get; set; }

		public void EatCollectedVeggies()
		{
			foreach (var vegetable in this.collectedVeggies)
			{
				this.Eat(vegetable);
			}

			this.collectedVeggies.Clear();
		}

		public void CollectVegetable(IVegetable vegetable)
		{
			this.collectedVeggies.Add(vegetable);
			vegetable.HasBeenCollected = true;
		}

		private void Eat(IVegetable vegetable)
		{
			this.Power += vegetable.PowerEffect;
			this.Stamina += vegetable.StaminaEffect;

			// Console.WriteLine(this.Name + " ate a " + vegetable.GetType().Name);
		}
	}
}