using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Debug.WriteLine(solv(3));
            Debug.WriteLine(solv2());
        }

        static int solv2()
        {
            //11x (9091c + 910d + 100e)
            for(int c = 9; c >= 1; c--)
            {
                for(int d = 9; d >= 0; d--)
                {
                    for(int e = 9; e >= 0; e--)
                    {
                        int p = 100001 * c + 10010 * d + 1100 * e;

                        for(int x = 10; x <= 90; x++)
                        {
                            if(p%(11*x) == 0)
                            {
                                
                                if ((p / (11 * x)).ToString().Length == 3)
                                {
                                    Debug.WriteLine("{0} x {1}", 11 * x, p / (11 * x));
                                    return p;
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        static int solv(int digit)
        {
            int max = DigitMaxValue(digit);
           // int maxp = 0;
            for (int a = max; a >= 100; a--)
            {
                for (int b = a-1; b >= 100; b--)
                {
                    int n = a * b;
                    if (IsPalindromcNumber(n) == true)
                    {

                        return n;
                    }
                }
            }
            return 0;
        }
        
        static int DigitMaxValue(int digit)
        {
            int num = 0;
            for(int i = 0; i < digit; i++)
            {
                num += ((int)Math.Pow(10, i) * 9);
            }

            return num;
        }

        static bool IsPalindromcNumber(int n)
        {
            //n = 900009;
            string str = n.ToString();
            int half = str.Length / 2;

            for (int i = 0; i < half; i++)
            {
                int b = str.Length - i - 1;
                if (str[i] != str[b])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
