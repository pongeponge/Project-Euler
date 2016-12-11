using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem32
{
    class Program
    {
        //使う数字
        int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            Debug.WriteLine(PandigitalProducts());
        }

        static Int64 PandigitalProducts()
        {
            List<int> answers = new List<int>();

            CreateFormula(1, 9, 1234, 9876, answers);
            CreateFormula(12, 98, 123, 987, answers);

            //重複を削除して総和を取る
            return answers.Distinct().Sum();
        }

        //数式の作成
        static void CreateFormula(int amin, int amax, int bmin, int bmax, List<int> ans)
        {
            StringBuilder sb = new StringBuilder();

            for (int a = amin; a <= amax; a++)
            {
                for (int b = bmin; b <= bmax; b++)
                {
                    int c = a * b;

                    if (c.ToString().Length == 4)
                    {
                        sb.Append(a.ToString());
                        sb.Append(b.ToString());
                        sb.Append(c.ToString());

                        if (CheckNumbers(sb.ToString().ToArray()) == true)
                        {
                            Debug.WriteLine(a + "*" + b + "=" + c);
                            ans.Add(c);
                        }
                    }

                    sb.Clear();
                }
            }
        }

        //式のチェック
        static bool CheckNumbers(char[] n)
        {
            Array.Sort(n);

            for (int i = 1; i <= 9; i++)
            {
                if (n[i - 1] - 48 != i) return false;
            }

            return true;
        }
    }
}
