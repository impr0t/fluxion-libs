using System;

namespace Ca.Fluxion.Shared
{
	/// <summary>
	/// Provides extensions for the <see cref="System.DateTime"/> object.
	/// </summary>
	public static class DateExtensions
	{
		/// <summary>
		/// Converts <see cref="System.DateTime"/> to ISO6801 standard date string.
		/// </summary>
		/// <returns>The log string.</returns>
		/// <param name="dateTime">Date time.</param>
		public static string ToLogDate (this DateTime dateTime)
		{
			return dateTime.ToString ("o");
		}
	}
}

