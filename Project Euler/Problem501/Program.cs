using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem501
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger edCount = 0;
            BigInteger a = Pow(10, 12);

            for (int i = 1; i < 100; i++)
            {
                BigInteger n = Pow(i, 7);

                if (n >= a)
                {
                    Debug.WriteLine(i);
                    break;
                }
            }



            Debug.WriteLine(Pow(2,7));
        }

        static BigInteger Pow(int x, int y)
        {
            BigInteger num = 1;

            for (int i = 0; i < y; i++)
            {
                num *= x;
            }

            return num;
        }

        /// <summary>
        /// 約数カウンタ
        /// </summary>
        static bool IsEightDivisors(BigInteger n)
        {
            BigInteger ul = n;
            int count = 0;

            for (BigInteger i = 1; i < ul; i++)
            {
                if(n%i == 0)
                {
                    if(n/i == i)
                    {
                        count++;
                    }
                    else
                    {
                        count += 2;
                        ul = n / i;
                    }
                }

                if (count > 8) return false;
            }
            
            if(count < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
