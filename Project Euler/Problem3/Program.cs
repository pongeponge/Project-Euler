using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(solv(600851475143));
        }

        static double solv(double n)
        {
            //因数分解の場合ルートn以下の素数で十分なので
            double rn = (double)(int)Math.Sqrt(n);

            //ルートn以下の素数を取得
            List<int> pl = CreatePrimeList((int)rn);

            //nを割れる最も大きい素数を調べる
            int max = 0;
            for(int i = pl.Count-1; i >= 0; i--)
            {
                if (n % pl[i] == 0)
                {
                    max = pl[i];
                    break;
                }
            }

            return max;
        }

        //素数リストの生成
        static List<int> CreatePrimeList(int max)
        {
            List<int> pl = new List<int>();

            pl.Add(2);

            for (int i = 3; i <= max; i+=2)
            {
                if (isPrime(i, pl))
                {
                    pl.Add(i);
                }
            }

            return pl;
        }

        //素数判定
        static bool isPrime(int n, List<int> pl)
        {
            foreach(int p in pl)
            {
                if (n % p == 0) return false;
            }

            return true;
        }
    }
}
