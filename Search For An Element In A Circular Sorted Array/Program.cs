using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchElementInCircularySortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 10, 11, 13, 15, 17, 31, 1, 3, 5, 6, 8, 9 };
            Console.WriteLine("Searching for element 10 in the array:\tResult: {0}\tExpected:  0", CircularBinarySearch(a, a.Length, 10));
            Console.WriteLine("Searching for element  9 in the array:\tResult: {0}\tExpected: 11", CircularBinarySearch(a, a.Length, 9));
            Console.WriteLine("Searching for element 31 in the array:\tResult: {0}\tExpected:  5", CircularBinarySearch(a, a.Length, 31));
            Console.WriteLine("Searching for element  1 in the array:\tResult: {0}\tExpected:  6", CircularBinarySearch(a, a.Length, 1));
            Console.WriteLine("Searching for element  3 in the array:\tResult: {0}\tExpected:  7", CircularBinarySearch(a, a.Length, 3));
            Console.WriteLine("Searching for element 17 in the array:\tResult: {0}\tExpected:  4", CircularBinarySearch(a, a.Length, 17));
            Console.ReadLine();
        }

        /// <summary>
        /// Searches a circulary sorted integer array for a given element.
        /// </summary>
        /// <param name="a">a: int[] (an array of circulary sorted integer elements)</param>
        /// <param name="n">n: int (the size of the array)</param>
        /// <param name="x">x: int (the element to be searched for)</param>
        /// <returns>the index of the element</returns>
        private static int CircularBinarySearch(int[] a, int n, int x)
        {
            int low = 0;
            int high = n - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                // Case 1: we found the element x at the middle index
                if (x == a[mid])
                {
                    return mid;
                }

                // Case 2: If x is not found, and the right half of the search space is sorted
                if (a[mid] <= a[high])
                {
                    // Case 2A: If the right half of the search space is sorted, and x is within
                    //          the interval of mid and high, we continue searching on the right
                    //          side. If not, we search in the left side.
                    if (x > a[mid] && a[high] >= x)
                    {
                        low = mid + 1;
                    }
                    // Case 2B: x is not in the interval of the search space, thus we search in
                    //          the left side.
                    else
                    {
                        high = mid - 1;
                    }
                }
                // Case 3: If x is not found, and the right half of the search space is not sorted,
                //         then it stands to reason that the left side will be sorted.
                else // a[low] <= a[mid]. If the right side is not sorted, then the left will be.
                {
                    // Case 3A: If the left half of the search space is sorted, and x is within
                    //          the interval of mid and low, we continue searching on the left side.
                    //          If not, we search on the right side.
                    if (a[low] <= x && x < a[mid])
                    {
                        high = mid - 1;
                    }

                    else
                    {
                        low = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}
