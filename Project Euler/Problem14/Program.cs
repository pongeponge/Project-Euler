using System;
using System.Diagnostics;

namespace Problem14
{
    class Program
    {
        static Int64 num = 1000000;
        static Int64[] chainNum = new Int64[num + 1];

        static void Main(string[] args)
        {
            Debug.WriteLine(LongestChainNumber());
        }

        /// <summary>
        /// 最長チェインの数を調べる
        /// </summary>
        static Int64 LongestChainNumber()
        {
            Int64 chainNum = 0;
            Int64 maxNum = 0;

            for (Int64 n = num - 1; n >= 2; n--)
            {
                Int64 tmp = CountChain(n);

                if (chainNum < tmp)
                {
                    chainNum = tmp;
                    maxNum = n;
                }
            }

            return maxNum;

        }

        /// <summary>
        /// チェインのカウントとチェイン箱の更新
        /// </summary>
        static Int64 CountChain(Int64 n)
        {
            Int64 count = 1;

            while (n != 1)
            {
                if (n <= num)
                {
                    if (chainNum[n] > count)
                    {
                        return 0;
                    }
                    chainNum[n] = count;
                }

                n = NextCollatzNumber(n);

                count++;
            }

            chainNum[n] = count;

            return count + 1;
        }

        /// <summary>
        /// 次のコラッツ数
        /// </summary>
        static Int64 NextCollatzNumber(Int64 n)
        {
            if (n % 2 == 0)
            {
                return n / 2;
            }
            else
            {
                return 3 * n + 1;
            }
        }
    }
}
