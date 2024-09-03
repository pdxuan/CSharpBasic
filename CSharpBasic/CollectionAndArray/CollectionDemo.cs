using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpBasic
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/collections/
    /// </summary>
    public static class CollectionDemo
    {
        /// <summary>
        /// Lists provide dynamic arrays with additional functionality.
        /// Arrays: Fixed size, less flexibility, direct access by index. 
        /// Lists: Dynamic size, more functionality, slower access by index.
        /// </summary>
        public static void DoListDemo()
        {
            // Declaration and Initialization
            List<string> names = new List<string>() { "Shawn", "Handsome", "Boizzz" };


            // Adding and Removing Elements
            names.Add("Very"); // Add an element
            names.Remove("Handsome"); // Remove an element by value
            names.RemoveAt(1); // Remove an element by index

            // Accessing Elements
            string firstElement = names[0];
            Console.WriteLine(firstElement);


            // Iterating Through Lists
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // Linq with a list
            var result = names.Where(n => n.Length > 4).ToList();

        }


        /// <summary>
        /// Dictionaries in C# are collections that store key-value pairs, providing fast access to values based on their associated keys.
        /// </summary>
        public static void DictionaryDemo()
        {
            // Declaration and Initialization
            Dictionary<string, int> ages = new Dictionary<string, int>()
                {
                 {"Alice", 25},
                 {"Bob", 30},
                 {"Charlie", 22}
                };


            // Adding and Accessing Elements
            ages["David"] = 28; // Add a new key-value pair
            int bobAge = ages["Bob"]; // Access the value using the key


            // Iterating Through Dictionaries
            foreach (var pair in ages)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }


            // Checking for Key Existence
            bool hasAlice = ages.ContainsKey("Alice"); // true

        }


        /// <summary>
        /// HashSets in C# are collections that store unique elements without any specific order.
        /// </summary>
        public static void HashsetDemo()
        {
            // Declaration and Initialization
            HashSet<int> uniqueNumbers = new HashSet<int>() { 1, 2, 3, 4, 5 };


            // Adding and Removing Elements
            uniqueNumbers.Add(6); // Add a new element
            uniqueNumbers.Remove(3); // Remove an element

            // Checking for Element Existence
            bool hasThree = uniqueNumbers.Contains(3); // false
            bool hasFive = uniqueNumbers.Contains(5); // true


            // Set Operations
            HashSet<int> otherNumbers = new HashSet<int>() { 4, 5, 6, 7, 8 };
            // Union
            HashSet<int> unionSet = new HashSet<int>(uniqueNumbers);
            unionSet.UnionWith(otherNumbers); // {1, 2, 3, 4, 5, 6, 7, 8}

            // Intersection
            HashSet<int> intersectionSet = new HashSet<int>(uniqueNumbers);
            intersectionSet.IntersectWith(otherNumbers); // {4, 5}


            // Difference
            HashSet<int> differenceSet = new HashSet<int>(uniqueNumbers);
            differenceSet.ExceptWith(otherNumbers); // {1, 2, 3}
        }


    }
}
