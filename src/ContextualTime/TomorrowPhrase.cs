using System;

namespace ContextualTime
{
    public class TomorrowPhrase : TimePhrase {
        public override string Preposition => "tomorrow";
        public override int Quantity => 1;
        public override UnitOfTime UnitOfTime => UnitOfTime.Day;
        public override Tense Tense => Tense.Future;
    }
}
