using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("RC1:" + ReciprocalCycles(1000));
        }

        static int[] CreatePrimeArray(int max)
        {
            List<int> p = new List<int>();

            for (int i = 0; i <= max; i++)
            {
                p.Add(i);
            }

            for (int i = 2; i <= max / 2; i++)
            {
                if (p[i] != 0)
                {
                    for (int j = 2; p[i] * j <= max; j++)
                    {
                        p[i * j] = 0;
                    }
                }
            }

            p.RemoveAll(obj => obj == 0);

            //1,2,5は巡回小数にならないので最初に削除しておく
            p.RemoveAt(3);
            p.RemoveAt(1);
            p.RemoveAt(0);

            return p.ToArray();
        }

        static int ReciprocalCycles(int max)
        {
            int[] primes = CreatePrimeArray(max);

            int l = 0;
            int n = 0;

            for (int i = primes.Length-1; i >= 0; i--)
            {
                for (int d = primes[i].ToString().Length; ; d++)
                {
                    if (Pow(d) % primes[i] == 1)
                    {
                        if (l < d)
                        {
                            l = d;
                            n = primes[i];
                        }
                        break;
                    }
                }

                if (primes[i] - 1 < l) break;
            }

            return n;
        }

        static BigInteger Pow(int y)
        {
            BigInteger p = 1;

            for (int i = 0; i < y; i++)
            {
                p *= 10;
            }

            return p;
        }
    }
}
