using System;

namespace DateTimeSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //prints current date and time to console
            DateTime now = DateTime.Now;
            Console.WriteLine($"Current Date and Time: {now}");
            //ask user for number
            Console.Write("\nEnter a number: ");
            //prints to the console the exact time it will be in X hours, X being the number the user entered
            int hoursToAdd;
            if (int.TryParse(Console.ReadLine(), out hoursToAdd))
            {
                DateTime futureTime = now.AddHours(hoursToAdd);
                Console.WriteLine($"The time in {hoursToAdd} hours will be: {futureTime}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
