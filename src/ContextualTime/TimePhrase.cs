using System;

namespace ContextualTime
{
    public abstract class TimePhrase {
        public abstract int Coefficient { get; }
        public abstract UnitOfTime UnitOfTime { get; }

        public DateTime GetAsDateTime()
        {
            return UnitOfTime switch {
                    UnitOfTime.Second => DateTime.Now.AddSeconds(Coefficient),
                    UnitOfTime.Minute => DateTime.Now.AddHours(Coefficient),
                    UnitOfTime.Hour => DateTime.Now.AddHours(Coefficient),
                    UnitOfTime.Day => DateTime.Now.AddDays(Coefficient),
                    UnitOfTime.Week => DateTime.Now.AddWeeks(Coefficient),
                    UnitOfTime.Month => DateTime.Now.AddMonths(Coefficient),
                    UnitOfTime.Year => DateTime.Now.AddYears(Coefficient),
                    UnitOfTime.Decade => DateTime.Now.AddDecades(Coefficient),
                    UnitOfTime.Century => DateTime.Now.AddCenturies(Coefficient),
                    UnitOfTime.Millennium => DateTime.Now.AddMillenniums(Coefficient),
                    _ => DateTime.Now
                };
        }
    }
}
