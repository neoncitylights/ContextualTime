namespace ContextualTime
{
    public class YesterdayPhrase : TimePhrase {
        public override string Preposition => "yesterday";
        public override int Quantity => -1;
        public override UnitOfTime UnitOfTime => UnitOfTime.Day;
        public override Tense Tense => Tense.Past;
    }
}
