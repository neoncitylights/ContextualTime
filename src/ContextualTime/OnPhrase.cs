using System;

namespace ContextualTime {
	public class OnPhrase : TimePhrase {
		public OnPhrase(DayOfWeek currentDay, DayOfWeek newDay) {
			
			Quantity = Math.Abs((int)currentDay - (int)newDay);
		}
		
		public override int Quantity { get; }
		public override UnitOfTime UnitOfTime => UnitOfTime.Day;
		public override Tense Tense => Tense.Future;
	}
}
