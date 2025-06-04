using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of Employee and initialize its properties
            Employee employee = new Employee()
            {
                FirstName = "Sample", // Set the first name
                LastName = "Student", // Set the last name
            };
            employee.SayName(); // Call the SayName method to display the name

            // Wait for a key press so the console doesn't close immediately
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey(); // Wait for user input
        }
    }
}
