using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace functionalStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string string1 = "Hello!";
            string string2 = "I am very excited.";
            string string3 = "This line was written using string concatenation!";
            string string4 = string1 + " " + string2 + " " + string3 + "\n";  //concatenation
            Console.WriteLine(string4);//Prints the concatenated string to the console

            string1 = string1.ToUpper(); //converts to uppercase
            Console.WriteLine(string1 + "\n");//Prints the uppercase string to the console

            //Creates a Stringbuilder and builds a paragraph of text, one sentence at a time
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Hello!");
            sb.AppendLine("I am very excited.");
            sb.AppendLine("This paragraph was written using a StringBuilder!");
            Console.WriteLine(sb.ToString()); //Prints the StringBuilder object to the 

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); //Waits for a key press before exiting
        }
    }
}
