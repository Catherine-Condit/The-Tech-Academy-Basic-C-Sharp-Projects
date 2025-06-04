using System;

namespace ClassSubmission
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer number: ");
            string input = Console.ReadLine(); //read user input as string
            //try to parse the input to an integer
            if (int.TryParse(input, out int userNumber))
            {
                //call static method to divide by 2 and print result
                MathHelper.DivideByTwo(userNumber);

                // use method with output parameters. The out keyword is especially useful when a method needs to return more than one value
                MathHelper.DivideWithRemainder(userNumber, 2, out int quotient, out int remainder);
                Console.WriteLine($"Using output parameters: Quotient = {quotient}, Remainder = {remainder}");

                // call overloaded method (divides by two but with method overloading)
                MathHelper.DivideWithRemainder(userNumber, out int quotient2, out int remainder2);
                Console.WriteLine($"Using overloaded method: Quotient = {quotient2}, Remainder = {remainder2}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            // Wait for user input before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    static class MathHelper
    {
        //void method that takes an integer, divides it by 2, and prints the result
        public static void DivideByTwo(int number)
        {
            int result = number / 2;
            Console.WriteLine("Result of dividing by 2: " + result);
        }

        //method with output parameters to return both quotient and remainder
        public static void DivideWithRemainder(int number, int divisor, out int quotient, out int remainder)
        {
            quotient = number / divisor;
            remainder = number % divisor;
        }

        // Overloaded method: same name as above but takes only 1 parameter, divides it by 2
        public static void DivideWithRemainder(int number, out int quotient, out int remainder)
        {
            quotient = number / 2;
            remainder = number % 2;
        }
    }
}

