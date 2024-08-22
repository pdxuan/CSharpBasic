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




        /// <summary>
        /// How to use delegate in real senariors
        /// Different beetween Delegate, Action  and Func 
        /// </summary>
        public static void DelegateDemo()
        {



        }
    }
}



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
