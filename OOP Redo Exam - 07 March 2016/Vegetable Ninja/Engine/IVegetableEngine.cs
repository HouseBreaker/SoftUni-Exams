namespace Vegetable_Ninja.Engine
{
	using Vegetable_Ninja.IO;

	public interface IVegetableEngine
	{
		IReader Reader { get; }

		IWriter Writer { get; }

		void Run();
	}
}