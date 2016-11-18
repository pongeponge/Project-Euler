using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(solv1());
            Debug.WriteLine(solv2());
        }

        static int solv1()
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if ((i % 3 == 0) | (i % 5 == 0))
                {
                    sum += i;
                }
            }

            return sum;
        }

        static int solv2()
        {
            return SumM(1000, 3) + SumM(1000, 5) - SumM(1000, 15);
        }

        static int SumM(int MaxValue, int MultipleNumber)
        {
            int n = (MaxValue - 1) / MultipleNumber;

            return MultipleNumber * ((n * (n + 1)) / 2);
        }
    }
}
