namespace Vegetable_Ninja.Models.Vegetables
{
	public abstract class Vegetable : IVegetable
	{
		private int growthTimer;

		protected Vegetable(int powerEffect, int staminaEffect, int regrowPeriod, char identifier)
		{
			this.PowerEffect = powerEffect;
			this.StaminaEffect = staminaEffect;
			this.RegrowPeriod = regrowPeriod;
			this.Identifier = identifier;
			this.GrowthTimer = regrowPeriod;
		}

		public int PowerEffect { get; }

		public int StaminaEffect { get; }

		public int RegrowPeriod { get; }

		public char Identifier { get; }

		public bool HasBeenCollected { get; set; }

		public int GrowthTimer
		{
			get
			{
				return this.growthTimer;
			}

			set
			{
				if (value < 0)
				{
					this.growthTimer = this.RegrowPeriod;
					this.HasBeenCollected = false;
				}
			}
		}

		public void TickGrowth()
		{
			if (this.growthTimer < 1)
			{
				this.GrowthTimer = this.RegrowPeriod;
				this.HasBeenCollected = false;
			}
			else
			{
				this.growthTimer--;
			}
		}
	}
}
