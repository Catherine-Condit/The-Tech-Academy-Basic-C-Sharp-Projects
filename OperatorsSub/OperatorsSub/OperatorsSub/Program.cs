using System;


namespace OperatorsSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the first Employee object and assign properties
            Employee employee1 = new Employee()
            {
                Id = 101,
                FirstName = "John",
                LastName = "Doe"
            };

            // Create the second Employee object and assign properties
            Employee employee2 = new Employee()
            {
                Id = 101, // Same ID as emp1 to test equality
                FirstName = "Jane",
                LastName = "Smith"
            };

            //compare the two Employee objects using overloaded '=='
            if (employee1 == employee2)
            {
                Console.WriteLine("Employee1 and Employee2 are considered equal (same Id).");
            }
            else
            {
                Console.WriteLine("Employee1 and Employee2 are not equal (different Ids).");
            }

            //comparison using '!=' for completeness
            if (employee1 != employee2) //overloaded != operator is called
            {
                Console.WriteLine("Employee1 and Employee2 are different.");
            }
            else
            {
                Console.WriteLine("Employee1 and Employee2 are the same.");
            }

            // Keep the console window open until user presses a key
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
