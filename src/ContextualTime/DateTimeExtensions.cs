using System;

namespace ContextualTime {
	public static class DateTimeExtensions {
		public static DateTime AddWeeks(this DateTime dateTime, int value) =>
			dateTime.AddDays(value * 7);
		
		public static DateTime AddDecades(this DateTime dateTime, int value) =>
			dateTime.AddYears(value * 10);

		public static DateTime AddCenturies(this DateTime dateTime, int value) =>
			dateTime.AddYears(value * 100);

		public static DateTime AddMillenniums(this DateTime dateTime, int value) =>
			dateTime.AddYears(value * 1000);
	}
}
