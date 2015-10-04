using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberOfOccurrencesBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the the sorted integer array to do binary search on
            int[] a = new int[] { 1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11 };

            Console.WriteLine("#1 Searching for number of occurences of 5. Result: {0}, Expected: 5", NumberOfOccurrences(a, a.Length, 5));
            Console.WriteLine("#2 Searching for number of occurences of 3. Result: {0}, Expected: 2", NumberOfOccurrences(a, a.Length, 3));
            Console.WriteLine("#2 Searching for number of occurences of 9. Result: {0}, Expected: 2", NumberOfOccurrences(a, a.Length, 9));
            Console.WriteLine("#2 Searching for number of occurences of 1. Result: {0}, Expected: 2", NumberOfOccurrences(a, a.Length, 1));
            Console.WriteLine("#2 Searching for number of occurences of 11. Result: {0}, Expected: 1", NumberOfOccurrences(a, a.Length, 11));
            Console.WriteLine("#2 Searching for number of occurences of 10. Result: {0}, Expected: 0", NumberOfOccurrences(a, a.Length, 10));
            Console.ReadLine();
        }

        private static int NumberOfOccurrences(int[] a, int n, int x) 
        {
            int fi = BinarySearch(a, n, x, true);
            return fi == -1 ? 0 : (BinarySearch(a, n, x, false) - BinarySearch(a, n, x, true)) + 1;        
        }

        /**
         * Determines the first or last occurence (not the first found) in a given sorted integer array.
         * 
         * PRE:     a sorted array of type int has been defined. The size of the array n, and the
         *          number to be searched for, x, has been defined
         * POST:    If the number exists, returns the index of the first or last occurrence of x in the array.
         * 
         * @param   a       int[]           a sorted integer array.
         * @param   n       int             the size of the integer array.
         * @param   x       int             the number of the integer value to search for.
         * @param   first   bool            bool stating if we're looking for first or last occurrence
         *                                  first == true, last == false.
         * @return  result  int             index of the first or last occurrence.
         **/
        private static int BinarySearch(int[] a, int n, int x, bool first)
        {
            int low = 0,                    // lower limit of the binary search in terms of index.
                high = n - 1,               // upper limit of the binary search in terms of index.
                mid = 0,                    // middle value of the binary search (where we split) in terms of index.
                result = -1;                // the first or last occurrence of x in a in terms of index.

            // While the search interval has not been exhausted
            while (low <= high)
            {
                // Set mid to the average of the sum of low and high, rounded down.
                mid = (low + high) / 2;

                // if x has been found as the middle element of the array
                if (x == a[mid])
                {
                    // Set result to the index of the element
                    result = mid;

                    if (first)
                    {
                        // Since we're looking for the first occurrence, discard the upper
                        // half of the current search interval.
                        high = mid - 1;
                    }
                    else
                    {
                        // Since we're looking for the last occurrence, discard the lower
                        // half of the current search interval.
                        low = mid + 1;
                    }
                }
                // If the element at mid is bigger than x
                else if (x < a[mid])
                {
                    // Discard the upper half of the current search interval
                    high = mid - 1;
                }
                // If the element at mid is less than x    
                else
                {
                    // Discard the lower half of the search interval
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
