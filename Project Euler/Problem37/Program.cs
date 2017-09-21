using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem37
{
    class Program
    {
        static void Main(string[] args)
        {
            P37 p = new P37();
            Debug.WriteLine(p.Solve());

        }
    }

    class P37
    {
        //1桁の素数
        private int[] Primes = { 2, 3, 5, 7 };
        //切除可能素数保管庫
        private List<int> TruncatablePrimes = new List<int>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P37()
        {
        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns>切除可能素数の和</returns>
        public int Solve()
        {
            //中央の数の桁(-1の時は無し)
            for (int centerDigit = -1; this.TruncatablePrimes.Count < 11; centerDigit++)
            {
                //頭側の素数インデックス
                for (int top = 0; top < this.Primes.Length; top++)
                {
                    //尻側の素数インデックス
                    for (int bottom = 1; bottom < this.Primes.Length; bottom++)
                    {
                        //中央の数の最大最小値
                        int centerMin = (int)Math.Pow(10, centerDigit);
                        int centerMax = (int)Math.Pow(10, centerDigit + 1);
                        //中央の数
                        for (int center = centerMin; center < centerMax; center++)
                        {
                            int num;

                            //頭・中央・尻を合体
                            if (centerDigit == -1)
                            {
                                num = int.Parse(string.Format("{0}{1}", this.Primes[top], this.Primes[bottom]));
                            }
                            else
                            {
                                num = int.Parse(string.Format("{0}{1}{2}", this.Primes[top], center, this.Primes[bottom]));
                            }

                            //検査して良好な結果なら保管庫に保存
                            if (this.IsTruncatablePrimes(num) == true)
                            {
                                this.TruncatablePrimes.Add(num);
                                Debug.WriteLine(num);
                            }
                        }

                    }
                }
            }

            return this.TruncatablePrimes.Sum();
        }

        /// <summary>
        /// 切除可能素数？
        /// </summary>
        /// <param name="num">検査する数</param>
        /// <returns></returns>
        private bool IsTruncatablePrimes(int num)
        {
            int digits = (int)Math.Log10(num) + 1;

            if (this.IsPrime(num) == false) return false;

            //左右から切除していって、その都度検査
            for (int i = 1; i < digits; i++)
            {
                if (this.IsPrime(this.LeftCut(num, i)) == false) return false;
                if (this.IsPrime(this.RightCut(num, i)) == false) return false;
            }

            return true;
        }

        /// <summary>
        /// 素数？
        /// </summary>
        /// <param name="num">検査する数</param>
        /// <returns></returns>
        private bool IsPrime(int num)
        {
            //1,2だけ先に判定
            if (num == 1) return false;
            if (num == 2) return true;

            //ルートnより上は調べる必要ない
            int n = (int)Math.Sqrt(num);
            //nが偶数なら奇数に
            if (n % 2 == 0) n++;

            //n以下の素数で割り切れるか検査
            for(int i = (int)n; i >= 3; i-=2)
            {
                if (num % i == 0) return false;
            }
            if (num % 2 == 0) return false;

            return true;
        }

        /// <summary>
        /// 左側(頭)を切除
        /// </summary>
        /// <param name="num">切除される数</param>
        /// <param name="cutNum">切除する文字数</param>
        /// <returns></returns>
        private int LeftCut(int num, int cutNum)
        {
            return int.Parse(num.ToString().Substring(cutNum));
        }

        /// <summary>
        /// 右側(尻)を切除
        /// </summary>
        /// <param name="num">切除される数</param>
        /// <param name="cutNum">切除する文字数</param>
        /// <returns></returns>
        private int RightCut(int num, int cutNum)
        {
            return int.Parse(num.ToString().Substring(0, num.ToString().Length - cutNum));
        }


    }
}
