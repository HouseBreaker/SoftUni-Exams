namespace Exam.Engine.IO.Interfaces
{
	public interface IWriter
	{
		void Write(string format, params object[] parameters);
		void WriteLine(string format, params object[] parameters);
	}
}
