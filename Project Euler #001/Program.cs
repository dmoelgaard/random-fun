using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set the upper limit
            int limit = 1000;

            // Print the sum of all numbers divisible by 3 and 5,
            // not including twin numbers (15, 30, 45, ...)
            Console.WriteLine("Sum of all numbers between 1 and {0} divisible by 3 and 5: {1}", limit,
                                                                                                SumOfDividersFor(3) + SumOfDividersFor(5) - SumOfDividersFor(15));
            // Keep console open until user hits a key.
            Console.ReadLine();
        }

        public static int SumOfDividersFor(int n)
        {
            // Declare variable sum
            int sum = 0;

            // For each iteration of i while i is less than 100,
            // if i divided by n leaves no remainder, add i to sum.
            // Continue loop until i surpasses the limit.
            for (int i = n; i < 1000; i += n)
            {
                if (i % n == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
