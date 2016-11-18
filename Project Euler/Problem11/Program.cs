using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Problem11
{
    class Program
    {
        private static int width = 20;
        private static int height = 20;
        private static int[,] data;

        static void Main(string[] args)
        {
            ReadData();

            Debug.WriteLine(SearchMaxProductNumber());
        }

        /// <summary>
        /// グリッドデータを読み込む
        /// </summary>
        static void ReadData()
        {
            String path = @"..\..\data.txt";
            String[] strs = File.ReadAllText(path).Replace("\r\n", " ").Split(' ');

            data = new int[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    data[x, y] = int.Parse(strs[y * width + x]);
                }
            }
        }

        /// <summary>
        /// 最大の総乗数を探す
        /// </summary>
        /// <returns>最大の総乗数</returns>
        static Int64 SearchMaxProductNumber()
        {
            Int64[] maxs = new Int64[4];

            maxs[0] = SearchVertical();
            maxs[1] = SearchHorizontal();
            maxs[2] = SearchDiagonallyRightUp();
            maxs[3] = SearchDiagonallyRightDown();

            return maxs.Max();
        }

        /// <summary>
        /// 縦方向の最大の総乗数を探す
        /// </summary>
        /// <returns>最大の総乗数</returns>
        static Int64 SearchVertical()
        {
            Int64 max = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height - 3; y++)
                {
                    Int64 tmp = data[x, y] * data[x, y + 1] * data[x, y + 2] * data[x, y + 3];

                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// 横方向の最大の総乗数を探す
        /// </summary>
        /// <returns>最大の総乗数</returns>
        static Int64 SearchHorizontal()
        {
            Int64 max = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width - 3; x++)
                {
                    Int64 tmp = data[x, y] * data[x + 1, y] * data[x + 2, y] * data[x + 3, y];

                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// 右上がり斜めで最大の総乗数を探す
        /// </summary>
        /// <returns>最大の総乗数</returns>
        static Int64 SearchDiagonallyRightUp()
        {
            Int64 max = 0;

            for (int y = 3; y < height; y++)
            {
                for (int x = 0; x < width - 3; x++)
                {
                    Int64 tmp = data[x, y] * data[x + 1, y - 1] * data[x + 2, y - 2] * data[x + 3, y - 3];

                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// 右下がり斜めで最大の総乗数を探す
        /// </summary>
        /// <returns></returns>
        static Int64 SearchDiagonallyRightDown()
        {
            Int64 max = 0;

            for (int y = 0; y < height - 3; y++)
            {
                for (int x = 0; x < width - 3; x++)
                {
                    Int64 tmp = data[x, y] * data[x + 1, y + 1] * data[x + 2, y + 2] * data[x + 3, y + 3];

                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }

            return max;
        }
    }
}
