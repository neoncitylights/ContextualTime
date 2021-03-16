using System;

namespace ContextualTime
{
    public class TodayPhrase : TimePhrase
    {
        public override int Coefficient => 0;
        public override UnitOfTime UnitOfTime => UnitOfTime.Day;
    }
}
