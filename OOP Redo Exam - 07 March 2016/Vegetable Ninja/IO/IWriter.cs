namespace Vegetable_Ninja.IO
{
	public interface IWriter
	{
		void Write(string format, params object[] args);

		void WriteLine(string format, params object[] args);
	}
}
