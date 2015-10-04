﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingFirstAndLastOccurrenceBinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the the sorted integer array to do binary search on
            int[] a = new int[] { 1, 2, 4, 5, 5, 5, 6, 7, 8, 9, 10, 10, 10, 10, 12, 13, 14 };

            Console.WriteLine("#1 Searching for first occurence of 5. Result: {0}, Expected: 3", BinarySearch(a, a.Length, 5, true));
            Console.WriteLine("#2 Searching for last occurence of 10. Result: {0}, Expected: 13", BinarySearch(a, a.Length, 10, false));
            Console.ReadLine();
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
