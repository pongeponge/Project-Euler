using System;
using System.Diagnostics;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Answer : {0}", Result());
        }

        static Int64 Result()
        {
            Int64 n = 1000;

            for (Int64 a = 1; a < n; a++)
            {
                for (Int64 b = a + 1; b < n; b++)
                {
                    if (a * b - n * (a + b) + 0.5 * n * n == 0)
                    {
                        Debug.WriteLine("(a, b, c)=({0}, {1}, {2})", a, b, (n - a - b));
                        return a * b * (n - a - b);
                    }
                }
            }

            return 0;
        }
    }
}
