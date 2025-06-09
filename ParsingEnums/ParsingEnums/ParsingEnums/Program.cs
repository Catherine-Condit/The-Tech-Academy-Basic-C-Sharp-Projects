using System;

namespace ParsingEnums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //prompt the user to enter a day of the week
            Console.WriteLine("Please enter the current day of the week:");
            //read user input as a string
            string userInput = Console.ReadLine();

            try
            {
                //try to parse input string into DaysOfWEek enum
                //the 'true' parameter makes the parse case-insensitive
                DaysOfWeek currentDay = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), userInput, true);

                //if successful, print the successfully parsed enum value
                Console.WriteLine($"You entered: {currentDay}");
            }
            catch (Exception)
            {
                //if parsing fails, catch the error and print friendly message
                Console.WriteLine("Please enter an actual day of the week.");
            }

            //wait for user input before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    //enum that represents the days of the week
    public enum DaysOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
