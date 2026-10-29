using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome1
{
    public static class TemperatureExtensions
    {
        public static DayTemperature GetDayWithMaxDifference(this DayTemperature[] temperatures)
        {
            DayTemperature result = temperatures[0];
            for (int i = 1; i < temperatures.Length; i++)
            {
                result = temperatures[i].Difference > result.Difference
                    ? temperatures[i]
                    : result;
            }
            return result;
        }
    }
}
