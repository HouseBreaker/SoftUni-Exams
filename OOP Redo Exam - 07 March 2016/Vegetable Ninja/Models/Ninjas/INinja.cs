namespace Vegetable_Ninja.Models.Ninjas
{
	public interface INinja
	{
		string Name { get; }

		int Power { get; set; }

		int Stamina { get; set; }

		Position Position { get; set; }

		void EatCollectedVeggies();
	}
}