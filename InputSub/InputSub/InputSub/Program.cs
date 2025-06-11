using System;
using System.IO;

namespace InputSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ask user for a number
            Console.WriteLine("Please enter a number:");
            //read user input from console
            string input = Console.ReadLine();

            //define the path to the log file
            string filePath = @"C:\c#logs\log1.txt";

            //log input to a file
            using (StreamWriter file = new StreamWriter(filePath, true)) //true says to append some text to the file, not overwrite
            {
                file.WriteLine(input);
            }

            //read to user in console
            Console.WriteLine("\nContents of the log file:");
            string fileContents = File.ReadAllText(filePath);
            Console.WriteLine(fileContents);

            //wait for user to press a key before closing the console window
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
