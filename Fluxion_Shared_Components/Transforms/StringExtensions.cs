using System;
using System.Globalization;

namespace Ca.Fluxion.Shared
{
	public static class StringExtensions
	{
		public static string[] SupportedDateFormats = {
			"d", "D", "f", "F", "g", "G", "m", "o", "R", "s", "t", "T", "u", "U", "y"
		};

		/// <summary>
		/// Converts a string to a DateTime.  DtString contains the string date field
		/// while format contains the date string format to aid in parsing.
		/// </summary>
		/// <returns>The date time.</returns>
		/// <param name="dtString">Date String</param>
		/// <param name="format">Date String Format</param>
		public static DateTime ToDateTime (this string dtString, string format)
		{
			DateTime result;
			if (Array.IndexOf (SupportedDateFormats, format) > -1) {
				DateTime.TryParseExact (dtString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
				return result;
			}
			throw new ArgumentException ("Unsupported Format", "format");
		}
	}
}

