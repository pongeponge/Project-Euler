using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(EF1(4000000));
            Debug.WriteLine(EF2(4000000));
        }

        static int EF1(int max)
        {
            int f1, f2;
            int sum = 0;

            f1 = 1;
            f2 = 1;
            while(true)
            {
                int f3 = f1 + f2;

                if (f3 >= max) break;

                if (f3 % 2 == 0) sum += f3;

                f1 = f2;
                f2 = f3;

                Debug.WriteLine(f3);
            }

            return sum;
        }

        static int EF2(int max)
        {
            int sum = 0;

            int f2 = 2;
            int f1 = 0;

            sum += f2;

            while (true)
            {
                int fnext = f2 * 4 + f1;

                if (fnext > max) break;

                sum += fnext;

                f1 = f2;
                f2 = fnext;

                Debug.WriteLine(f2);
            }

            return sum;
        }
    }
}
