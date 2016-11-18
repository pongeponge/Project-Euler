using System;
using System.Diagnostics;
using System.Numerics;

namespace problem15
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Result1 " + RoutesList(20));
            Debug.WriteLine("Result2 " + PascalTriangle(20));
        }

        /// <summary>
        /// 配列を使う方法
        /// </summary>
        static Int64 RoutesList(int gridNum)
        {
            if (gridNum <= 0) return 0;

            Int64[] routes = new Int64[gridNum];

            //1に初期化
            for (int i = 0; i < gridNum; i++)
            {
                routes[i] = 1;
            }

            //グリッド数だけ経路数計算をくりかえす
            for (int y = 0; y < gridNum; y++)
            {
                routes[0] += 1;
                for (int x = 1; x < gridNum; x++)
                {
                    routes[x] = routes[x - 1] + routes[x];
                }
            }

            return routes[routes.Length - 1];
        }

        /// <summary>
        /// パスカルの三角形から導く方法
        /// </summary>
        static BigInteger PascalTriangle(int gridNum)
        {
            if (gridNum <= 0) return 0;

            BigInteger m = AllProduct(1, gridNum);
            BigInteger c = AllProduct(gridNum + 1, 2 * gridNum);

            return c / m;
        }

        /// <summary>
        /// 総乗を求める
        /// </summary>
        /// <param name="start">開始する数</param>
        /// <param name="end">終了する数</param>
        /// <returns></returns>
        static BigInteger AllProduct(int start, int end)
        {
            BigInteger ap = 1;

            for (BigInteger i = start; i <= end; i++)
            {
                ap *= i;
            }

            return ap;
        }
    }
}
