using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 10, 25, 36, 50, 62, 98 }; // List of integers
        try
        {
            Console.WriteLine("Enter a number to divide each number in the list by.");
            int input = Convert.ToInt32(Console.ReadLine());
            // Loop through each number in the list
            foreach (int number in numbers)
            {
                // Divide the number by user input and print the result. could use/convert to double for decimal results and to avoid divide by zero error
                int result = number / input;
                Console.WriteLine($"{number} / {input} = {result}");
            }
        }
        catch (FormatException ex) //assigning exception name "ex" for format exceptions
        {
            Console.WriteLine("Error: Please enter a whole number."); //better ui
            return; //common in exception handling
        }
        catch (DivideByZeroException ex) //if user tries to divide by zero
        {
            Console.WriteLine("Error: Please do not divide by zero."); //better ui
        }
        catch (Exception ex) //catch all other exceptions we dont necessarily see
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message); //server gives premade message for all other exceptions
        }
        finally //this code will always run, typically has db log
        {
            Console.ReadLine(); //this ensures error message can be read
        }

        // Code after try/catch block
        Console.WriteLine("Program has continued after the try/catch block.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

