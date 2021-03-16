namespace ContextualTime {
	public class LastPhrase : TimePhrase {
		public LastPhrase(UnitOfTime unitOfTime) {
			Coefficient = -1;
			UnitOfTime = unitOfTime;
		}
		public LastPhrase(int coefficient, UnitOfTime unitOfTime) {
			Coefficient = coefficient < 0 ? coefficient : coefficient * -1;
			UnitOfTime = unitOfTime;
		}
		
		public override int Coefficient { get; }
		public override UnitOfTime UnitOfTime { get; }
	}
}