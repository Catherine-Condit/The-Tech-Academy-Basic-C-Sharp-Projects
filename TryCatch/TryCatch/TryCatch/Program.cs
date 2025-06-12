using System;

namespace TryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ask user for their age
            Console.WriteLine("Please enter your age:");
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                //check if age is less than 0
                if (age <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative or zero.");
                }
                else
                {
                    //calculate the year of birth
                    int yearOfBirth = DateTime.Now.Year - age;
                    Console.WriteLine($"You were born in the year {yearOfBirth}.");
                }
            }
            catch (FormatException) //handle non-numeric input
            {
                Console.WriteLine("Invalid input. Please enter a numeric value for age.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //handle negative or zero age input
                Console.WriteLine(ex.Message);
            }
            catch (Exception) //generic message if exception caused by anythingn else
            {
                Console.WriteLine("An unexpected error occurred. Please try again.");
            }
            finally
            {
                //wait for user input before closing the console
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
