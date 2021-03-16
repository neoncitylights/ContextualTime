using System;

namespace ContextualTime {
	public class OnPhrase : TimePhrase {
		public OnPhrase(DayOfWeek dayOfWeek) {
			Quantity = (int)dayOfWeek - 1;
		}
		
		public override int Quantity { get; }
		public override UnitOfTime UnitOfTime => UnitOfTime.Day;
	}
}
