using System;
using NUnit.Framework;
using Task3.Library;

namespace Task1.NUnit
{
    [TestFixture]
    public class NewtonRootTest
    {
        [TestCase(4, 2, 0.00001)]
        [TestCase(81, 4, 0.00001)]
        [TestCase(0.008, 3, 0.00001)]
        [TestCase(1024,10,0.00001)]
        [TestCase(-4, 2, 0.00001, ExpectedException = typeof(ArgumentException))]
        [TestCase(4, 0, 0.00001, ExpectedException=typeof(ArgumentException))]
        public void NewtonRoot_FromDataSourceTest(double value, int degree, double precision)
        {
            double actual = Calculator.NewtonRoot(value, degree, precision);
            Assert.AreEqual(Math.Pow(value, 1d / degree), actual, precision);
        }
    }
}
