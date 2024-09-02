using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public static class OtherConceptsDemo
    {
        /// <summary>
        /// tuple is a data structure that holds a fixed number of elements, which can be of different types. 
        /// </summary>
        public static void TupleDemo()
        {
            // Creating a tuple with different data types
            var person = Tuple.Create("John", "Doe", 30);

            // Accessing tuple elements
            string firstName = person.Item1;
            string lastName = person.Item2;
            int age = person.Item3;

            Console.WriteLine($"Name: {firstName} {lastName}, Age: {age}");

            // Deconstructing a tuple
            var (name, surname, ageDestruct) = person;
            Console.WriteLine($"Name: {name} {surname}, Age: {ageDestruct}");
        }



        /// <summary>
        /// We ensure thread safety by allowing only one thread to update the shared variable at a time, thus avoiding race conditions and ensuring accurate results.
        /// </summary>
        public static void LockKeywordDemo()
        {

            // Create a bank account with an initial balance
            BankAccount account = new BankAccount(100);

            // Create two threads that will deposit money into the account
            Thread thread1 = new Thread(() => account.Deposit(50, "Thread 1"));
            Thread thread2 = new Thread(() => account.Deposit(30, "Thread 2"));

            // Start the threads
            thread1.Start();
            thread2.Start();

            // Wait for both threads to finish
            thread1.Join();
            thread2.Join();

            // Display the final balance
            Console.WriteLine($"Final Balance: {account.GetBalance()}");

        }





        public static void LockKeywordDemo2()
        {
            string temp = "test";

            object temp1 = temp;


            string temp2 = (string)temp1;

            dynamic temp3 = temp1;
        }


        public static void OperatorOverloadingDemo()
        {
            var set1 = new CustomSet<int>(new[] { 1, 2, 3, 4 });
            var set2 = new CustomSet<int>(new[] { 3, 4, 5, 6 });

            var unionSet = set1 + set2; // Union of set1 and set2
            var differenceSet = set1 - set2; // Difference of set1 and set2

            Console.WriteLine("Union: " + unionSet); // Output: {1, 2, 3, 4, 5, 6}
            Console.WriteLine("Difference: " + differenceSet); // Output: {1, 2}
        }





        
    }
}




/// <summary>
/// For Operator Overloading demo 
/// </summary>
/// <typeparam name="T"></typeparam>
public class CustomSet<T>
{
    private readonly HashSet<T> _elements;

    public CustomSet(IEnumerable<T> elements)
    {
        _elements = new HashSet<T>(elements);
    }

    // Overload the + operator for union of two sets
    public static CustomSet<T> operator +(CustomSet<T> set1, CustomSet<T> set2)
    {
        return new CustomSet<T>(set1._elements.Union(set2._elements));
    }

    // Overload the - operator for difference of two sets
    public static CustomSet<T> operator -(CustomSet<T> set1, CustomSet<T> set2)
    {
        return new CustomSet<T>(set1._elements.Except(set2._elements));
    }

    public override string ToString()
    {
        return "{" + string.Join(", ", _elements) + "}";
    }
}





/// <summary>
/// For lock demo 
/// </summary>
public class BankAccount
{
    private decimal balance;
    private readonly object balanceLock = new object();

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount, string threadName)
    {
        Console.WriteLine($"{threadName} is attempting to deposit {amount}");

        // Lock the balance object to ensure exclusive access
        lock (balanceLock)
        {
            Console.WriteLine($"{threadName} has locked the balance");

            // Simulate some work with Thread.Sleep
            Thread.Sleep(1000);

            balance += amount;

            Console.WriteLine($"{threadName} has deposited {amount}. New Balance: {balance}");
        }

        Console.WriteLine($"{threadName} has released the lock");
    }

    public decimal GetBalance()
    {
        return balance;
    }
}
