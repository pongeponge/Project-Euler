using System.Diagnostics;
using System.Numerics;

namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger f1 = 1;
            BigInteger f2 = 1;
            BigInteger f3 = 0;

            int count = 2;
            while(f3.ToString().Length < 1000)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
                count++;
            }

            Debug.WriteLine("Count:" + count);
            Debug.WriteLine(f3);
        }
    }
}
