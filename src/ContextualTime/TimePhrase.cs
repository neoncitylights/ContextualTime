using System;

namespace ContextualTime {
	public abstract class TimePhrase {
		public abstract string Preposition { get; }
		public abstract int Quantity { get; }
		public abstract UnitOfTime UnitOfTime { get; }
		public abstract Tense Tense { get; }

		public DateTime GetAsDateTime() {
			return UnitOfTime switch {
				UnitOfTime.Second => DateTime.Now.AddSeconds( Quantity ),
				UnitOfTime.Minute => DateTime.Now.AddHours( Quantity ),
				UnitOfTime.Hour => DateTime.Now.AddHours( Quantity ),
				UnitOfTime.Day => DateTime.Now.AddDays( Quantity ),
				UnitOfTime.Week => DateTime.Now.AddWeeks( Quantity ),
				UnitOfTime.Month => DateTime.Now.AddMonths( Quantity ),
				UnitOfTime.Year => DateTime.Now.AddYears( Quantity ),
				UnitOfTime.Decade => DateTime.Now.AddDecades( Quantity ),
				UnitOfTime.Century => DateTime.Now.AddCenturies( Quantity ),
				UnitOfTime.Millennium => DateTime.Now.AddMillenniums( Quantity ),
				_ => DateTime.Now
			};
		}
	}
}
