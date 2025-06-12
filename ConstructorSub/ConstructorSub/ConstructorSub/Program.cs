using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a const variable
            const string greeting = "Welcome to the Constructor Demo.";
            Console.WriteLine(greeting);

            //create a variable using keyword "var"
            var userName = "Alice";
            //create instances of the Person class using different constructors. Here, the default constructor is used because no age has been provided.
            Person person1 = new Person(userName);
            //call the DisplayInfo method to show the person's information
            person1.DisplayInfo();

            //create another instance of the Person class with a different name and age. Here, the overloaded constructor is used.
            Person person2 = new Person("George", 30);
            person2.DisplayInfo();

            //wait for user input before closing the console
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
