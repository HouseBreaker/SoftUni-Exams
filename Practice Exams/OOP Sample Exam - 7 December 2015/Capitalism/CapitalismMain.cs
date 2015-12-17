namespace Capitalism
{
	class CapitalismMain
	{
		static void Main()
		{
			var db = new CapitalismDatabase();

			var engine = new CapitalismEngine(db);
			engine.RunEngine();
		}
	}
}