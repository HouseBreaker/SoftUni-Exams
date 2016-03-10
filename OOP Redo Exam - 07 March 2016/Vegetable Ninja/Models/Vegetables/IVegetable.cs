namespace Vegetable_Ninja.Models.Vegetables
{
	public interface IVegetable
	{
		int PowerEffect { get; }

		int StaminaEffect { get; }

		int RegrowPeriod { get; }

		char Identifier { get; }

		bool HasBeenCollected { get; set; }

		int GrowthTimer { get; set; }

		void TickGrowth();
	}
}
