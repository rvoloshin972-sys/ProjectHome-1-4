using System;

namespace ProjectHome3
{
    internal class ProgrammerDay
    {
        public static Predicate<DateTime> IsProgrammerDay = date => date.DayOfYear == 256;
    }
}
