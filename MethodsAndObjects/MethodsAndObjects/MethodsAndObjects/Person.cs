using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndObjects
{
    public class Person 
    {
        public string FirstName { get; set; } // Set the first name of the person
        public string LastName { get; set; }// Set the last name of the person
        public void SayName() // Method to display the full name of the person
        {
            Console.WriteLine("Name: " + FirstName + " " + LastName);
        }
    }
}
