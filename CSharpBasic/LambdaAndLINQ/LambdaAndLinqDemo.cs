using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    /// <summary>
    /// Lambdas and LINQ (Language Integrated Query) are powerful features in C# that enhance code conciseness and facilitate data querying and manipulation.
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
    /// </summary>
    public static class LambdaAndLinqDemo
    {
        /// <summary>
        /// Lambdas are concise, anonymous functions that allow you to write inline code for short-lived operations, especially useful for delegate types.
        /// </summary>
        public static void LambdasDemo()
        {
            // Lambda expression syntax
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(3, 5)); // Output: 8


            // Lambda with statements
            Func<int, int> square = x =>
            {
                int result = x * x;
                return result;
            };


            // Like function without return 
            Action<string> upper = (s) => s.ToUpper();


            Console.WriteLine(square(4)); // Output: 16

        }


        public static void LinqDemo()
        {



        }


    }
}
