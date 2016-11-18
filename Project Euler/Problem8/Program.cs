using System;
using System.Diagnostics;
using System.IO;

namespace Problem8
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\\..\\1000DigitNumber.txt";
            //改行の削除と、0で区切って節を作る
            string[] sd = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Split('0');

            double maxProduct = 0;
            for (int i = 0; i < sd.Length; i++)
            {

                if (sd[i].Length >= 13)
                {
                    double tmp = Score(sd[i]);

                    if (maxProduct < tmp) maxProduct = tmp;
                }
            }

            Debug.WriteLine(maxProduct);

        }

        /// <summary>
        /// 節内で最大の総乗値を求める
        /// </summary>
        /// <param name="s">数字の節</param>
        /// <returns>節内で最大の相乗値</returns>
        static double Score(String s)
        {

            double maxScore = 0;
            for (int i = s.Length - 13; i >= 0; i--)
            {
                String str = s.Substring(i, 13);
                double tmp = Product(str);

                if (maxScore < tmp) maxScore = tmp;
            }

            return maxScore;
        }

        /// <summary>
        /// 総乗を求める
        /// </summary>
        /// <param name="s">13文字の数字列</param>
        /// <returns>総乗の値</returns>
        static double Product(string s)
        {
            double score = 1;

            foreach (char c in s)
            {
                score *= (c - 48);
            }

            return score;
        }

    }
}