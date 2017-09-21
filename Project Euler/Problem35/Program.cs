using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem35
{
    class Program
    {
        static void Main(string[] args)
        {
            p35 p = new p35();
            Debug.WriteLine(p.Solve());
        }
    }

    class p35
    {
        //素数リスト
        private List<int> primeList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public p35()
        {
            this.CreatePrimeList(1000000);
        }

        /// <summary>
        /// 解く
        /// </summary>
        public int Solve()
        {
            //巡回素数の個数カウンタ
            int count = 0;

            for (int i = 0; i < this.primeList.Count; i++)
            {
                int c = 0;

                if (this.IsCircularPrime(this.primeList[i], ref c) == true)
                {
                    Debug.WriteLine(this.primeList[i]);
                    count += c;
                }

                this.primeList[i] = 0;
            }

            return count;
        }

        /// <summary>
        /// 巡回素数か？
        /// </summary>
        /// <param name="p">検査する素数</param>
        private bool IsCircularPrime(int p, ref int c)
        {
            int count = 1;
            int d = (int)Math.Log10(p) + 1;

            //1桁の素数以外を調べる
            if (d != 1)
            {
                int np = p;

                for (int i = 0; i < d - 1; i++)
                {
                    np = this.NumberCirculer(np, d);

                    //数字が無ければ巡回素数じゃない
                    if (this.primeList.Contains(np) == false) return false;
                    else
                    {
                        //11みたいな巡回シフトしても変わらないやつ以外
                        if (np != p) count++;
                    }
                }
            }

            c = count;

            return true;
        }

        /// <summary>
        /// 10進右巡回シフトさせる(最小桁を最大桁にする)
        /// </summary>
        /// <param name="n">右巡回シフトさせる値</param>
        /// <param name="d">桁</param>
        /// <returns></returns>
        public int NumberCirculer(int n, int d)
        {
            return (int)(n%10 * Math.Pow(10, d - 1) + (n / 10));
        }

        /// <summary>
        /// 素数リストの初期化
        /// </summary>
        private void InitPrimeList(int max)
        {
            this.primeList = new List<int>();

            for (int i = 0; i <= max; i++)
            {
                this.primeList.Add(i);
            }
        }

        /// <summary>
        /// 素数リストの作成
        /// </summary>
        /// <param name="max">最大値</param>
        private void CreatePrimeList(int max)
        {
            this.InitPrimeList(max);

            int skip = this.primeList[2];

            while (true)
            {
                int start = 2 * skip;

                if (start > this.primeList.Count) break;

                for (int i = start; i < this.primeList.Count; i += skip)
                {
                    this.primeList[i] = 0;
                }

                for (int i = skip + 1; i < this.primeList.Count; i++)
                {
                    if (this.primeList[i] != 0)
                    {
                        skip = i;
                        break;
                    }
                }
            }

            //1は素数じゃないので除外
            this.primeList[1] = 0;

            this.primeList.RemoveAll(x => x == 0);
        }

    }

}