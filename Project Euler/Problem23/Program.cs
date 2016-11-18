using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem23
{
    class Program
    {
        //上限
        static int MaxNum = 28123;

        static void Main(string[] args)
        {
            int[] an = CreateAbundantNumbersArray(CreateSumDivisorsArray());

            Debug.WriteLine(Result(an));
        }

        /// <summary>
        /// 約数の和リストを作成
        /// </summary>
        static Int64[] CreateSumDivisorsArray()
        {
            Int64[] SumDivisors = new Int64[MaxNum + 1];

            for (int p = 2; p <= MaxNum / 2; p++)
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

            return SumDivisors;
        }

        /// <summary>
        /// 過剰数の和リストを作成
        /// </summary>
        /// <param name="sd">約数の和リスト</param>
        static int[] CreateAbundantNumbersArray(Int64[] sd)
        {
            List<int> an = new List<int>();
            List<int> an2 = new List<int>();

            //過剰数リスト
            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i] > i)
                {
                    an.Add(i);
                }
            }

            //過剰数の和リスト
            for (int i = 0; i < an.Count - 1; i++)
            {
                for (int j = i; j < an.Count; j++)
                {
                    int tmp = an[i] + an[j];
                    if (tmp <= MaxNum)
                    {
                        an2.Add(tmp);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //ソートと重複の削除
            an2.Sort();

            return an2.Distinct().ToArray();
        }

        /// <summary>
        /// 過剰数の和で表せられない数を全部足す
        /// </summary>
        /// <param name="an2">過剰数の和リスト</param>
        static Int64 Result(int[] an2)
        {
            Int64 sum = 0;
            int count = 0;

            for (int i = 0; i <= MaxNum; i++)
            {
                if (an2[count] == i)
                {
                    count++;
                }
                else
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
