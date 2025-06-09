using System;

namespace StructAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an object of data type Number 
            Number myNumber = new Number();
            //assign a value to the Amount property
            myNumber.Amount = 100.50m;
            //print the value of the Amount property to the console
            Console.WriteLine("The amount is: " + myNumber.Amount);
        }
    }
}
