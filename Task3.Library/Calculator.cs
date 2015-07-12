using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public static class Calculator
    {
        /// <summary>
        /// Calculates a nth root of a number
        /// </summary>
        /// <param name="x">Radicand</param>
        /// <param name="degree">Degree of the root</param>
        /// <param name="precision">Precision of the result</param>
        /// <returns>Root of the given degree</returns>
        /// <exception cref="ArgumentException">Thrown when <see cref="degree"/> is non-positive number, or <see cref="x"/> is negative and <see cref="degree"/> is an even number.</exception>
        public static double NewtonRoot(double x, int degree, double precision)
        {
            if (degree <= 0)
            {
                throw new ArgumentException("Can't calculate root of non-positive degree.", "degree");
            }
            if (x < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("Can't calculate an even degree root of a negative number.", "degree");
            }
            precision = Math.Abs(precision);
            double delta, result = 1;
            do
            {
                delta = (1d / degree) * (x / Math.Pow(result, degree - 1) - result);
                result += delta;
            }
            while (Math.Abs(delta) > precision);
            return result;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Euclidian Algorithm.
        /// </summary>
        /// <param name="timeTaken">Stores time taken by calculation.</param>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        public static int EuclideanGCD(out TimeSpan timeTaken, params int[] numbers)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int gdc = EuclideanGCD(numbers);
            timeTaken = stopwatch.Elapsed;
            return gdc;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Euclidian Algorithm.
        /// </summary>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when less than two <see cref="numbers"/> provided.</exception>
        public static int EuclideanGCD(params int[] numbers)
        {
            int gdc = 1;
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Can't calculate GCD of less than two numbers.");
            }
            gdc = EuclideanGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gdc = EuclideanGCD(gdc, numbers[i]);
            }
            return gdc;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of three numbers using Euclidian Algorithm.
        /// </summary>
        /// <param name="a">First natural number.</param>
        /// <param name="b">Second natural number.</param>
        /// <param name="c">Third natural number.</param>
        /// <returns>Greatest Common Devisor of <see cref="a"/>, <see cref="b"/> and <see cref="c"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when at least one argument is a negative number.</exception>
        public static int EuclideanGCD(int a, int b, int c)
        {
            return EuclideanGCD(EuclideanGCD(a, b), c);
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of two numbers using Euclidian Algorithm.
        /// </summary>
        /// <param name="a">First natural number.</param>
        /// <param name="b">Second natural number.</param>
        /// <returns>Greatest Common Devisor of <see cref="a"/> and <see cref="b"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when at least one argument is a negative number.</exception>
        public static int EuclideanGCD(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Can't calculate GCD of negative numbers.");
            }
            while(b > 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Binary GCD Algorithm.
        /// </summary>
        /// <param name="timeTaken">Stores time taken by calculation.</param>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        public static int BinaryGCD(out TimeSpan timeTaken, params int[] numbers)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int gdc = BinaryGCD(numbers);
            timeTaken = stopwatch.Elapsed;
            return gdc;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Binary GCD Algorithm.
        /// </summary>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when less than two <see cref="numbers"/> provided.</exception>
        public static int BinaryGCD(params int[] numbers)
        {
            int gdc = 1;
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Can't calculate GCD of less than two numbers.");
            }
            gdc = BinaryGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gdc = BinaryGCD(gdc, numbers[i]);
            }
            return gdc;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of three numbers using Binary GCD Algorithm.
        /// </summary>
        /// <param name="a">First natural number.</param>
        /// <param name="b">Second natural number.</param>
        /// <param name="c">Third natural number.</param>
        /// <returns>Greatest Common Devisor of <see cref="a"/>, <see cref="b"/> and <see cref="c"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when at least one argument is a negative number.</exception>
        public static int BinaryGCD(int a, int b, int c)
        {
            return BinaryGCD(BinaryGCD(a, b), c);
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of two numbers using Binary GCD Algorithm.
        /// </summary>
        /// <param name="a">First natural number.</param>
        /// <param name="b">Second natural number.</param>
        /// <returns>Greatest Common Devisor of <see cref="a"/> and <see cref="b"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when at least one argument is a negative number.</exception>
        public static int BinaryGCD(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Can't calculate GCD of negative numbers.");
            }

            int shift;
            if (a == 0) return b;
            if (b == 0) return a;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    int t = b; b = a; a = t;
                }
                b = b - a;
            } while (b != 0);

            return a << shift;
        }
    }
}
