using System;
using System.Diagnostics;
using System.Text;

namespace Problem43
{
    class Program
    {
        static void Main(string[] args)
        {
            P43 p = new P43();
            Debug.WriteLine(p.Solve());
        }
    }

    class P43
    {
        //割る数(素数)の配列
        private int[] primes = { 2, 3, 5, 7, 11, 13, 17 };
        //パンデジタル数の要素
        private int[] panElement = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P43()
        {

        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns></returns>
        public Int64 Solve()
        {
            Int64 sum = 0;
            PandigitalNumber pan = new PandigitalNumber(this.panElement);

            //パンデジタル数が最終状態になれば終了
            while (pan.IsEnd == false)
            {
                if (this.IsSubstringDivisibilityNumber(pan.Value) == true)
                {
                    //部分文字列被整除性数であれば加える
                    sum += Int64.Parse(pan.Value);
                }

                //次のパンデジタル数を計算する
                pan.Next();
            }

            return sum;
        }

        /// <summary>
        /// 割り切れる？
        /// </summary>
        /// <param name="dividend">割られる数</param>
        /// <param name="divisor">割る数</param>
        /// <returns></returns>
        private bool IsDivisible(Int64 dividend, int divisor)
        {
            return dividend % divisor == 0 ? true : false;
        }

        /// <summary>
        /// 部分文字列被整除性数か？
        /// </summary>
        /// <param name="num">検査する値</param>
        /// <returns></returns>
        private bool IsSubstringDivisibilityNumber(string strnum)
        {
            for (int i = 0; i < primes.Length; i++)
            {
                Int64 dividend = Int64.Parse(strnum.Substring(7 - i, 3));
                int divisor = this.primes[this.primes.Length - i - 1];

                if (this.IsDivisible(dividend, divisor) == false) return false;
            }

            return true;
        }
    }

    /// <summary>
    /// パンデジタルクラス
    /// </summary>
    class PandigitalNumber
    {
        //要素
        private int[] elements;
        //順序
        private int[] order;
        //値
        public string Value
        {
            get { return GetValue(); }
        }
        //逆順の値
        public string ReverseValue
        {
            get { return GetReverseValue(); }
        }
        //最終状態に到達したか
        public bool IsEnd;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="e">要素</param>
        public PandigitalNumber(int[] e)
        {
            this.elements = e;
            this.SetFirstOrder();
            this.IsEnd = false;
        }

        /// <summary>
        /// 順序の設定
        /// </summary>
        private void SetFirstOrder()
        {
            this.order = new int[this.elements.Length];

            for (int i = 0; i < order.Length; i++)
                this.order[i] = i + 1;
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        /// <returns></returns>
        private string GetValue()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in order)
            {
                sb.Append(this.elements[i - 1]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 逆順序での取得
        /// </summary>
        /// <returns></returns>
        private string GetReverseValue()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in order)
            {
                sb.Append(this.elements[order.Length - i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 次のパンデジタル数を求める
        /// </summary>
        /// <returns></returns>
        public string Next()
        {
            int index = this.order.Length - 1;

            for (int i = this.order.Length - 2; i >= 0; i--)
            {
                if (this.order[i] < this.order[i + 1])
                {
                    this.SwapOrder(i, this.SearchMinValue(this.order[i], i + 1));
                    Array.Sort(order, i + 1, this.order.Length - i - 1);
                    return this.Value;
                }
            }

            this.IsEnd = true;

            return this.Value;
        }


        /// <summary>
        /// 指定したインデックス値以降から
        /// 基準より大きく、最小のオーダー値を持つインデックスを求める
        /// </summary>
        /// <param name="threshold">基準値</param>
        /// <param name="index">インデックス値</param>
        /// <returns></returns>
        private int SearchMinValue(int threshold, int index)
        {
            int min = int.MaxValue;
            int p = -1;

            for (int i = index; i < this.order.Length; i++)
            {
                if (this.order[i] > threshold && this.order[i] < min)
                {
                    min = this.order[i];
                    p = i;
                }
            }

            //見つからない場合
            if (p == -1)
            {
                p = this.order.Length - 1;
            }

            return p;
        }

        /// <summary>
        /// 順序の入れ替え
        /// </summary>
        /// <param name="p1">入れ替え位置1</param>
        /// <param name="p2">入れ替え位置2</param>
        private void SwapOrder(int p1, int p2)
        {
            int p = this.order[p1];
            this.order[p1] = this.order[p2];
            this.order[p2] = p;
        }
    }
}

