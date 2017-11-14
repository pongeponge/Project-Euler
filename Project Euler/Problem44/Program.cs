using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem44
{
    class Program
    {
        static void Main(string[] args)
        {
            P44 p = new P44();
            Debug.WriteLine(p.Solve());
        }
    }

    class P44
    {
        //ペンタゴン数格納リスト
        private List<int> numbers;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P44()
        {
            this.numbers = new List<int>();
        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns>解を出力する/見つからない場合は-1を返す</returns>
        public int Solve()
        {
            numbers.Add(this.CalcPentagonNumber(1));

            for (int count = 2; count != int.MaxValue; count++)
            {
                for (int i = numbers.Count - 2; i >= 0; i--)
                {
                    if (this.TestPentagonNumber(i) == true)
                    {
                        return numbers[numbers.Count - 1] - numbers[i];
                    }
                }

                numbers.Add(this.CalcPentagonNumber(count));
            }

            return -1;
        }

        /// <summary>
        /// ペンタゴン数を加減算した場合の検査
        /// </summary>
        /// <param name="si">ペンタゴン数のインデックス</param>
        /// <returns></returns>
        private bool TestPentagonNumber(int si)
        {
            if (this.SubtractionNumbers(si) == true)
            {
                if (this.AdditionNumbers(si) == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 現在の最大ペンタゴン数と引き算の結果ペンタゴン数になるか？
        /// </summary>
        /// <param name="si">ペンタゴン数のインデックス</param>
        /// <returns></returns>
        private bool SubtractionNumbers(int si)
        {
            int sub = this.numbers[this.numbers.Count - 1] - this.numbers[si];

            return this.numbers.Contains(sub);
        }

        /// <summary>
        /// 現在の最大ペンタゴン数と足し算の結果ペンタゴン数になるか？
        /// </summary>
        /// <param name="si">ペンタゴン数のインデックス</param>
        /// <returns></returns>
        private bool AdditionNumbers(int si)
        {
            int sum = this.numbers[this.numbers.Count - 1] + this.numbers[si];

            return this.IsPentagonNumber(sum);
        }

        /// <summary>
        /// ペンタゴン数の計算
        /// </summary>
        /// <param name="n">インデックス値</param>
        /// <returns></returns>
        private int CalcPentagonNumber(int i)
        {
            return (i * (3 * i - 1)) / 2;
        }

        /// <summary>
        /// ペンタゴンナンバー？
        /// </summary>
        /// <param name="n">検査する値</param>
        /// <returns></returns>
        private bool IsPentagonNumber(int n)
        {
            double k = (1 + Math.Sqrt(1 + 24 * n)) / 6;

            if ((int)k == k) return true;
            else return false;
        }
    }
}
