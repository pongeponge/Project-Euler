using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem33
{
    class Program
    {
        static void Main(string[] args)
        {
            p33 p = new p33();
            Debug.WriteLine(p.CheckMAndC().mother);           
        }
    }

    class p33
    {
        //桁を削った分数
        private Fraction fra;

        //分子と分母を決定する
        public Fraction CheckMAndC()
        {
            //一時保存用
            Fraction num;
            //全部掛けたやつ
            Fraction mul = new Fraction(1,1);

            for (int m = 11; m < 99; m++)
            {
                for (int c = 11; c < m; c++)
                {
                    num = new Fraction(m, c);

                    if (CheckFraction(num) == true)
                    {
                        if (CalcFractions(num) == true)
                        {
                            Debug.WriteLine("{0}/{1}", c, m);
                            mul *= num;
                        }
                    }
                }
            }
            return mul.Reduce();
        }

        /// <summary>
        /// 分数の値チェック
        /// </summary>
        bool CheckFraction(Fraction num)
        {
            //片方か両方が10の倍数だとダメ
            if (IsMultiples10(num.mother) == true || IsMultiples10(num.child) == true) return false;
            //分子と分母に同じ数字が含まれていないとダメ
            if (IsIncludeSameValue(num) == false) return false;

            return true;
        }

        /// <summary>
        /// 10の倍数か？
        /// </summary>
        /// <param name="num">検査する値</param>
        bool IsMultiples10(int num)
        {
            if (num % 10 == 0) return true;

            return false;
        }

        /// <summary>
        /// 2つの値に同じ数字が含まれているか？
        /// </summary>
        bool IsIncludeSameValue(Fraction num)
        {
            string ms = num.mother.ToString();
            string cs = num.child.ToString();

            for (int mi = 0; mi < ms.Length; mi++)
            {
                for (int ci = 0; ci < cs.Length; ci++)
                {
                    if (ms[mi] == cs[ci])
                    {
                        this.fra = new Fraction(int.Parse(ms[-mi + 1].ToString()), int.Parse(cs[-ci + 1].ToString()));
                        if (fra.child > fra.mother) return false;

                        return true;
                    }
                }
            }

            return false;
        }

        //問題文に合うか計算
        bool CalcFractions(Fraction num)
        {
            this.fra = num * this.fra.Reciprocal();
            if (this.fra.child == this.fra.mother) return true;
            return false;

        }
    }

    //分数表現クラス
    class Fraction
    {
        public int child;
        public int mother;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Fraction(int m, int c)
        {
            this.child = c;
            this.mother = m;
        }

        /// <summary>
        /// 逆数を返す
        /// </summary>
        public Fraction Reciprocal()
        {
            return new Fraction(this.child, this.mother);
        }

        /// <summary>
        /// 約分を返す
        /// </summary>
        public Fraction Reduce()
        {
            int g = this.gcd();
            return new Fraction(this.mother / g, this.child / g);
        }

        /// <summary>
        /// 最大公約数
        /// </summary>
        private int gcd()
        {
            int m = this.mother;
            int n = this.child;
            while (true)
            {
                m = m % n;
                if (m == 0)
                    return n;
                n = n % m;
                if (n == 0)
                    return m;
            }
        }

        /// <summary>
        /// オペレータ：掛け算
        /// </summary>
        public static Fraction operator *(Fraction n, Fraction m)
        {
            return new Fraction(n.mother * m.mother, n.child * m.child);
        }
    }
}