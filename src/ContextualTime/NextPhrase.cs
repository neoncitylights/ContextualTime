using System;

namespace ContextualTime {
    public class NextPhrase : TimePhrase {
        public NextPhrase(UnitOfTime unitOfTime) {
            Quantity = 1;
            UnitOfTime = unitOfTime;
        }
        
        public NextPhrase(int coefficient, UnitOfTime unitOfTime) {
            Quantity = coefficient;
            UnitOfTime = unitOfTime;
        }
   
        public override int Quantity { get; }
        public override UnitOfTime UnitOfTime { get; }
        public override Tense Tense => Tense.Future;
    }
}
