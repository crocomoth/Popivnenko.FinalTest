using System;
using System.Collections.Generic;
using System.Text;

namespace Popivnenko.FinalTest
{
    public class Randomer
    {
        private Random random = new Random();

        public double GenerateDependentDouble(double maxValue)
        {
            double result = this.GenerateBetweenDoubles(double.Epsilon, maxValue);
            return result;
        }

        public double GenerateIndependentDouble(double medium, double percent)
        {
            double shift = medium * percent;
            double result = this.GenerateBetweenDoubles(medium - shift, medium + shift);
            return result;
        }

        private double GenerateBetweenDoubles(double minValue, double maxValue)
        {
            double result = random.NextDouble() * (maxValue - minValue) + minValue;
            return result;
        }
    }
}
