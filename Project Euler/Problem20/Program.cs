using System;
using System.Diagnostics;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(FactorialDigitSum(100));
        }

        static BigInteger FactorialDigitSum(int n)
        {
            BigInteger bi = Factorial(n);

            return DigitSum(bi);
        }

        static BigInteger Factorial(int n)
        {
            BigInteger bi = 1;

            for (BigInteger i = 2; i <= n; i++)
            {
                bi *= i;
            }

            return bi;
        }

        static BigInteger DigitSum(BigInteger bi)
        {
            String s = bi.ToString();
            BigInteger sum = 0;

            foreach (char c in s)
            {
                sum += (c - '0');
            }

            return sum;
        }
    }
}
