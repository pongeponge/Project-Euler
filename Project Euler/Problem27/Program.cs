using System.Collections.Generic;
using System.Diagnostics;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p = CreatePrimeArray(1000);

            int maxN = 0;
            int maxPd = 0;
            for (int pi = 0; pi < p.Length; pi++)
            {
                int b = p[pi];
                for (int a = 1; a < 1000; a += 2)
                {
                    int tmp = QuadraticFormula(a, b);
                    if (maxN < tmp)
                    {
                        maxN = tmp;
                        maxPd = a * b;
                    }
                    tmp = QuadraticFormula(-a, b);
                    if (maxN < tmp)
                    {
                        maxN = tmp;
                        maxPd = -a * b;
                    }
                }
            }

            Debug.WriteLine(maxPd);
        }

        /// <summary>
        /// 二次式で素数がどれだけ連続するか調べる
        /// </summary>
        static int QuadraticFormula(int a, int b)
        {
            int n = 0;
            int p = 0;

            while (true)
            {
                p = n * n + a * n + b;
                if (IsPrime(p) == true)
                {
                    n++;
                }
                else
                {
                    break;
                }
            }

            return n;
        }

        /// <summary>
        /// エラトステネスの篩による素数列の生成
        /// </summary>
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

            return p.ToArray();
        }

        /// <summary>
        /// 素数判定
        /// </summary>
        static bool IsPrime(int n)
        {
            if (n <= 0) return false;

            int hn = n / 2;

            if (n % 2 == 0) return false;

            for (int i = 3; i <= hn; i += 2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

    }
}
