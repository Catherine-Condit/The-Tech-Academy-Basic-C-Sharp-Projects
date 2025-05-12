using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Anonymous Income Comparison Program");

            Console.WriteLine("Person 1");
            Console.WriteLine("Please enter hourly rate:");
            decimal person1HourlyRate = Convert.ToDecimal(Console.ReadLine()); //Convert string to decimal to allow for cents
            Console.WriteLine("Please enter hours worked per week:");
            decimal person1HoursWorked = Convert.ToDecimal(Console.ReadLine()); //convert string to decimal to allow for less than an hour

            Console.WriteLine("Person 2");
            Console.WriteLine("Please enter hourly rate:");
            decimal person2HourlyRate = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please enter hours worked per week:");
            decimal person2HoursWorked = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Annual salary of Person 1:");
            decimal person1AnnualSalary = person1HourlyRate * person1HoursWorked * 52; //52 weeks in a year
            Console.WriteLine("$" + person1AnnualSalary);

            Console.WriteLine("Annual salary of Person 2:");
            decimal person2AnnualSalary = person2HourlyRate * person2HoursWorked * 52; //52 weeks in a year
            Console.WriteLine("$" + person2AnnualSalary);

            Console.WriteLine("Does Person 1 make more money than Person 2?");
            bool doesPerson1MakeMore = person1AnnualSalary > person2AnnualSalary; //compare the two salaries
            Console.WriteLine(doesPerson1MakeMore); //output true or false

            Console.WriteLine("Press any key to exit."); //keep program open until user presses a key
            Console.ReadKey();
        }
    }
}
