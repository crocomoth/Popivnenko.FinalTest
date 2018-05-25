using System;

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

            //last number needs to be precise
            resultArray[size - 1] = 1 - CalculateSum(resultArray);
            return resultArray;
        }

        /// <summary>
        /// Generates array with more flat value of numbers
        /// so they are more similar and yet random
        /// </summary>
        /// <param name="size">Size of array to be generated</param>
        /// <returns>Generated array</returns>
        public double[] FlatGeneration(int size)
        {
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            double[] resultArray = new double[size];
            //average element will be about this
            double medium = 1.0 / size;

            for (int i = 0; i < size - 1; i++)
            {
                // 0.25 = 25% of value of current element. this is how much element can differ from medium
                double newElement = randomer.GenerateIndependentDouble(medium, 0.25);
                resultArray[i] = newElement;
            }

            //again last element has fixed size
            resultArray[size - 1] = 1 - CalculateSum(resultArray);
            return resultArray;
        }

        public double[] GenerateWithMax(int size, double maxElem)
        {
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            if (1.0 / size > maxElem)
            {
                throw new Exception("max element is too small");
            }

            while (true)
            {
                double[] resultArray = new double[size];
                //average element will be about this
                double medium = 1.0 / size;

                for (int i = 0; i < size - 1; i++)
                {
                    double currSum = CalculateMedianSum(resultArray, i);                
                    double[] values = CalculateBounds(medium, maxElem, currSum, 0.25);
                    double newElement = randomer.GenerateDoubleBetween(values[0], values[1]);
                    // 0.25 = 25% of value of current element. this is how much element can differ from medium
                    resultArray[i] = newElement;
                }

                //again last element has fixed size
                resultArray[size - 1] = 1 - CalculateSum(resultArray);
                if (resultArray[size - 1] < maxElem && resultArray[size - 1] > 0)
                {
                    return resultArray;
                }
                
            }
        }

        // simply calculates sum of array to provide reasonable last element
        private double CalculateSum(double[] array)
        {
            double sum = 0.0;

            foreach (var elem in array)
            {
                sum += elem;
            }

            return sum;
        }

        private double CalculateMedianSum(double[] array, int maxIndex)
        {
            double sum = 0.0;

            for (int i = 0; i < maxIndex; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private double[] CalculateBounds(double median, double max, double sum, double procent)
        {
            double minFromMaxOrSum = max < 1 - sum ? max : 1 - sum;
            double[] result = new double[2];
            if (median + median * procent < minFromMaxOrSum)
            {
                result[0] = median - median * procent;
                result[1] = median + median * procent;
            }
            else
            {
                result[0] = median - (minFromMaxOrSum - median);
                result[1] = minFromMaxOrSum;
            }

            return result;
        }
    }
}
