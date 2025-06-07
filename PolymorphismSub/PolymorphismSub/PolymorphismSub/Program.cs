using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new instance of Employee and set properties
            Employee employee = new Employee()
            {
                FirstName = "Bob",
                LastName = "Smith",
            };

            //call SayName method to display employee's name
            employee.SayName();

            //create an object of IQuittable type using polymorphism. an object can be of an interface type if it implements that specific interface.
            IQuittable quittableEmployee = employee;

            //call Quit method to display quitting message
            quittableEmployee.Quit();

            // Wait for user input before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
