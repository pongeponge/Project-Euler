using System.Diagnostics;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(Result());
        }

        static BigInteger Result()
        {
            string str = Power(Power(Power(2, 10), 10), 10).ToString();

            return DigitSum(str);
        }

        /// <summary>
        /// xのy乗を求める
        /// </summary>
        static BigInteger Power(BigInteger x, BigInteger y)
        {
            BigInteger n = 1;
            for (int i = 0; i < y; i++)
            {
                n *= x;
            }

            return n;
        }

        /// <summary>
        /// 各桁の総和を求める
        /// </summary>
        static int DigitSum(string s)
        {
            int n = 0;

            foreach (char c in s)
            {
                n += (c - '0');
            }

            return n;
        }
    }
}
