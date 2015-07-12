using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;

namespace Task1.Tests
{
    [TestClass]
    public class NewtonRootTests
    {
        [TestMethod]
        public void SquareRootOfFourEqualsTwo()
        {
            double precision = 0.00001;
            double diviation = GetDiviation(4, 2, precision);
            Assert.IsTrue(diviation < Math.Abs(precision));
        }

        [TestMethod]
        public void FourthRootOfEightyOneEqualsThree()
        {
            double precision = 0.00001;
            double diviation = GetDiviation(81, 4, precision);
            Assert.IsTrue(diviation < Math.Abs(precision));
        }

        [TestMethod]
        public void ThirdRootOfEightThousandthEqualsTwoTenth()
        {
            double precision = 0.00001;
            double diviation = GetDiviation(0.008, 2, precision);
            Assert.IsTrue(diviation < Math.Abs(precision));
        }

        [TestMethod]
        public void TenthRootOfOneThousandTwentyFourEqualsTwo()
        {
            double precision = 0.00001;
            double diviation = GetDiviation(1024, 10, precision);
            Assert.IsTrue(diviation < Math.Abs(precision));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareRootOfMinusFourThrowsException()
        {
            double precision = 0.00001;
            double diviation = GetDiviation(-4, 2, precision);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroRootOfFourThrowsException()
        {
            double precision = 0.00001;
            double diviation = GetDiviation(4, 0, precision);
        }

        private static double GetDiviation(double value, int degree, double precision)
        {
            double NewtonResult = Calculator.NewtonRoot(value, degree, precision);
            double PowResult = Math.Pow(value, 1d / degree);
            return Math.Abs(NewtonResult - PowResult);
        }
    }
}
