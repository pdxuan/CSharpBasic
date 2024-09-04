using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    /// <summary>
    /// The static keyword in C# is a powerful concept used to define members (fields, methods, constructors) and 
    /// classes that are associated with the type itself rather than any instance of the type.
    /// </summary>
    public class StaticKeyword
    {
        public void StaticKeywordDemo()
        {
            Singleton.Instance.DisplayMessage();

            object extentionDemo = new object();
            extentionDemo.Log("ExtentionDemoLog works");

        }

    }


    public class Singleton
    {
        // Hold an instance of the class
        private static Singleton instance;

        private static object instanceLock = new object();

        // Private constructor ensures that the class cannot be instantiated from outside
        private Singleton() { }

        // Provide a global point to access the instance
        public static Singleton Instance
        {
            get
            {
                lock (instanceLock)
                {
                    // If the instance is null, create a new one
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }

        // Example method to demonstrate its usage
        public void DisplayMessage()
        {
            Console.WriteLine("Singleton Instance");
        }
    }




    /// <summary>
    /// Common usecses in real world project. It help us to split logic outside the business classes.
    /// First parameter should add this prefix after Type of it 
    /// </summary>
    public static class ExtensionMethodDemo
    {

        public static void Log(this object temp, string message)
        {
            Console.WriteLine(message);
        }
    }


}
