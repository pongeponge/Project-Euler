using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            //右下の値用
            int dif = 2;
            int dif2 = 8;
            int rd = 3;

            //1週分用
            Int64 add = 2;
            Int64 c = 0;
            Int64 sum = 1;

            for (int width = 3; width <= 1001; width+=2)
            {
                //一週分の値を求める
                c = 4 * rd + 6 * add;
                add += 2;

                sum += c;
                Debug.WriteLine(width + ":" + rd + ":" + c+":"+sum);

                //次の右下の値を求める
                dif += dif2;
                rd += dif;
            }
        }
    }
}
