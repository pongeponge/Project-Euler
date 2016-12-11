using System.Diagnostics;

namespace Problem31
{
    class Program
    {
        //使えるコイン(端数が出ても1pで払えるので気にしない)
        static int[] coins = { 2, 5, 10, 20, 50, 100, 200};
        //パターン数
        static int sum = 0;

        static void Main(string[] args)
        {
            reco(200, coins.Length-1);
            Debug.WriteLine(sum);
        }

        //コインの支払いパターンを調べる
        static void reco(int zan, int c)
        {
            //支払いパターン確定
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