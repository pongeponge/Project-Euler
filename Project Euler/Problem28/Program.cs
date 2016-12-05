using System;
using System.Diagnostics;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(NumberSpiralDiagonals(1001));
        }

        static Int64 NumberSpiralDiagonals(int size)
        {
            int loops = (size - 1) / 2;

            int a = 0;
            Int64 sum = 0;
            for (int m = 0; m <= loops; m++)
            {
                a = ComputeA(a, m - 1);
                sum += LoopSum(a, m);
            }

            return sum;
        }

        /// <summary>
        /// m週目の右下の値aを求める
        /// </summary>
        static int ComputeA(int a, int m)
        {
            if (m < 0) return 1;

            int b = 2 + 8 * m;

            return a + b;
        }

        /// <summary>
        /// 一周分の和を求める
        /// </summary>
        static Int64 LoopSum(int a, int m)
        {
            if (m == 0) return a;

            return 4 * a + 12 * m;
        }
    }
}
