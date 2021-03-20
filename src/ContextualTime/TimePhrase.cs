using System;

namespace ContextualTime {
	public abstract class TimePhrase {
		public abstract string Preposition { get; }
		public abstract int Quantity { get; }
		public abstract UnitOfTime UnitOfTime { get; }
		public abstract Tense Tense { get; }

		public DateTime GetAsDateTime() => DateTime.Now.AddByUnit( Quantity, UnitOfTime );
	}
}
