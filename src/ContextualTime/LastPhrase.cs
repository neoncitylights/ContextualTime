namespace ContextualTime {
	public class LastPhrase : TimePhrase {
		public LastPhrase(UnitOfTime unitOfTime) {
			Quantity = -1;
			UnitOfTime = unitOfTime;
		}
		public LastPhrase(int coefficient, UnitOfTime unitOfTime) {
			Quantity = coefficient < 0 ? coefficient : coefficient * -1;
			UnitOfTime = unitOfTime;
		}
		
		public override int Quantity { get; }
		public override UnitOfTime UnitOfTime { get; }
		public override Tense Tense => Tense.Past;
	}
}