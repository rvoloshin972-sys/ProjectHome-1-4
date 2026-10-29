using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome1
{
    public record DayTemperature(string Day,double MaxTemperature,double MinTemperature)
    {
        public double Difference => MaxTemperature - MinTemperature;
    }
}
