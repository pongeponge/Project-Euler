using System;
using System.Diagnostics;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 n = 100;

            Debug.WriteLine(SquareOfSum(n) - SumOfSquare(n));
        }

        //2乗の総和を取る方
        static Int64 SumOfSquare(Int64 n)
        {
            return (n * (n + 1) * (2 * n + 1)) / 6;
        }

        //総和の2乗を取る方
        static Int64 SquareOfSum(Int64 n)
        {
            Int64 t = (n * (n + 1)) / 2;
            return t * t;
        }

        
    }
}
