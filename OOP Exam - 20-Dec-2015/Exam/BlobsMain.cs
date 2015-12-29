using Exam.Engine;
using Exam.Engine.Database;
using Exam.Engine.IO;
using Exam.Engine.IO.Interfaces;

namespace Exam
{
	public class BlobsMain
	{
		static void Main()
		{
			IReader input = new ConsoleReader();
			IWriter output = new ConsoleWriter();
			BlobDatabase database = new BlobDatabase();
			BlobEngine engine = new BlobEngine(database, input, output);

			engine.Run();
		}
	}
}
