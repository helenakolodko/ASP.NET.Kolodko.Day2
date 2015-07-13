using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;

namespace Task1.Tests
{
    [TestClass]
    public class NewtonRootTest
    {
        [TestMethod]
        public void SquareRootOfFourEqualsTwo()
        {
            double value = 4;
            int degree = 2;
            double precision = 0.00001;
            Assert.AreEqual(Math.Pow(value, 1d / degree), Calculator.NewtonRoot(value, degree, precision), precision);
        }

        [TestMethod]
        public void FourthRootOfEightyOneEqualsThree()
        {
            double value = 81;
            int degree = 4;
            double precision = 0.00001;
            Assert.AreEqual(Math.Pow(value, 1d / degree), Calculator.NewtonRoot(value, degree, precision), precision);
        }

        [TestMethod]
        public void ThirdRootOfEightThousandthEqualsTwoTenth()
        {
            double value = 0.008;
            int degree = 2;
            double precision = 0.00001;
            Assert.AreEqual(Math.Pow(value, 1d / degree), Calculator.NewtonRoot(value, degree, precision), precision);
        }

        [TestMethod]
        public void TenthRootOfOneThousandTwentyFourEqualsTwo()
        {
            double value = 1024;
            int degree = 2;
            double precision = 0.00001;
            Assert.AreEqual(Math.Pow(value, 1d / degree), Calculator.NewtonRoot(value, degree, precision), precision);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareRootOfMinusFourThrowsException()
        {
            Calculator.NewtonRoot(-4, 2, 0.00001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroRootOfFourThrowsException()
        {
            Calculator.NewtonRoot(4, 0, 0.00001);
        }
    }
}
