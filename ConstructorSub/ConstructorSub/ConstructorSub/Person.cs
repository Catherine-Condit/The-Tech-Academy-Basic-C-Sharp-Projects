using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorSub
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //default constructor
        public Person(string name) : this(name, 30) //chain two constructors
        {
            //this constructor initializes the Name property and sets a default Age of 30.
        }
        //overloaded constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        //method to display person information
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }
}
