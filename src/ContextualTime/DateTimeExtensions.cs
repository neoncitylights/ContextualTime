using System;

namespace ContextualTime {
	public static class DateTimeExtensions {
		/// <summary>
		/// Extension method to add a certain number of weeks to a <see cref="DateTime"/> instance
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of weeks to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddWeeks(this DateTime dateTime, int value) =>
			dateTime.AddDays(value * 7);
		
		/// <summary>
		/// Extension method to add a certain number of decades to a <see cref="DateTime"/>
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of decades to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddDecades(this DateTime dateTime, int value) =>
			dateTime.AddYears(value * 10);

		/// <summary>
		/// Extension method to add a certain number of centuries to a <see cref="DateTime"/>
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of centuries to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddCenturies(this DateTime dateTime, int value) =>
			dateTime.AddYears(value * 100);

		/// <summary>
		/// Extension method to add a certain number of millenniums/millennia to a <see cref="DateTime"/>
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of millenniums/millennia to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddMillenniums(this DateTime dateTime, int value) =>
			dateTime.AddYears(value * 1000);
	}
}
