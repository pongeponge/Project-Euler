using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem39
{
    class Program
    {
        static void Main(string[] args)
        {
            P39 p = new P39();
            Debug.WriteLine(p.Solve());
        }
    }

    class P39
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P39()
        {

        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns></returns>
        public int Solve()
        {
            int maxPatternCount = 0;
            int maxP = 1;

            for (int p = 1; p <= 1000; p++)
            {
                int patternCount = SetSides(p);

                if (patternCount > maxPatternCount)
                {
                    maxPatternCount = patternCount;
                    maxP = p;
                }
            }

            return maxP;
        }

        /// <summary>
        /// 斜辺以外の辺を決める
        /// </summary>
        /// <param name="p">週長</param>
        /// <returns>三角形になるパターン数</returns>
        private int SetSides(int p)
        {
            int patternCount = 0;

            for (int a = 1; a < p / 2; a++)
            {
                int b = (p * (2 * a - p)) / (2 * (a - p));

                if (a > b) break;

                if (IsMakeTriangle(p, a, b) == true)
                {
                    patternCount++;
                }
            }

            return patternCount;
        }

        /// <summary>
        /// 三角形になるか？
        /// </summary>
        /// <param name="p">周長</param>
        /// <param name="a">辺1</param>
        /// <param name="b">辺2</param>
        /// <returns></returns>
        private bool IsMakeTriangle(int p, int a, int b)
        {
            if (a * a + b * b == (p - a - b) * (p - a - b))
            {
                //Debug.WriteLine(string.Format("{0},{1},{2}:{3}", a, b, a * a + b * b, a + b + Math.Sqrt(a * a + b * b)));
                return true;
            }

            return false;
        }
    }
}
