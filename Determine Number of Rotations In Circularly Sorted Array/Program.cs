using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetermineNumberOfRotationsSortedArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] a1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] a2 = new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] a3 = new int[] { 9, 10, 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] a4 = new int[] { 8, 9, 10, 1, 2, 3, 4, 5, 6, 7 };
            int[] a5 = new int[] { 7, 8, 9, 10, 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("#1 Rotation count test on array rotated 0 times: {0}", DetermineNumberOfRotations(a1, 10));
            Console.WriteLine("#2 Rotation count test on array rotated 1 time: {0}", DetermineNumberOfRotations(a2, 10));
            Console.WriteLine("#3 Rotation count test on array rotated 2 times: {0}", DetermineNumberOfRotations(a3, 10));
            Console.WriteLine("#4 Rotation count test on array rotated 3 times: {0}", DetermineNumberOfRotations(a4, 10));
            Console.WriteLine("#5 Rotation count test on array rotated 4 times: {0}", DetermineNumberOfRotations(a5, 10));
            Console.ReadLine();

        }

        /// <summary>
        /// Determines the number of rotations a sorted array has gone through. Assumes no duplicates in the array.
        /// </summary>
        /// <param name="a">a: int[] (an array of type integer)</param>
        /// <param name="n">n: int (the size of the array)</param>
        /// <returns>int (the number of circular rotations the array has gone through)</returns>
        private static int DetermineNumberOfRotations(int[] a, int n)
        {
            int low = 0,
                high = n - 1,
                mid = 0,
                next = 0,               // the index of the element to the right of mid
                previous = 0;           // the index of the element to the left of mid

            while (low <= high)
            {
                // case 1: the element at the lowest index is less than the element
                //         at the highest index. This is only possible if the remaining
                //         search space is already sorted, thus the result is the index
                //         of low.
                if (a[low] <= a[high])
                {
                    return low;
                }

                // If case 1 is not true, we calculate the middle index and check
                // if mid is in fact a pivot element (the lowest element is sorrounded
                // by two elements greater than it).
                mid = (low + high) / 2;
                // In case mid is the last index, we use mod to get to the first index.
                next = (mid + 1) % n;
                // To avoid negative numbers, we add and mod n.
                previous = (mid + n - 1) % n;

                // case 2: If the element at mid is sorrounded by two elements greater
                //         than it, we have thus determined the result.
                if (a[mid] <= a[next] && a[previous] >= a[mid]) 
                {
                    return mid;
                }
                // case 3: If the element at mid is less than or equal to the element
                //         at high, the whole segment is sorted, and we must search
                //         for the lowest element in the left side of the search space.
                else if (a[mid] <= a[high])
                {
                    high = mid - 1;
                }
                // case 4: If the element at mid is bigger than or equal to the element
                //         at low, the whole segment is sorted, and we must search
                //         for the lowest element in the right side of the search space.
                else if (a[mid] >= a[low])
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
