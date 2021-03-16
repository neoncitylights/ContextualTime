using System;

namespace ContextualTime
{
    public class TomorrowPhrase : TimePhrase
    {
        public override int Coefficient => 1;
        public override UnitOfTime UnitOfTime => UnitOfTime.Day;
    }
}
