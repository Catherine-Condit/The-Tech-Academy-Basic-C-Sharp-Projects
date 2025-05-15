using System;
using System.Collections.Generic;

namespace ArrayConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-D array of strings
            string[] stringArray = { "apple", "banana", "cherry", "blackberry", "raspberry" };
            //prompt user
            Console.WriteLine("Select an index (0-4) to get a fruit from the array!: ");
            int stringIndex = Convert.ToInt32(Console.ReadLine());
            //check if index is valid
            if (stringIndex >= 0 && stringIndex < stringArray.Length)
            {
                //print the fruit at the index
                Console.WriteLine($"You selected the fruit at index {stringIndex} which is the {stringArray[stringIndex]}!");
            }
            else
            {
                Console.WriteLine("Invalid index. Please select a number between 0 and 4.");
            }

            //1-D array of integers
            int[] intArray = { 10, 20, 30, 40, 50 };
            //prompt user
            Console.WriteLine("Select an index (0-4) to get a number from the array!: ");
            int intIndex = Convert.ToInt32(Console.ReadLine());
            //check if index is valid
            if (intIndex >= 0 && intIndex < intArray.Length)
            {
                //print the number at the index
                Console.WriteLine($"You selected the number at index {intIndex} which is {intArray[intIndex]}!");
            }
            else
            {
                Console.WriteLine("Invalid index. Please select a number between 0 and 4.");
            }

            //create a list of strings
            List<string> stringList = new List<string> { "blue", "green", "red", "orange", "gold" };
            //prompt user
            Console.WriteLine("Select an index (0-4) to get a color from the list!: ");
            int listIndex = Convert.ToInt32(Console.ReadLine());
            //check if index is valid
            if (listIndex >= 0 && listIndex < stringList.Count)
            {
                //print the color at the index
                Console.WriteLine($"You selected the color at index {listIndex} which is {stringList[listIndex]}!");
            }
            else
            {
                Console.WriteLine("Invalid index. Please select a number between 0 and 4.");
            }
        }
    }
}
