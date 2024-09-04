using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    /// <summary>
    /// Lambdas and LINQ (Language Integrated Query) are powerful features in C# that enhance code conciseness and facilitate data querying and manipulation.
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
    /// </summary>
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            Console.WriteLine(square(4)); // Output: 16

            // Lambda without return (using Action)
            Action<string> printUpper = (s) => Console.WriteLine(s.ToUpper());
            printUpper("hello world"); // Output: HELLO WORLD

            // Pass lambda as a parameter to another function
            int[] array = new int[4] { 1, 2, 3, 4 };
            Print(x => x > 2, array); // Output: 3, 4
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="nums"></param>
        public static void Print(Func<int, bool> func, int[] nums)
        {
            foreach (var x in nums)
            {
                if (func(x))
                {
                    Console.WriteLine(x);
                }
            }
        }

        /// <summary>
        /// LINQ provides a declarative syntax for querying and manipulating data from various sources, such as collections, databases, XML, and more.
        /// </summary>
        public static void LinqDemo()
        {
            int[] numbers = new int[] { 1, 2, 3, 4 };

            // LINQ query syntax
            var evenNumbers = from number in numbers
                              where number % 2 == 0
                              select number;

            Console.WriteLine("Even Numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num); // Output: 2, 4
            }

            // LINQ method syntax
            var oddNumbers = numbers.Where(x => x % 2 != 0);

            Console.WriteLine("Odd Numbers:");
            foreach (var num in oddNumbers)
            {
                Console.WriteLine(num); // Output: 1, 3
            }

            // LINQ chaining operations
            var squaredAndFiltered = numbers
                .Select(x => x * x)  // Square each number
                .Where(x => x > 10); // Filter numbers greater than 10

            Console.WriteLine("Squared and Filtered Numbers:");
            foreach (var num in squaredAndFiltered)
            {
                Console.WriteLine(num); // Output: 16
            }

            // Joining in LINQ
            var persons = new List<dynamic>
                {
                    new { Id = 1, Name = "Shawn" },
                    new { Id = 2, Name = "Anna" }
                };

            var orders = new List<dynamic>
                {
                    new { ProductId = 1, PersonId = 1, ProductName = "Book" },
                    new { ProductId = 2, PersonId = 2, ProductName = "Laptop" }
                };

            var query = from person in persons
                        join order in orders on person.Id equals order.PersonId
                        select new { person.Name, order.ProductName };

            Console.WriteLine("Person-Product Pairs:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} bought {item.ProductName}");
                // Output: 
                // Shawn bought Book
                // Anna bought Laptop
            }

            // LINQ with lambda expressions
            var products = new List<dynamic>
                {
                    new { Name = "Phone", Price = 500 },
                    new { Name = "Laptop", Price = 1500 },
                    new { Name = "Tablet", Price = 800 }
                };

            var expensiveProducts = products.Where(p => p.Price > 1000);

            Console.WriteLine("Expensive Products:");
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} costs {product.Price}");
                // Output: Laptop costs 1500
            }

            // LINQ to Objects with complex types
            var students = new List<dynamic>
                {
                    new { Name = "John", Grades = new List<int> { 90, 85, 70 } },
                    new { Name = "Jane", Grades = new List<int> { 95, 80, 75 } },
                    new { Name = "Joe", Grades = new List<int> { 60, 70, 80 } }
                };

            var topStudents = students
                .Where(student => student.Grades.Average() > 80)
                .Select(student => new { student.Name, AverageGrade = student.Grades.Average() });

            Console.WriteLine("Top Students:");
            foreach (var student in topStudents)
            {
                Console.WriteLine($"{student.Name} has an average grade of {student.AverageGrade}");
                // Output:
                // John has an average grade of 81.6666666666667
                // Jane has an average grade of 83.3333333333333
            }
        }
    }


}
