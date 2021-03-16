namespace ContextualTime
{
    public class YesterdayPhrase : TimePhrase
    {
        public override int Coefficient => -1;
        public override UnitOfTime UnitOfTime => UnitOfTime.Day;
    }
}
