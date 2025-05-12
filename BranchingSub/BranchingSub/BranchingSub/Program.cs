using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
            Console.WriteLine("Please enter the package weight in pounds:");
            double weightInput = Convert.ToDouble(Console.ReadLine()); //read string to double
            if (weightInput > 50) //check if weight is greater than 50
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }
            // Prompt user for package width
            Console.WriteLine("Please enter the package width:");
            double widthInput = Convert.ToDouble(Console.ReadLine());
            // Prompt user for package height
            Console.WriteLine("Please enter the package height:");
            double heightInput = Convert.ToDouble(Console.ReadLine());
            // Prompt user for package length
            Console.WriteLine("Please enter the package length:");
            double lengthInput = Convert.ToDouble(Console.ReadLine());

            // Calculate the total size of the package by adding dimensions
            double dimensionTotal = widthInput + heightInput + lengthInput;

            // Check if the package is too large
            if (dimensionTotal > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return; // End the program
            }

            // Calculate the quote based on volume * weight / 100
            double quote = (widthInput * heightInput * lengthInput * weightInput) / 100;

            // Display the estimated shipping cost formatted as currency
            Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
            Console.WriteLine("Thank you!");

            // Wait for user input before closing the console
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
