using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberGuessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secretNumber = 7; //hardcoded secret number
            int userGuess; // Variable to store user's guess

            Console.WriteLine("=== WHILE LOOP EXAMPLE ===");
            Console.Write("Guess the secret number (1-8): ");
            userGuess = Convert.ToInt32(Console.ReadLine()); // Get user input

            // Boolean comparison using while loop
            while (userGuess != secretNumber)
            {
                Console.Write("Wrong number! Try again: ");
                userGuess = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Correct! You guessed the number using a while loop.\n");

            Console.WriteLine("=== DO-WHILE LOOP EXAMPLE ===");

            // Reset userGuess to demonstrate the do-while loop
            do
            {
                Console.Write("Guess the secret number (1-8): ");
                userGuess = Convert.ToInt32(Console.ReadLine());

                if (userGuess != secretNumber)
                    Console.WriteLine("Wrong! Try again.");

            } while (userGuess != secretNumber);

            Console.WriteLine("Correct! You guessed the number using a do-while loop.");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
