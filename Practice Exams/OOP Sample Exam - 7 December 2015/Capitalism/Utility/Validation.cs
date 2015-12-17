using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitalism.Utility
{
	public static class Validation
	{
		public static string ValidateStr(string value, string paramName)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(paramName, paramName + " can't be null, empty or whitespace.");
			}
			return value;
		}

		public static decimal ValidateDec(decimal value, string paramName)
		{
			if (value <= 0)
			{
				throw new ArgumentNullException(paramName, paramName + " cannot be negative or zero.");
			}
			return value;
		}
	}
}
