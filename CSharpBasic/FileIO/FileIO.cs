using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/io/
    /// File I/O (Input/Output) and Serialization are essential aspects of C# programming that involve reading from and writing to files, as well as converting objects into a format suitable for storage or transmission.
    /// </summary>
    public static class FileIO
    {
        public static void DirectoryDemo()
        {
            string directoryPath = @"C:\ExampleDirectory";

            // Create new directory if not exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directory created at {directoryPath}");
            }
            else
            {
                Console.WriteLine($"Directory already exists at {directoryPath}");
            }

            // List files inside the directory
            string[] files = Directory.GetFiles(directoryPath);
            Console.WriteLine($"Files in {directoryPath}:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }

            // Delete directory
            Console.WriteLine("Deleting the directory...");
            Directory.Delete(directoryPath, true);
            Console.WriteLine($"Directory deleted at {directoryPath}");
        }



        public static void FileDemo()
        {
            string filePath = @"C:\ExampleDirectory\ExampleFile.txt";

            //  Create directory if not exist 
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }


            // Create and write data text
            string content = "Hello, this is a sample text.";
            File.WriteAllText(filePath, content);
            Console.WriteLine($"File created and written to at {filePath}");

            string readContent = File.ReadAllText(filePath);
            Console.WriteLine($"Content of the file: {readContent}");


            // Create and write data by byte
            byte[] contentByte = { 0x42, 0x69, 0x6E, 0x61, 0x72, 0x79 }; // "Binary" in hex
            File.WriteAllBytes(filePath, contentByte);
            Console.WriteLine($"Binary file created and written to at {filePath}");

            // Read data as byte 
            byte[] readContentByte = File.ReadAllBytes(filePath);
            Console.WriteLine($"Content of the file (as hex): {BitConverter.ToString(readContentByte)}");




            Console.WriteLine("Deleting the file...");
            File.Delete(filePath);
            Console.WriteLine($"File deleted at {filePath}");

            Directory.Delete(directoryPath);
            Console.WriteLine($"Directory deleted at {directoryPath}");
        }


    }
}
