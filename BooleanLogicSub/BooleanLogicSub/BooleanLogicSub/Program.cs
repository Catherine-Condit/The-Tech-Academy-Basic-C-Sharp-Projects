using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanLogicSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car Insurance Approval Program"); // title
            Console.WriteLine("===================================");
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine()); // age input converted to int
            Console.WriteLine("Have you ever had a DUI? (true/false)"); // DUI input specifies t/f
            bool hasDUI = Convert.ToBoolean(Console.ReadLine()); // DUI input converted to bool
            Console.WriteLine("How many speeding tickets do you have? (Please enter 0 if none.)");
            int speedingTickets = Convert.ToInt32(Console.ReadLine()); // speeding tickets input converted to int
            bool isApproved = (age > 15 && !hasDUI && speedingTickets <= 3);
            Console.WriteLine("Approved for car insurance? " + isApproved);

            // The program checks if the user is older than 15, has no DUI, and has 3 or fewer speeding tickets.
            // If all conditions are true, the user is approved for car insurance.
            // If any condition is false, the user is not approved.

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); // wait for user to press a key before closing
        }
    }
}
