using System;

namespace MethodSubmission
{
    class Program
    {
        static void Main(string[] args)
        {
            //create instance of the MathOperations class
            MathOperations mathOps = new MathOperations();

            //ask user for the first number
            Console.Write("Enter the first number: ");
            string firstInput = Console.ReadLine(); //read user input

            //try to parse the first number input to an integer
            if (!int.TryParse(firstInput, out int firstNumber))
            {
                Console.WriteLine("Invalid input for the first number. Please enter an integer value.");
                return; //exit if input is invalid
            }

            //ask user for the second number(optional)
            Console.Write("Enter the second number (optional, press Enter to skip the second number (default is 1): ): ");
            string secondInput = Console.ReadLine(); //read user input
            int result;
            if (string.IsNullOrWhiteSpace(secondInput))
            {
                //if no second number is provided, call the method with one parameter
                result = mathOps.AddNumbers(firstNumber);
            }
            else
            {
                //try to parse the second input to an integer
                if (!int.TryParse(secondInput, out int secondNumber))
                {
                    Console.WriteLine("Invalid input for the second number. ");
                    return; //exit if input is invalid
                }
                //call method with both numbers
                result = mathOps.AddNumbers(firstNumber, secondNumber);
            }

            //display the result
            Console.WriteLine($"The result is: {result}");

            //pause the console to view the result before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    class MathOperations
    {
        //method to take two integers, with the second one being optional (default is 1)
        public int AddNumbers(int firstNumber, int secondNumber = 1)
        {
            return firstNumber + secondNumber; //return the sum of the two numbers
        }
    }
}
