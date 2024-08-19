using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInt = System.Int32;

namespace CSharpBasic
{
    public static class DataTypeDemo
    {

        #region  Data types & CSharp type system

        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/
        /// Data types and Variables sample code 
        /// Variables are used to store data in a program. In C#, you declare a variable by specifying its data type and a name.
        /// </summary>
        public static void DataTypesDemo()
        {

            // Interger type 
            int age = 25;
            Console.WriteLine($"Age: {age}");

            // Floating-point numeric type: float 4 bytes, double 8 bytes, decimal 16 bytes
            float price = 19.99f;  // Notice the 'f' suffix for float
            double pi = 3.14159;
            decimal totalCost = 199.99m; // Notice the 'm' suffix for decimal
            Console.WriteLine($"Price: {price}, Pi: {pi}, Total Cost: {totalCost}");

            // Character type
            char grade = 'A';
            Console.WriteLine($"Grade: {grade}");

            // Boolean type
            bool isPassed = true;
            Console.WriteLine($"Passed: {isPassed}");

            // String type
            string name = "John Doe";
            Console.WriteLine($"Name: {name}");



            //Constants: variables whose values cannot be changed once assigned
            const double gravity = 9.81;
            //gravity = 10; Compiler error 
            Console.WriteLine($"Gravity: {gravity}");


        }



        /// <summary>
        /// Demo CSharp type system and data types
        /// </summary>
        public static void DoTypeSystemDemo()
        {

            // Value Types vs. Reference Types



            // Conversion between Data types: Implicit conversion is done automatically, while explicit conversion requires the use of casting.
            // Implicit: No data loss occurs, Compatibility
            // Explicit: Potential for data loss, Incompatibility
            int numInt = 10;
            double numDouble = numInt; // Implicit conversion
            Console.WriteLine(numDouble);

            double pi = 3.14159;
            int intPi = (int)pi; // Explicitly converting double to int
            Console.WriteLine(intPi); // Output will be 3, the fractional part is truncated


            // Nullables types: value types cannot be assigned a value of null -> nullable types help explicitly allow a value type to be null
            int? nullableInt = null;
            nullableInt = 5;
            Console.WriteLine($"Nullable Integer: {nullableInt.HasValue}");


            // Type inference(var and dynamic)
            // var Keyword (Compile-time Type Inference): The var keyword allows the compiler to infer the type of a variable based on the assigned value.
            // dynamic Keyword (Runtime Type Resolution): The dynamic type delays the determination of the type until runtime, allowing for dynamic typing.
            var inferredString = "Type Inference";
            dynamic dynamicValue = 42;
            Console.WriteLine($"Inferred Integer: {dynamicValue.GetType()}, Inferred String: {inferredString.GetType()}");


            // Generics in the Type System: Generics introduce a way to create flexible and reusable code that operates on various data types.
            List<int> numbers = new List<int>();


            // Boxing involves converting a value type to a reference type, and unboxing is the reverse operation
            int valueType = 10;
            object boxed = valueType; // Boxing
            int unboxed = (int)boxed; // Unboxing
            Console.WriteLine($"Boxed Value: {boxed}, Unboxed Value: {unboxed}");


            // Type Aliases (using Directive): Type aliases allow creating shorter names for types, improving code readability.
            MyInt myValue = 42;
            Console.WriteLine($"Aliased Value: {myValue}");

        }


        #endregion

    }
}
