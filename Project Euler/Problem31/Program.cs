using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem31
{
    class Program
    {
        static int[] coins = { 2, 5, 10, 20, 50, 100, 200};
        static int sum = 0;

        static void Main(string[] args)
        {
            reco(200, coins.Length-1);
            Debug.WriteLine(sum);
        }

        static Int64 CoinSums()
        {
            return 0;
        }

        static void reco(int zan, int c)
        {
            if (c < 0)
            {
                sum++;
                return;
            }

            int n = zan / coins[c];

            for (int i = 0; i <= n; i++)
            {
                reco(zan - i * coins[c], c - 1);
            }
        }
    }
}