using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number; // This will store the valid integer input from the user

            // Loop until the user provides a valid integer input
            while (true)
            {
                // Prompt the user for input
                Console.WriteLine("Please enter a number to perform math operations on:");

                // Try to convert user input to an integer
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    break; // If conversion is successful, exit the loop
                }
                catch (FormatException) // If input is not a valid number
                {
                    Console.WriteLine("That was not a valid number. Please enter a whole number (integer).");
                }
            }

            // Create an instance of the MathOperations class to access its methods
            MathOperations operations = new MathOperations();

            // Call the AddTen method and display the result
            int result1 = operations.AddTen(number);
            Console.WriteLine("Result after adding 10: " + result1);

            // Call the Square method and display the result
            int result2 = operations.Square(number);
            Console.WriteLine("Result after squaring the number: " + result2);

            // Call the SubtractFive method and display the result
            int result3 = operations.SubtractFive(number);
            Console.WriteLine("Result after subtracting 5: " + result3);

            // Keep the console window open until the user presses a key
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
