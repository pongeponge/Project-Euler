using System;
using System.Diagnostics;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            while (true)
            {
                Int64 n = i * (i + 1) / 2;

                int count = 0;
                Int64 d = n;

                for (Int64 p = 1; p < d; p++)
                {
                    if (n % p == 0)
                    {
                        d = n / p;
                        count += 2;
                    }
                }

                if (count > 500)
                {
                    Debug.WriteLine(n);
                    break;
                }

                i++;
            }
        }
    }
}
