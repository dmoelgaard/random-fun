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
            Console.WriteLine("PROJECT EULER PROBLEM #001: MULTIPLES OF 3 AND 5");
            Console.WriteLine();
            Console.WriteLine("If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. \nThe sum of these multiples is 23.\n\n");
            Console.WriteLine("Find the sum of all the multiples of 3 or 5 below 1000.\n\n");
            Console.WriteLine("Result: {0}", SumOfMultiples());
            Console.ReadLine();
        }

        /// <summary>
        /// Returns the sum of all numbers below 1000 divisible by 3 or 5.
        /// </summary>
        /// <returns>the sum of all numbers of which 3 or 5 is a factor.</returns>
        public static int SumOfMultiples()
        {
            return Enumerable.Range(1, 999).Where(x => (x % 5 == 0 || 0 == x % 3)).Sum();
        }
    }
}
