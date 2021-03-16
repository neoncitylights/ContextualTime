namespace ContextualTime
{
    public class YesterdayPhrase : TimePhrase
    {
        public override int Quantity => -1;
        public override UnitOfTime UnitOfTime => UnitOfTime.Day;
    }
}
