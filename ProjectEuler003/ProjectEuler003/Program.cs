using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler003
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("PROJECT EULER PROBLEM #003: LARGEST PRIME FACTOR");
            Console.WriteLine();
            Console.WriteLine("The prime factors of 13195 are 5, 7, 13 and 29.");
            Console.WriteLine("What is the largest prime factor of the number 600851475143?\n\n");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Result: {0}", LargestPrimeFactor(600851475143));
            Console.ReadLine();
        }

        /**
         * Returns highest prime factor of supplied integer value.
         * 
         * @param   n          int      the number to factorize.
         * @return  lastFactor int      the determined highest prime factor of n.
         **/
        private static int LargestPrimeFactor(long n)
        {
            // The currently highest prime factor of n
            int lastFactor = 1;

            // 2 is the only even prime number, by getting it out of the way first,
            // we can increment factor by 2 instead of 1 each iteration.
            if (n % 2 == 0)
            {
                n = n / 2;
                
                // Set 2 as the highest factor, if n is divisible by 2.
                lastFactor = 2;

                // Divide out 2.
                while (n % 2 == 0)
                {
                    n = n / 2;
                }
            }

            // Set factor to 3, as we've already done 2.
            int factor = 3;

            // n becomes 1 when we reach the last prime factor.
            while (n > 1)
            {
                // Determine if n is divisible by next factor
                if (n % factor == 0)
                {
                    // If divisible, divide n by said factor.
                    n = n / factor;

                    // Set highest factor to new factor.
                    lastFactor = factor;

                    // Divide out n with new factor.
                    while (n % factor == 0)
                    {
                        n = n / factor;
                    }
                }

                // Increment by 2, as we only need to test for uneven numbers now.
                factor = factor + 2;
            }

            // Return highest prime factor of n.
            return lastFactor;
        }
    }
}
