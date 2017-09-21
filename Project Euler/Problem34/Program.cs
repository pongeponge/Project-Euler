using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem34
{
    class Program
    {
        static void Main(string[] args)
        {
            P34 p = new P34();
            Debug.WriteLine(p.Solve());
        }
    }

    class P34
    {
        //階乗
        Dictionary<int, int> factrial;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P34()
        {
            this.SetFactrial();
        }

        /// <summary>
        /// 階乗の値をセットする
        /// </summary>
        private void SetFactrial()
        {
            this.factrial = new Dictionary<int, int>();

            this.factrial[0] = 1;
            for (int i = 1; i < 10; i++)
            {
                this.factrial[i] = this.factrial[i - 1] * i;
            }
        }

        /// <summary>
        /// 問題を解く
        /// </summary>
        public int Solve()
        {
            int answer = 0;
            int upperLimit = this.GetUpperLimit();

            //問題文より、1!と2!は含まないので3!から
            for (int num = 3; num < upperLimit; num++)
            {
                if (num == this.SumDigitsFactrial(num))
                    answer += num;
            }

            return answer;
        }

        /// <summary>
        /// 探索する値の最大値
        /// </summary>
        private int GetUpperLimit()
        {
            int d = 1;

            //9がd桁並んでいるとすると(10^d)-1と書ける
            //d*9!が(10^d)-1より小さくなるdを見つければ、(10^d)-1以上を調べる必要は無くなる
            while (Math.Log10(d*factrial[9]+1) >= d)
            {
                d++;
            }

            return d*factrial[9];
        }

        /// <summary>
        /// 各桁を階乗し、総和を求める
        /// </summary>
        private int SumDigitsFactrial(int num)
        {
            int sum = 0;

            foreach(char c in num.ToString())
            {
                sum += this.factrial[(int)(c - '0')];
            }

            return sum;
        }

    }
}
