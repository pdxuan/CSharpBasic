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


            // Pass like a param for other function
            int[] array = new int[4] { 1, 2, 3, 4 };

            Print((x) => x > 2, array);

        }


        public static void Print(Func<int, bool> func, int[] nums)
        {
            foreach (var x in nums)
            {
                if(func(x))
                {
                    Console.WriteLine(x);
                }
            }

        }




        /// <summary>
        /// LINQ provides a declarative syntax for querying and  manipulating data from various sources, such as collections databases, XML, and more
        /// </summary>
        public static void LinqDemo()
        {

            int[] numbers = [1, 2, 3, 4];

            // LINQ query syntax
            var evenNumbers = from number in numbers
                              where number % 2 == 0
                              select number;

            // Projection in LINQ
            var squaredAndFiltered = numbers
             .Select(x => x * x)
             .Where(x => x > 10);


            // Joining in LINQ
            var persons = new List<dynamic>();
            persons.Add(new { Id = 1, Name = "Shawn" });
            var orders = new List<dynamic>();
            orders.Add(new { ProductId = 1, PersonId = 1, ProductName = "book" });
            var query = from person in persons
                        join order in orders on person.Id equals order.PersonId
                        select new { person.Name, order.ProductName };  


            // LINQ with lambda expressions
            var products = new List<dynamic> { /* ... */ };
            var expensiveProducts = products.Where(p => p.Price > 1000);

        }


    }
}
