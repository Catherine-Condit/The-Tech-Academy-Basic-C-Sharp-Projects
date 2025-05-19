using System;
using System.Collections.Generic;

namespace MultiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //assignemnt part one
            //create 1-D array of strings
            string[] names = { "Hello", "Welcome", "Goodbye", "See you", "Take care" };

            //assignment part two
            //infinite loop to ask user for input continuously
            while (true)
            {
                //ask user for input
                Console.WriteLine("\nEnter a name to append (or type 'exit' to quit): ");
                string name = Console.ReadLine();

                // FIX to infinite loop:
                // Check if user wants to exit, and break out of loop if so
                if (name.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting the name program...");
                    break; // ← this fixes the infinite loop by allowing a way to exit
                }

                //loop to append users input name to each string in the array (without outputting)
                for (int i = 0; i < names.Length; i++)
                {
                    names[i] += " " + name;
                }
                //second loop to output each string in the array one at a time
                foreach (string str in names)
                {
                    Console.WriteLine(str);
                }                              
            }

            //assignment part three
            Console.WriteLine("\nLoop using '<' operator:");
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine($"j = {j}");
            }

            Console.WriteLine("\nLoop using '<=' operator:");
            for (int k = 0; k <= 5; k++)
            {
                Console.WriteLine($"k = {k}");
            }

            //assignment part four
            // Unique list of strings
            List<string> items = new List<string> { "apple", "banana", "orange", "grape", "mango",
            "pineapple", "kiwi", "strawberry", "blueberry", "raspberry",
            "watermelon", "cantaloupe", "peach", "plum", "cherry" };

            bool keepRunning = true; // Variable to control the loop

            while (keepRunning)
            {
                // Ask user for input
                Console.Write("\nEnter text to search for a fruit: ");
                string userInput = Console.ReadLine();

                bool matchFound = false;

                // Loop through list to find a match
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Equals(userInput, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Match found at index {i}: {items[i]}");
                        matchFound = true;
                        break; // Stop loop after first match
                    }
                }

                // If no match was found
                if (!matchFound)
                {
                    Console.WriteLine("Your input was not found in the list.");
                    Console.Write("Would you like to try again? (y/n): ");
                    string retryInput = Console.ReadLine().ToLower(); // Ask user if they want to try again

                    if (retryInput != "y")
                    {
                        keepRunning = false;
                    }
                }
                else
                {
                    keepRunning = false; // Exit after successful match
                }

                Console.WriteLine();
            }

            //assignment part five
            List<string> duplicateItems = new List<string>
        {
            "book", "pen", "notebook", "pen", "eraser", "pencil", "notebook", "marker", "laptop", "book"
        };

            Console.Write("\nEnter text to search for a type of school supply: ");
            string searchInput = Console.ReadLine(); //stores user input
            bool anyMatch = false; //creates boolean variable to check if any matches were found

            for (int i = 0; i < duplicateItems.Count; i++) //for loop to iterate through the list
            {
                if (duplicateItems[i].Equals(searchInput, StringComparison.OrdinalIgnoreCase)) //if match to user input is found, output index and match
                {
                    Console.WriteLine($"Match found at index {i}: {duplicateItems[i]}");
                    anyMatch = true; //sets boolean to true if match is found
                }
            }

            if (!anyMatch) //if no matches were found, output message without allowing user to search again
            {
                Console.WriteLine("Your input was not found in the list.");
            }

            //assignment part six
            //new line
            Console.WriteLine();
            // Create a list of strings with at least one duplicate entry
            List<string> stringList = new List<string> { "cat", "dog", "cow", "cat", "chicken", "horse", "dog", "goat" };

            // Create a HashSet to store strings we've already seen (for quick lookup)
            HashSet<string> seenStrings = new HashSet<string>();

            // Iterate over each string in the list
            foreach (string item in stringList)
            {
                // Check if the string has already been seen
                if (seenStrings.Contains(item))
                {
                    // If yes, print that it's a duplicate
                    Console.WriteLine($"{item} - this item is a duplicate");
                }
                else
                {
                    // If not, add it to the HashSet and print that it's unique
                    seenStrings.Add(item);
                    Console.WriteLine($"{item} - this item is unique");
                }
            }

            //wait for user to close window
            Console.WriteLine("\nPress any key to close the window...");
            Console.ReadKey();
        }
    }
}
