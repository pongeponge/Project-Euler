using System;
using System.Diagnostics;

namespace Problem21
{
    class Program
    {
        //上限
        static int MaxNum = 10000;
        //約数の和リスト
        static Int64[] SumDivisors;

        static void Main(string[] args)
        {

            Debug.WriteLine(SumOfAmicableNumbers());
        }

        /// <summary>
        /// 問題を解く
        /// </summary>
        static Int64 SumOfAmicableNumbers()
        {
            CreateSumDivisorsArray();

            return SumAmicable();
        }

        /// <summary>
        /// 約数の和リストを作成
        /// </summary>
        static void CreateSumDivisorsArray()
        {
            SumDivisors = new Int64[MaxNum + 1];

            for (int p = 2; p <= SumDivisors.Length / 2; p++)
            {
                for (int i = p * 2; i < SumDivisors.Length; i += p)
                {
                    SumDivisors[i] += p;
                }
            }

            for (int i = 2; i < SumDivisors.Length; i++)
            {
                SumDivisors[i] += 1;

                if (SumDivisors[i] > MaxNum) SumDivisors[i] = 0;
            }
        }

        /// <summary>
        /// 友愛数の総和を求める
        /// </summary>
        static Int64 SumAmicable()
        {
            Int64 sum = 0;

            for (int i = 2; i < SumDivisors.Length; i++)
            {
                if (SumDivisors[i] != i & SumDivisors[SumDivisors[i]] == i)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
