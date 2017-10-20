using System;
using System.Diagnostics;

namespace Problem40
{
    class Program
    {
        static void Main(string[] args)
        {
            P40 p = new P40();
            Debug.WriteLine(p.Solve());
        }
    }

    class P40
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P40()
        {
        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns>答え</returns>
        public int Solve()
        {
            int n = 1;
            int pro = 1;

            for (int d = 0; d < 6; d++)
            {
                pro *= this.GetNumberCharcter(n-1);

                n *= 10;
            }

            return pro;
        }

        /// <summary>
        /// 桁ごとの文字数を計算する
        /// </summary>
        /// <param name="d">桁</param>
        /// <returns>文字数</returns>
        private int CalcCharctersOfDigit(int d)
        {
            //d桁の時、文字数tはいくらか(1から9なら9文字、10から99なら180文字)
            //t = 9 * 10^(d - 1) * d
            return (int)(9 * Math.Pow(10, d - 1) * d);
        }

        /// <summary>
        /// 値を調べる
        /// </summary>
        /// <param name="n">番号</param>
        /// <returns>値</returns>
        private int GetNumberCharcter(int n)
        {
            //桁を調べる
            for (int k = 1; k <= 9; k++)
            {
                int w = this.CalcCharctersOfDigit(k);

                if (n < w)
                {
                    //数字numberを計算し、pos番目の文字(値)を返す
                    int number = n / k + (int)Math.Pow(10, k - 1);
                    int pos = n % k;

                    return number.ToString()[pos] - '0';
                }

                n = n - w;
            }

            return -1;
        }
    }
}
