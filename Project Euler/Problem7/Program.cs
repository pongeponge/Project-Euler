using System;
using System.Diagnostics;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 n = 10001;

            Debug.WriteLine(Prime(n));
        }

        static Int64 Prime(Int64 n)
        {
            Int64[] primeList = new Int64[n];
            primeList[0] = 2;

            Int64 num = 3;

            int count = 1;
            while (primeList[primeList.Length - 1] == 0)
            {
                if (IsPrime(num, primeList) == true)
                {
                    primeList[count] = num;
                    count++;
                }
                num += 2;
            }

            return primeList[n - 1];
        }


        //素数判定
        static bool IsPrime(Int64 n, Int64[] pl)
        {
            Int64 sqrtNum = (Int64)Math.Sqrt(n);

            for (int i = 0; pl[i] != 0; i++)
            {
                if ((n % pl[i] == 0) & (pl[i] <= sqrtNum))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
