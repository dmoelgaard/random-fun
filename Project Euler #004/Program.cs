using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler004
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROJECT EULER PROBLEM #004: LARGEST PALINDROME PRODUCT OF TWO 3-DIGIT NUMBERS");
            Console.WriteLine();
            Console.WriteLine("A palindromic number reads the same both ways. \nThe largest palindrome made from the product of two 2-digit numbers is \n\n9009 = 91 × 99.");
            Console.WriteLine("\n\nFind the largest palindrome made from the product of two 3-digit numbers.\n\n");
            DeterminePalindrome();
            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Determines the largest palindrome product of two 3-digit numbers.
        /// </summary>
        private static void DeterminePalindrome()
        {
            bool found = false;                 // Search condition
            int firstHalf = 998;                // Starting at 998 as the largest possible palindrome is 998001
            int palin = 0;                      // The completed palindrome (first half + reversed first half)
            int[] factors = new int[2];         // Contains the two three digit factors

            while (!found)
            {
                // Decrement the first half of the palindrome, so that we'll get the
                // next possible palindrome before proceeding.
                firstHalf--;

                // Generate the next possible palindrome
                palin = CreatePalindrome(firstHalf);

                // Determine the three digit factors
                for (int i = 999; i > 99; i--)
                {
                    // If the palindrome divided by i (j) is bigger than 999, we violate the terms of the problem,
                    // seeing as j is a factor and consists of more than three digits.
                    // Likewise, if i squared is less than the palindrome, it's in violation as j needs to be lower
                    // than i.
                    if ((palin / i) > 999 || i * i < palin)
                    {
                        break;
                    }

                    // If i is a factor of the palindrome, end the search
                    if ((palin % i == 0))
                    {
                        found = true;
                        // Assign j to the factor array
                        factors[0] = palin / i;
                        // Assign i to the factor array
                        factors[1] = i;
                        break;
                    }
                }
            }

            Console.WriteLine("Palindrome: {0}\nFactors: {1} * {2}", palin, factors[0], factors[1]);
        }

        /// <summary>
        /// Uses string manipulation to generate the palindromes. Takes the first half,
        /// reverses it and concatinates it on the right side of the first half.
        /// </summary>
        /// <param name="firstHalf">firstHalf: int (the first half of the palindrome)</param>
        /// <returns>a completed palindrome</returns>
        private static int CreatePalindrome(int firstHalf)
        {
            char[] secondHalf = firstHalf.ToString().Reverse().ToArray();
            return Convert.ToInt32(firstHalf + new string(secondHalf));
        }
    }
}
