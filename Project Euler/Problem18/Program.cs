using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Problem18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] data = FormatData(ReadFile());

            Debug.WriteLine(Maximum(data));
        }

        /// <summary>
        /// データを読み込む
        /// </summary>
        static string[] ReadFile()
        {
            string path = @"..\..\data.txt";

            return File.ReadLines(path).ToArray<string>();
        }

        /// <summary>
        /// テキストデータを数値に変換する
        /// </summary>
        static int[][] FormatData(String[] str)
        {
            int[][] data = new int[str.Length][];

            for (int i = 0; i < str.Length; i++)
            {
                String[] s = str[i].Split(' ');
                data[i] = new int[s.Length];

                for (int j = 0; j < s.Length; j++)
                {
                    data[i][j] = int.Parse(s[j]);
                }
            }

            return data;
        }

        /// <summary>
        /// 最大値を調べる
        /// </summary>
        static int Maximum(int[][] data)
        {

            for (int i = data.Count() - 2; i >= 0; i--)
            {
                for (int j = data[i].Length - 1; j >= 0; j--)
                {
                    int a = data[i][j] + data[i + 1][j + 1];
                    int b = data[i][j] + data[i + 1][j];

                    data[i][j] = (a >= b) ? a : b;
                }
            }

            return data[0][0];
        }
    }
}
