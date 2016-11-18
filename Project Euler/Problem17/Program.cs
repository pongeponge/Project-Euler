using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem17
{
    class Program
    {
        static Dictionary<int, string> Number = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            Debug.WriteLine(Result());
        }

        /// <summary>
        /// 必要な文字を入れておく。1000は別。
        /// </summary>
        static void Init()
        {
            Number[1] = "one";
            Number[2] = "two";
            Number[3] = "three";
            Number[4] = "four";
            Number[5] = "five";
            Number[6] = "six";
            Number[7] = "seven";
            Number[8] = "eight";
            Number[9] = "nine";
            Number[10] = "ten";
            Number[11] = "eleven";
            Number[12] = "twelve";
            Number[13] = "thirteen";
            Number[14] = "fourteen";
            Number[15] = "fifteen";
            Number[16] = "sixteen";
            Number[17] = "seventeen";
            Number[18] = "eighteen";
            Number[19] = "nineteen";
            Number[20] = "twenty";
            Number[30] = "thirty";
            Number[40] = "forty";
            Number[50] = "fifty";
            Number[60] = "sixty";
            Number[70] = "seventy";
            Number[80] = "eighty";
            Number[90] = "ninety";
            Number[100] = "hundred";
        }

        static int Result()
        {
            Init();

            return LetterCount();
        }

        static int LetterCount()
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                String str = "";
                int n = i;

                if (i >= 100)
                {
                    str += HunderdNumber(i / 100);
                    n = int.Parse(i.ToString().Substring(1));
                }

                str += Under2Digit(n, i);

                sum += str.Length;
            }

            sum += "onethousand".Length;

            return sum;
        }

        /// <summary>
        /// 100の位
        /// </summary>
        static String HunderdNumber(int n)
        {
            return Number[n] + Number[100];
        }

        static String Under2Digit(int n, int i)
        {
            String s = "";

            if (i >= 100 & n != 0) s += "and";

            if (n >= 20)
            {
                int tmp = (n / 10) * 10;

                if (n - tmp != 0) return s + Number[tmp] + Number[n - tmp];
                else return s + Number[tmp];
            }
            else if (n >= 1)
            {
                return s + Number[n];
            }
            else
            {
                return "";
            }
        }
    }
}
