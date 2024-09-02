using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace CSharpBasic
{
    /// <summary>
    /// Array is reference type, so array need initialization before using. 
    /// Arrays in C# are fixed-size collections of elements of the same data type.
    /// </summary>
    internal static class ArrayDemo
    {
        public static void ArrayUsesesDemo()
        {

            // Declaration and Initialization
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.Length);


            // Accessing Elements
            int firstElement = numbers[0]; // Accessing the first element (index 0)

            // Iterating Through Arrays
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // Multidimensional Arrays 2, 3 ...
            int[,] matrix = new int[3, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };


            // jagged array
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = [1, 3, 5, 7, 9];
            jaggedArray[1] = [0, 2, 4, 6];
            jaggedArray[2] = [11, 22];


        }


    }
}
