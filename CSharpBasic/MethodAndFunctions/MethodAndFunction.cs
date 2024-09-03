using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpBasic
{
    /// <summary>
    /// In C#, methods are blocks of code that perform a specific task and can be called from other parts of the program.Methods promote code reuse, readability, and modularization.
    /// </summary>
    public static class MethodAndFunction
    {


        public static void DoMethodAndFunctionDemo()
        {
            int a = 10;
            int b = 20;


            PassByValueDemo(a, b);
            Console.WriteLine($"After change outside PassByValueDemo: a {a}, b {b}");

            PassByReference(ref a, ref b);
            Console.WriteLine($"After change outside PassByReference: a {a}, b {b}");


            Candidate originalCandidate = new Candidate { Id = 1, Name  = "Original Candidate" };
            UpdateCandidateToNewCandidate(originalCandidate);
            Console.WriteLine($"OriginalCan outside UpdateCandidateToNewCandidate {JsonSerializer.Serialize(originalCandidate)}");


            UpdateOriginalCanProperties(originalCandidate);
            Console.WriteLine($"OriginalCan outside UpdateCandidateToNewCandidate {JsonSerializer.Serialize(originalCandidate)}");


        }


        //Method declaration & Parameters 
        public static void PassByValueDemo(int a, int b)
        {
            Console.WriteLine($"Before change inside PassByValueDemo: a {a}, b {b}");

            a = 100; b = 200;

            Console.WriteLine($"After change inside PassByValueDemo: a {a}, b {b}");

        }



        /// Pass-by-reference with Value Type
        public static void PassByReference(ref int a, ref int b)
        {
            Console.WriteLine($"Before change inside PassByReference: a {a}, b {b}");

            a = 100; b = 200;

            Console.WriteLine($"After change inside PassByReference: a {a}, b {b}");
        }



        // 
        public static void UpdateCandidateToNewCandidate(Candidate originalCan)
        {
            originalCan = new Candidate { Id = 1 , Name = "New Candidate"};
            Console.WriteLine($"OriginalCan inside UpdateCandidateToNewCandidate {JsonSerializer.Serialize(originalCan)}");
        }

        public static void UpdateOriginalCanProperties(Candidate originalCan)
        {
            originalCan.Name = "New Name from UpdateOriginalCanProperties";
            Console.WriteLine($"OriginalCan inside UpdateOriginalCanProperties {JsonSerializer.Serialize(originalCan)}");


        }

    }


    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
