using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSharpBasic
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/io/
    /// File I/O (Input/Output) and Serialization are essential aspects of C# programming that involve reading from and writing to files, as well as converting objects into a format suitable for storage or transmission.
    /// </summary>
    public static class FileIO
    {
        public static void FileIODemo()
        {
            string directoryPath = @"C:\ExampleDirectory";
            string demoFilePath = Path.Combine(Environment.CurrentDirectory, "FileIO\\FileContent.txt");


            ReadFileDemo(demoFilePath);
            WriteFile(demoFilePath);
            ReadFileDemo(demoFilePath);
        }


        /// <summary>
        /// Read file line 
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadFileDemo(string filePath)
        {
            if (File.Exists(filePath))
            {


                // Read by line 
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }

                }

                // Read all line
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine(String.Join(",", lines));


                // Read text from a file 
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);


                // Read binary file
                byte[] data = File.ReadAllBytes(filePath);

                Console.WriteLine(String.Join(",", data));

                string demoFilePathCopy = Path.Combine(Environment.CurrentDirectory, "FileIO\\FileContentCopy.txt");

                WriteFile(demoFilePathCopy, data);



            }
            else
            {
                Console.WriteLine("File not found");
            }

        }


        public static void WriteFile(string filePath, byte[]? data = null)
        {
            string content = "Shawn is very handsome boizzz!";

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (data == null)
            {
                File.WriteAllText(filePath, content);
            }
            else
            {
                File.WriteAllBytes(filePath, data);
            }

        }



    }
}
