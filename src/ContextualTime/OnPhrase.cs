using System;

namespace ContextualTime {
	public class OnPhrase : TimePhrase {
		public OnPhrase(DayOfWeek dayOfWeek) {
			Coefficient = (int)dayOfWeek - 1;
		}
		
		public override int Coefficient { get; }
		public override UnitOfTime UnitOfTime => UnitOfTime.Day;
	}
}
