using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print2DArrayInSpiralPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize the 2D Array
            int[,] array = new int[,] { { 1, 2, 3, 4 }, 
                                        { 5, 6, 7, 8 },
                                        { 9, 10, 11, 12 },
                                        { 13, 14, 15, 16 } };

            Print2DArray(array, 4, 4);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints a given 2D integer array in spiral form.
        /// </summary>
        /// <param name="a">a: int[ , ] (a 2D array of type integer)</param>
        /// <param name="m">m: int (the number of rows in the given array)</param>
        /// <param name="n">n: int (the number of columns in the given array)</param>
        /// <returns>void</returns>
        private static void Print2DArray(int[,] a, int m, int n)
        {
            int TR = 0;                     // Set the top row as 0.
            int BR = m - 1;                 // Set the bottom row as the number of rows minus 1.
            int LC = 0;                     // Set the left-most column as 0.
            int RC = n - 1;                 // Set the right-most column as the number of columns minus 1.
            int direction = 0;              // 0: Right, 1: Down, 2: Left, 3: Up

            // While the expected right-most column is not in fact the left-most column, AND
            // the top row is in fact not the bottom row
            while (LC <= RC && TR <= BR)
            {
                // If we are moving right
                if (direction == 0)
                {
                    // Print all the elements in the top row of the array.
                    for (int i = LC; i <= RC; ++i) { Console.Write(a[TR, i] + " "); }
                    // Move the top-most row one row down.
                    ++TR;
                }

                // If we are moving down
                else if (direction == 1)
                {
                    // Print all the elements in the right-most column of the array.
                    for (int i = TR; i <= BR; ++i) { Console.Write(a[i, RC] + " "); }
                    // Move the right-most column one column left.
                    --RC;
                }

                // If we are moving left
                else if (direction == 2)
                {
                    // Print all the elements in the bottom row of the array.
                    for (int i = RC; i >= LC; --i) { Console.Write(a[BR, i] + " "); }
                    // Move the bottom row one row up.
                    --BR;
                }

                // If we are moving up
                else if (direction == 3)
                {
                    // Print all the elements in the left-most column of the array.
                    for (int i = BR; i >= TR; --i) { Console.Write(a[i, LC] + " "); }
                    // Move the left-most column one column right
                    ++LC;
                }

                // Change direction, if direction is 4, set it to 0.
                direction = (direction + 1) % 4;
            }
        }
    }
}