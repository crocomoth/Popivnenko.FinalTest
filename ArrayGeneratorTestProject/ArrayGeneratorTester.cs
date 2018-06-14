using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Popivnenko.FinalTest;

namespace ArrayGeneratorTestProject
{
    [TestClass]
    public class ArrayGeneratorTester
    {
        private ArrayGenerator arrayGenerator = new ArrayGenerator();
        private const double Epsilon = 0.001; 
		//hello world

        [TestMethod]
        public void GenerateDependentTest()
        {
            var doubles = arrayGenerator.DependentGenerate(10);
            Assert.IsTrue(Math.Abs(doubles.Sum() - 1.0) < Epsilon);
        }

        [TestMethod]
        public void GenerateFlatTest()
        {
            var doubles = arrayGenerator.FlatGeneration(10);
            Assert.IsTrue(Math.Abs(doubles.Sum() - 1.0) < Epsilon);
        }
    }
}
