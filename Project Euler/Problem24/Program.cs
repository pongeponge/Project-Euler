using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem24
{
    class Program
    {
        static List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            Int64 allPatternNum = Factorial(digits.Count);


            Debug.WriteLine(RankingNumber(allPatternNum, 1000000));

        }

        /// <summary>
        /// n!を求める
        /// </summary>
        static Int64 Factorial(int n)
        {
            if (n == 0) return 0;

            Int64 p = 1;

            for (int i = 2; i <= n; i++)
            {
                p *= i;
            }

            return p;
        }

        /// <summary>
        /// n番目の番号を求める
        /// </summary>
        /// <param name="apn">全パターン数</param>
        /// <param name="rank">求める値が何番目か</param>
        static String RankingNumber(Int64 apn, Int64 rank)
        {
            //ランクは1番から始まる＆最大数以上はなし
            if (rank <= 0) return "うわっ…私のRank、低すぎ…？";
            if (rank > apn) return "常識的に考えてRank高すぎ";
            rank--;

            List<int> d = new List<int>(digits);
            String s = string.Empty;


            for (int i = d.Count; i >= 1; i--)
            {
                apn = apn / i;
                int p = (int)(rank / apn);
                rank = rank % apn;
                s += d[p].ToString();
                d.RemoveAt(p);
            }

            return s;
        }
    }
}
