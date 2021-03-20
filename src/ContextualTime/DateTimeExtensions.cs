using System;

namespace ContextualTime {
	public static class DateTimeExtensions {
		/// <summary>
		/// Extension method to expressively modify a <see cref="DateTime"/> instance
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="quantity">The quantity to add or subtract (to go backwards in time, use a negative number)</param>
		/// <param name="unitOfTime">The unit of time (such as seconds, hours, or days) specified as a member of the <see cref="UnitOfTime"/> enum</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddByUnit( this DateTime dateTime, int quantity, UnitOfTime unitOfTime ) =>
			unitOfTime switch {
				UnitOfTime.Second => dateTime.AddSeconds( quantity ),
				UnitOfTime.Minute => dateTime.AddHours( quantity ),
				UnitOfTime.Hour => dateTime.AddHours( quantity ),
				UnitOfTime.Day => dateTime.AddDays( quantity ),
				UnitOfTime.Week => dateTime.AddWeeks( quantity ),
				UnitOfTime.Month => dateTime.AddMonths( quantity ),
				UnitOfTime.Year => dateTime.AddYears( quantity ),
				UnitOfTime.Decade => dateTime.AddDecades( quantity ),
				UnitOfTime.Century => dateTime.AddCenturies( quantity ),
				UnitOfTime.Millennium => dateTime.AddMillenniums( quantity ),
				_ => dateTime
			};

		/// <summary>
		/// Extension method to add a certain number of weeks to a <see cref="DateTime"/> instance
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of weeks to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddWeeks( this DateTime dateTime, int value ) =>
			dateTime.AddDays( value * 7 );
		
		/// <summary>
		/// Extension method to add a certain number of decades to a <see cref="DateTime"/>
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of decades to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddDecades( this DateTime dateTime, int value ) =>
			dateTime.AddYears( value * 10 );

		/// <summary>
		/// Extension method to add a certain number of centuries to a <see cref="DateTime"/>
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of centuries to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddCenturies( this DateTime dateTime, int value ) =>
			dateTime.AddYears( value * 100 );

		/// <summary>
		/// Extension method to add a certain number of millenniums/millennia to a <see cref="DateTime"/>
		/// </summary>
		/// <param name="dateTime">An instance of <see cref="DateTime"/></param>
		/// <param name="value">Number of millenniums/millennia to modify the date (to go backwards in time, use a negative number)</param>
		/// <returns><see cref="DateTime"/></returns>
		public static DateTime AddMillenniums( this DateTime dateTime, int value ) =>
			dateTime.AddYears( value * 1000 );
	}
}
