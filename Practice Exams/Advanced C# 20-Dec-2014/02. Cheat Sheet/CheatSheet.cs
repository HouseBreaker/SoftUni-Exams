using System;

	class CheatSheet
	{
		static void Main()
		{
			int r_rows = 9;
			int c_columns = 9;
			int v_start = 1;
			int h_start = 1;

			for (int i = v_start; i <= c_columns; i++)
			{
				Console.WriteLine(i + " ");
			
				for (int j = h_start; j <= r_rows; j++)
				{
					Console.Write(j + " ");
				}
			}
		}
	}