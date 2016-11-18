using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Problem13
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] nums = ReadData();

            Debug.WriteLine(TopTenDigit(BigSum(nums)));
        }

        /// <summary>
        /// データの読み込み
        /// </summary>
        static BigInteger[] ReadData()
        {
            string path = @"..\..\data.txt";

            return File.ReadAllLines(path).Select(obj => BigInteger.Parse(obj)).ToArray();
        }

        /// <summary>
        /// 総和
        /// </summary>
        static BigInteger BigSum(BigInteger[] n)
        {
            BigInteger sum = 0;

            foreach (BigInteger b in n)
            {
                sum += b;
            }

            return sum;
        }

        /// <summary>
        /// 上位10桁を返す
        /// </summary>
        static String TopTenDigit(BigInteger n)
        {
            return n.ToString().Substring(0, 10);
        }
    }
}
