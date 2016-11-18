using System;
using System.Diagnostics;

namespace Problem19
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            for (int y = 1901; y <= 2000; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    if (new DateTime(y, m, 1).DayOfWeek.ToString() == "Sunday")
                    {
                        count++;
                    }
                }
            }

            Debug.WriteLine(count);
        }
    }
}
