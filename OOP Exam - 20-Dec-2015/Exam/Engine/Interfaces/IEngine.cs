using Exam.Engine.Database;
using Exam.Engine.IO.Interfaces;

namespace Exam.Engine.Interfaces
{
	public interface IEngine
	{
		BlobDatabase Database { get; }
		IReader Input { get; }
		IWriter Output { get; }

		void Run();
	}
}