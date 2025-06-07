using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismSub
{
    public class Employee : Person, IQuittable // Employee class inherits from Person and implements IQuittable interface
    {
        //override SayName method to display employee's full name
        public override void SayName()
        {
            Console.WriteLine($"Employee Name: {FirstName} {LastName}");
        }

        //implement Quit method from IQuittable interface to display quitting message
        public void Quit()
        {
            Console.WriteLine($"{FirstName} {LastName} has quit the job.");
        }
    }
}
