using System;
using System.Diagnostics;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 e = 2;
            for(int i = 3; i <= 20; i++)
            {
                Int64 p = EA(e, i);
                e = (e * i) / p;
            }
            Debug.WriteLine(e);

        }

        //ユークリッド互除法
        static Int64 EA(Int64 a, Int64 b)
        {
            while((a != 0) & (b != 0))
            {
                if (a >= b) a = a % b;
                else b = b % a;
            }

            return (a != 0) ? a : b;
        }
    }
}
