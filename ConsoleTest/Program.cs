using System;
using Popivnenko.FinalTest;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayGenerator arrayGenerator = new ArrayGenerator();
            double[] result = arrayGenerator.DependentGenerate(10);
            double sum = 0.0;

            foreach (var elem in result)
            {
                Console.WriteLine(elem);
                sum += elem;
            }

            Console.WriteLine($"sum for dependent generation is {sum}");
            Console.WriteLine("___________________");

            result = arrayGenerator.FlatGeneration(10);
            sum = 0.0;

            foreach (var elem in result)
            {
                Console.WriteLine(elem);
                sum += elem;
            }

            Console.WriteLine($"sum for flat generation is {sum}");
            Console.WriteLine("___________________");

            result = arrayGenerator.GenerateWithMax(3, 0.4);
            sum = 0.0;

            foreach (var elem in result)
            {
                Console.WriteLine(elem);
                sum += elem;
            }

            Console.WriteLine($"sum for max generation is {sum}");
            Console.WriteLine("___________________");

            Console.ReadLine();
        }
    }
}
