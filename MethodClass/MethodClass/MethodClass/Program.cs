using System;

namespace MethodClass
{
    class Program
    {
        static void Main(string[] args)
        {
            MathHandler handler = new MathHandler(); //create instance of MathHandler class
            //call the method, passing 5 as numberOne and 7 as numberTwo
            handler.ProcessNumbers(5, 7);

            // Call the method, specifiying parameters by name. Here the order doesn't matter because we're naming the parameters
            handler.ProcessNumbers(numberTwo: 20, numberOne: 8);

            // Pause the console so the user can view the results
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    class MathHandler
    {
        //void method that takes two integers, preforms math operation on first integer and displays second integer to screen
        public void ProcessNumbers(int numberOne, int numberTwo)
        {
            int result = numberOne * 2; // double the first number
            Console.WriteLine($"The result of the operation on {numberOne} is {result}");
            Console.WriteLine($"The second number is {numberTwo}.");
        }
    }
}
