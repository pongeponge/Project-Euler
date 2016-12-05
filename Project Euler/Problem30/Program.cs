using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(DigitFifthPowers());
        }

        static Int64 DigitFifthPowers()
        {
            Int64 sum = 0;

            for (int a = 0; a < 10; a++)
            {
                Int64 A = Part(a, 5);
                for (int b = 0; b < 10; b++)
                {
                    Int64 B = Part(b, 4);
                    for (int c = 0; c < 10; c++)
                    {
                        Int64 C = Part(c, 3);
                        for (int d = 0; d < 10; d++)
                        {
                            Int64 D = Part(d, 2);
                            for (int e = 0; e < 10; e++)
                            {
                                Int64 E = Part(e, 1);

                                for (int f = 0; f < 10; f++)
                                {
                                    Int64 F = Part(f, 0);
                                    
                                    if(A+B+C+D+E+F == 0)
                                    {
                                        Int64 n = Number(a, b, c, d, e, f);

                                        if (n != 1)
                                        {
                                            Debug.WriteLine(n);
                                            sum += n;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return sum;
        }

        static Int64 Part(int n, int y)
        {
            return (Int64)(n * (Math.Pow(10, y) - Math.Pow(n, 4)));
        }

        static Int64 Number(params int[] d)
        {
            Int64 n = 0;

            for (int i = 0; i < d.Length; i++)
            {
                n += (Int64)(d[i] * (Math.Pow(10, d.Length - i - 1)));
            }

            return n;
        }
    }
}
