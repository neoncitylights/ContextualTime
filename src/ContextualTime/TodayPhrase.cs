using System;

namespace ContextualTime {
	public class TodayPhrase : TimePhrase {
		public override string Preposition => "today";
		public override int Quantity => 0;
		public override UnitOfTime UnitOfTime => UnitOfTime.Day;
		public override Tense Tense => Tense.Present;
	}
}
