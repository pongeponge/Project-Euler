using System;
using System.Diagnostics;
using System.Text;

namespace Problem38
{
    class Program
    {
        static void Main(string[] args)
        {
            P38 p = new P38();
            Debug.WriteLine(p.Solve());
        }
    }

    class P38
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P38()
        {

        }

        /// <summary>
        /// 解く
        /// </summary>
        public Int64 Solve()
        {
            Int64 maxNum = 0;

            for (int n = 2; n <= 9; n++)
            {
                //(1,2)の場合4-5桁必要、という感じで必要桁を求める
                int nd = 9 / n;
                int max = (int)Math.Pow(10, nd);
                int min = (int)Math.Pow(10, nd - 1);

                StringBuilder sb = new StringBuilder();

                for (int i = min; i < max; i++)
                {
                    sb.Clear();

                    //Concatenated product of i and (1, 2, ... , m) を求める
                    for (int m = 1; m <= n; m++)
                    {
                        sb.Append(i * m);
                    }

                    //値がパンデジタル数になってるかのチェックと比較
                    if(IsPandigital(sb.ToString()) == true)
                    {
                        Int64 pNum = Int64.Parse(sb.ToString());

                        if (maxNum < pNum)
                        { 
                            maxNum = pNum;
                            Debug.WriteLine("基数" + i + ",倍数" + n + "連結積" + maxNum);
                        }
                    }
                }
            }

            return maxNum;
        }


        /// <summary>
        /// パンデジタル数か？
        /// </summary>
        /// <param name="str">検査する文字列</param>
        private bool IsPandigital(string str)
        {
            //9桁でなければfalse
            if (str.Length != 9) return false;

            int[] numbers = new int[9];

            for (int i = 0; i < str.Length; i++)
            {
                int j = str[i] - '0' - 1;

                //-1だとfalse
                if (j == -1) return false;

                numbers[j]++;

                //字数カウンタが1より多いとfalse;
                if (numbers[j] > 1) return false;
            }

            return true;          
        }
        
    }
}
