using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismSub
{
    public abstract class Person
    {
        public string FirstName { get; set; } // Property for storing first name
        public string LastName { get; set; }  // Property for storing last name
        public abstract void SayName(); // Abstract method to be implemented by derived classes to display the person's name
    }
}
