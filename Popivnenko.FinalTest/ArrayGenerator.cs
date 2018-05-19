using System;
using System.Collections.Generic;
using System.Text;

namespace Popivnenko.FinalTest
{
    public class ArrayGenerator
    {
        private Randomer randomer;

        public ArrayGenerator()
        {
            randomer = new Randomer();
        }

        /// <summary>
        /// creates a dependent but quite a random sequence of numbers
        /// which can be thought to be truly random in some cases
        /// </summary>
        /// <param name="size">size of array to create</param>
        /// <returns>array filled with doubles.</returns>
        public double[] DependentGenerate(int size)
        {
            // not much sense in creating array consisting of 2 elements.
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            double[] resultArray = new double[size];
            double maxValue = 1.0 - double.Epsilon;

            for (int i = 0; i < size - 1; i++)
            {
                double newElement = randomer.GenerateDependentDouble(maxValue);
                maxValue -= newElement;
                resultArray[i] = newElement;
            }

            resultArray[size - 1] = 1 - CalculateSum(resultArray);
            return resultArray;
        }

        public double[] FlatGeneration(int size)
        {
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            double[] resultArray = new double[size];
            double medium = 1.0 / size;

            for (int i = 0; i < size - 1; i++)
            {
                double newElement = randomer.GenerateIndependentDouble(medium, 0.25);
                resultArray[i] = newElement;
            }

            resultArray[size - 1] = 1 - CalculateSum(resultArray);
            return resultArray;
        }

        private double CalculateSum(double[] array)
        {
            double sum = 0.0;

            foreach (var elem in array)
            {
                sum += elem;
            }

            return sum;
        }
    }
}
