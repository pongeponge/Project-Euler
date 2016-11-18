using System;
using System.Diagnostics;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(SumPrime());
        }

        /// <summary>
        /// 素数配列の総和を求める
        /// </summary>
        /// <returns>総和</returns>
        static Int64 SumPrime()
        {
            int[] p = SoE();

            Int64 sum = 0;
            for(int i = 0; i < p.Length; i++)
            {
                sum += p[i];
            }

            return sum;
        }

        /// <summary>
        /// エラトステネスの篩
        /// </summary>
        /// <returns>素数配列</returns>
        static int[] SoE()
        {
            int max = 2000000;
            int[] lp = new int[max-2];

            lp[0] = 2;
            for (int i = 1; i < lp.Length; i+=2)
            {
                lp[i] = 2+i;
            }

            int sq = (int)Math.Sqrt(max);
            for(int i = 1; i < sq; i++)
            {
                if (lp[i] != 0)
                {
                    for (int j = i + lp[i]; j < lp.Length; j += lp[i])
                    {
                        lp[j] = 0;
                    }
                }
            }

            return lp;
        }
    }
}
