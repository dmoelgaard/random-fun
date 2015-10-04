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

        private static int DetermineNumberOfRotations(int[] a, int n)
        {
            int low = 0,
                high = n - 1,
                mid = 0,
                next = 0,
                previous = 0;

            while (low <= high)
            {
                if (a[low] <= a[high])
                {
                    return low;
                }

                mid = (low + high) / 2;
                next = (mid + 1) % n;
                previous = (mid + n - 1) % n;

                if (a[mid] <= a[next] && a[previous] >= a[mid]) 
                {
                    return mid;
                }
                else if (a[mid] <= a[high])
                {
                    high = mid - 1;
                }
                else if (a[mid] >= a[low])
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
