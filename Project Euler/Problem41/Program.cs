using System;
using System.Diagnostics;
using System.Text;

namespace Problem41
{
    class Program
    {
        static void Main(string[] args)
        {
            P41 p = new P41();
            Debug.WriteLine(p.Solve());
        }
    }

    class P41
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P41()
        {

        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns></returns>
        public int Solve()
        {

            for (int i = 9; i >= 2; i--)
            {
                //n桁パンデジタル数の用意
                int[] n = new int[i];
                int max = 1 ;

                for (int j = 0; j < n.Length; j++)
                {
                    n[j] = j + 1;
                    max = max * (j + 1);
                }

                PandigitalNumber pn = new PandigitalNumber(n);

                //n桁パンデジタル数が素数かどうか調査
                for (int k = 0; k < max; k++)
                {
                    if (this.IsPrime(pn.ReverseValue) == true)
                    {
                        return pn.ReverseValue;
                    }

                    pn.Next();
                }
            }

            //見つからない場合は0を返す
            return 0;
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
            for (int i = (int)n; i >= 3; i -= 2)
            {
                if (num % i == 0) return false;
            }
            if (num % 2 == 0) return false;

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
        public int Value
        {
            get { return GetValue(); }
        }
        //逆順の値
        public int ReverseValue
        {
            get { return GetReverseValue(); }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="e">要素</param>
        public PandigitalNumber(int[] e)
        {
            this.elements = e;
            this.SetFirstOrder();
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
        private int GetValue()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in order)
            {
                sb.Append(this.elements[i - 1]);
            }

            return int.Parse(sb.ToString());
        }

        /// <summary>
        /// 逆順序での取得
        /// </summary>
        /// <returns></returns>
        private int GetReverseValue()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in order)
            {
                sb.Append(this.elements[order.Length - i]);
            }

            return int.Parse(sb.ToString());
        }

        /// <summary>
        /// 次のパンデジタル数を求める
        /// </summary>
        /// <returns></returns>
        public int Next()
        {
            int index = this.order.Length - 1;

            for (int i = this.order.Length - 2; i >= 0; i--)
            {
                if (this.order[i] < this.order[i + 1])
                {
                    this.SwapOrder(i, this.SearchMinValue(this.order[i], i + 1));
                    Array.Sort(order, i + 1, this.order.Length - i - 1);
                    break;
                }
            }

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
            if (p == -1) p = this.order.Length - 1;

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
