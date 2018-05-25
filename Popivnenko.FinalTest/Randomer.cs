using System;

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

        public double GenerateDoubleBetween(double minValue, double maxValue)
        {
            return GenerateBetweenDoubles(minValue, maxValue);
        }

        // using this method any other genration variant can be implemented
        private double GenerateBetweenDoubles(double minValue, double maxValue)
        {
            double result = random.NextDouble() * (maxValue - minValue) + minValue;
            return result;
        }
    }
}
