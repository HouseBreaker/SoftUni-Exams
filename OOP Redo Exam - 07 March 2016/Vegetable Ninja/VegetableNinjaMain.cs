namespace Vegetable_Ninja
{
	using Vegetable_Ninja.Engine;
	using Vegetable_Ninja.IO;

	public class VegetableNinjaMain
	{
		public static void Main(string[] args)
		{
			IVegetableEngine engine = new VegetableEngine(new ConsoleReader(), new ConsoleWriter());
			engine.Run();
		}
	}
}
