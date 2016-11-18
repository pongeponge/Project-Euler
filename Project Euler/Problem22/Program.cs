using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Problem22
{
    class Program
    {
        static String[] names;

        static void Main(string[] args)
        {
            ReadNames();

            Debug.WriteLine(TotalNameScore());
        }

        /// <summary>
        /// 名前ファイルの読み込みとソート
        /// </summary>
        static void ReadNames()
        {
            String path = @"..\..\names.txt";

            names = File.ReadAllText(path).Split(',').Select(obj => obj.Replace("\"", "")).ToArray();

            Array.Sort(names);
        }

        /// <summary>
        /// 全名前スコアを求める
        /// </summary>
        static Int64 TotalNameScore()
        {
            Int64 sum = 0;

            for (int i = 0; i < names.Length; i++)
            {
                int rank = i + 1;
                int score = 0;

                foreach (char c in names[i])
                {
                    score += (c - '@');
                }

                sum += (rank * score);
            }

            return sum;
        }
    }
}
