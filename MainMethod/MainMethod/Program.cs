using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the MathOperations class
            MathOperations mathOps = new MathOperations();

            // Call the method that takes an integer and display the result
            int result1 = mathOps.PerformOperation(25); // 25 + 20 = 45
            Console.WriteLine("Result of integer operation: " + result1);

            // Call the method that takes a decimal and display the result
            int result2 = mathOps.PerformOperation(7.5m); // 7.5 * 2 = 15
            Console.WriteLine("Result of decimal operation: " + result2);

            // Call the method that takes a string and display the result
            int result3 = mathOps.PerformOperation("20"); // 20 - 2 = 18
            Console.WriteLine("Result of string operation: " + result3);

            // Keep console open until user presses Enter
            Console.ReadLine();
        }
    }

    //class with overloaded methods for diff types of input
    public class MathOperations
    {
        //method one takes an integer input, adds 20, and returns the result
        public int PerformOperation(int number)
        {
            return number + 20; //adss 20 to the input number
        }

        //method two takes a decimal, multiplies by 2, and returns the result
        public int PerformOperation(decimal number)
        {
            return (int)(number * 2); //multiplies the input number by 2
        }

        //method three takes a string, converts it to an integer, subtracts 2, and returns the result
        public int PerformOperation(string numberString)
        {
            int parsedNumber = int.Parse(numberString); //converts the string to an integer
            return parsedNumber - 2; //subtracts 2 from the parsed number
        }
    }
}
