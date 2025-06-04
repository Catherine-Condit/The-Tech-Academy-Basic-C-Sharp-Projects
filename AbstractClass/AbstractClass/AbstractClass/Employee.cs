using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class Employee : Person
    {
        //implement the SayName method inside the Employee class
        public override void SayName()
        {
            // Display the full name in the console
            Console.WriteLine($"Name: {FirstName} {LastName}");
        }
    }
}
