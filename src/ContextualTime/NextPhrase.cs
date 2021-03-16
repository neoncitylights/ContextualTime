using System;

namespace ContextualTime {
    public class NextPhrase : TimePhrase {
        public NextPhrase(UnitOfTime unitOfTime) {
            Coefficient = 1;
            UnitOfTime = unitOfTime;
        }
        
        public NextPhrase(int coefficient, UnitOfTime unitOfTime) {
            Coefficient = coefficient;
            UnitOfTime = unitOfTime;
        }
   
        public override int Coefficient { get; }
        public override UnitOfTime UnitOfTime { get; }
    }
}
