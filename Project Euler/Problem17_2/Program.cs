using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem17_2
{
    class Program
    {
        static Dictionary<int, int> Number = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            Init();

            Debug.WriteLine(Result());
        }

        /// <summary>
        /// 必要な文字を入れておく。1000は別。
        /// </summary>
        static void Init()
        {
            Number[0] = 0;
            Number[1] = 3;// "one";
            Number[2] = 3;// "two";
            Number[3] = 5;// "three";
            Number[4] = 4;// "four";
            Number[5] = 4;// "five";
            Number[6] = 3;// "six";
            Number[7] = 5;// "seven";
            Number[8] = 5;// "eight";
            Number[9] = 4;// "nine";
            Number[10] = 3;// "ten";
            Number[11] = 6;// "eleven";
            Number[12] = 6;// "twelve";
            Number[13] = 8;// "thirteen";
            Number[14] = 8;// "fourteen";
            Number[15] = 7;// "fifteen";
            Number[16] = 7;// "sixteen";
            Number[17] = 9;// "seventeen";
            Number[18] = 8;// "eighteen";
            Number[19] = 8;// "nineteen";
            Number[20] = 6;// "twenty";
            Number[30] = 6;// "thirty";
            Number[40] = 5;// "forty";
            Number[50] = 5;// "fifty";
            Number[60] = 5;// "sixty";
            Number[70] = 7;// "seventy";
            Number[80] = 6;// "eighty";
            Number[90] = 6;// "ninety";
            Number[100] = 7;// "hundred";
        }

        static int Result()
        {
            int sum = 0;

            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        int n = b * 10 + c;

                        if(n <= 20)
                        {
                            sum += Number[n];
                        }
                        else
                        {
                            sum += Number[b * 10] + Number[c];
                        }

                        if(a >= 1)
                        {
                            sum += Number[a] + Number[100];
                        }

                        if(a >= 1 & n != 0)
                        {
                            sum += 3;
                        }
                    }
                }
            }

            return sum + 11;
        }
    }
}
