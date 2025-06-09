using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create list of at least 10 employees. at least two employees should have the same first name "Joe"
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Joe", LastName = "Smith" },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Doe" },
                new Employee { Id = 3, FirstName = "Joe", LastName = "Johnson" },
                new Employee { Id = 4, FirstName = "Alice", LastName = "Brown" },
                new Employee { Id = 5, FirstName = "Bob", LastName = "Davis" },
                new Employee { Id = 6, FirstName = "Charlie", LastName = "Wilson" },
                new Employee { Id = 7, FirstName = "David", LastName = "Garcia" },
                new Employee { Id = 8, FirstName = "Eve", LastName = "Martinez" },
                new Employee { Id = 9, FirstName = "Joe", LastName = "Lopez" },
                new Employee { Id = 10, FirstName = "Grace", LastName = "Hernandez" }
            };

            //use foreach loop to create a new list of all employees with the first name "Joe"
            List<Employee> joeEmployees = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.FirstName == "Joe") //reference property of object being checked
                {
                    joeEmployees.Add(employee);
                }
            }

            //CHECKING CODE BY PRINTING TO CONSOLE:
            //perform same action using a lambda expression
            List<Employee> joeEmployeesLambda = employees.Where(e => e.FirstName == "Joe").ToList();
            //use lambda expression to make a list of all employees with an id number greater than 5
            List<Employee> idGreaterThanFive = employees.Where(e => e.Id > 5).ToList();

            Console.WriteLine("Employees with First Name 'Joe' (foreach loop):");
            joeEmployees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - ID: {e.Id}"));

            Console.WriteLine("\nEmployees with First Name 'Joe' (lambda function):");
            joeEmployeesLambda.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - ID: {e.Id}"));

            Console.WriteLine("\nEmployees with ID > 5:");
            idGreaterThanFive.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - ID: {e.Id}"));

        }
    }
}
