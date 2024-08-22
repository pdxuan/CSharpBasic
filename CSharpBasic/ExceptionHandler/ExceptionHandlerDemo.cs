using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public class ExceptionHandlerDemo
    {

        public static void DoExceptionDemo()
        {
            ProcessData();
        }




        public static void ProcessData()
        {
            try
            {
                // Some code that might throw an exception
                throw new InvalidOperationException("An error occurred.");
            }
            catch (Exception ex)
            {
                // Log the exception or perform some action
                Console.WriteLine("Logging exception: " + ex.Message);

                // Re-throw the original exception
                throw; // This preserves the original stack trace
            }
        }


    }
}
