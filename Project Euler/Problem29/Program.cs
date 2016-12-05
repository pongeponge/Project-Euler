using System.Diagnostics;
using System.Linq;

namespace Problem29
{
    class Program
    {
        //範囲
        static int min = 2;
        static int max = 100;

        static void Main(string[] args)
        {
            Debug.WriteLine(DistinctPowers());
        }

        static int DistinctPowers()
        {
            bool[] findA = new bool[max + 1];
            int sum = 0;

            for (int a = min; a <= max; a++)
            {
                if (findA[a] == false)
                {
                    int b = maxB(a, findA);

                    sum += NumberCount(b);
                }
            }

            return sum;
        }

        /// <summary>
        /// a^bの最も大きいbを調べる
        /// </summary>
        static int maxB(int a, bool[] findA)
        {
            int b = 0;

            for (int i = a; i <= max; i *= a)
            {
                findA[i] = true;
                b++;
            }

            return b;
        }

        /// <summary>
        /// b乗まである場合の出現個数を求める
        /// </summary>
        static int NumberCount(int b)
        {
            if (b == 1) return max - min + 1;

            bool[] findB = new bool[b * max + 1];

            for (int d = 1; d <= b; d++)
            {
                for (int j = min * d; j <= d * max; j += d)
                {
                    if (findB[j] == false) findB[j] = true;
                }
            }

            return findB.Where(obj => obj == true).Count();
        }
    }
}
