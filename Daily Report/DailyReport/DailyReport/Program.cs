using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Tech Academy"); //The program must start by printing “The Tech Academy.”
            Console.WriteLine("Student Daily Report"); //The program must then print “Student Daily Report.”

            Console.WriteLine("What is your name?"); //The program must ask for the student’s name.
            string studentName = Console.ReadLine(); //The program must store the name in a variable.
            Console.WriteLine("What course are you on?"); //The program must ask for the course name.
            string courseName = Console.ReadLine(); //The program must store the course name in a variable.
            Console.WriteLine("What page number?"); //The program must ask for the page number.
            string pageInput = Console.ReadLine(); //The program must store the page number in a variable. 
            int pageNumber = Convert.ToInt32(pageInput); // Convert string to int
            Console.WriteLine("Do you need help with anything? Please answer “true” or “false.”"); //The program must ask if the student needs help.
            string helpInput = Console.ReadLine(); //The program must store the answer in a variable.
            bool helpNeeded = Convert.ToBoolean(helpInput); // Convert string to bool
            Console.WriteLine("Were there any positive experiences you’d like to share? Please give specifics."); //The program must ask for positive experiences.
            string positiveExperience = Console.ReadLine(); //The program must store the answer in a variable.
            Console.WriteLine("Is there any other feedback you’d like to provide? Please be specific."); //The program must ask for feedback.
            string feedback = Console.ReadLine(); //The program must store the answer in a variable.
            Console.WriteLine("How many hours did you study today?"); //The program must ask for the number of hours studied.
            string hoursInput = Console.ReadLine(); //The program must store the answer in a variable.
            double hoursStudied = Convert.ToDouble(hoursInput); // Convert string to double

            //prints success message
            Console.WriteLine("Thank you for your answers. An Instructor will respond shortly. Have a great day!"); //The program must print a thank you message.


        }
    }
}
