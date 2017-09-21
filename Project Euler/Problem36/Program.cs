using System;
using System.Diagnostics;

namespace Problem36
{
    class Program
    {
        static void Main(string[] args)
        {
            P36 p = new P36();
            Debug.WriteLine(p.Solve());
        }
    }

    class P36
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P36()
        {

        }

        /// <summary>
        /// 解く
        /// </summary>
        public int Solve()
        {
            int sum = 0;

            for (int i = 1; i < 1000000; i+=2)
            {
                if(this.IsDecimalPalindrome(i) == true)
                {
                    if(this.IsBinaryPalindrome(i) == true)
                    {
                        Debug.WriteLine(i+":"+ Convert.ToString(i, 2));
                        sum += i;
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// 10進数の回文か？
        /// </summary>
        /// <param name="n">検査する値</param>
        private bool IsDecimalPalindrome(int n)
        {
            string s = n.ToString();

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) return false;
            }

            return true;
        }


        /// <summary>
        /// 2進数の回文か？
        /// </summary>
        /// <param name="n">検査する値</param>
        private bool IsBinaryPalindrome(int n)
        {
            string s = Convert.ToString(n, 2);

            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) return false;
            }

            return true;
        }
    }
}
