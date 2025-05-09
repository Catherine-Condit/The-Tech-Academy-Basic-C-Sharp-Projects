using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //takes input,input * 50, prints result
            Console.WriteLine("Please enter any number.");
            long firstInput = Convert.ToInt64(Console.ReadLine()); //can take inputs larger than 10,000,000
            long firstResult = firstInput * 50;
            Console.WriteLine(firstInput + " times 50 = " + firstResult);

            //takes input, input + 25, prints result
            Console.WriteLine("\nPlease enter any number.");
            long secondInput = Convert.ToInt64(Console.ReadLine());
            long secondResult = secondInput + 25;
            Console.WriteLine(secondInput + " plus 25 = " + secondResult);

            //takes input, input / 12.5, prints result
            Console.WriteLine("\nPlease enter any number.");
            long thirdInput = Convert.ToInt64(Console.ReadLine());
            double thirdResult = thirdInput / 12.5;
            Console.WriteLine(thirdInput + " divided by 12.5 = " + thirdResult);

            //takes input, check if input > 50, prints result T/F
            Console.WriteLine("\nPlease enter any number.");
            long fourthInput = Convert.ToInt64(Console.ReadLine());
            bool fourthResult = fourthInput > 50;
            Console.WriteLine("\"" + fourthInput + " is greater than 50\" is " + fourthResult);

            //takes input, input % 7, prints resulting remainder
            Console.WriteLine("\nPlease enter any number.");
            long fifthInput = Convert.ToInt64(Console.ReadLine());
            long fifthResult = fifthInput % 7;
            Console.WriteLine("The remainder of " + fifthInput + " divided by 7 = " + fifthResult);


            // Keep console open until user clicks any key to close
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
