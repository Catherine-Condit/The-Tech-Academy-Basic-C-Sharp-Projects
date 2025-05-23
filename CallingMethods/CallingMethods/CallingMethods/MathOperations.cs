using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMethods
{
    public class MathOperations
    {
        // Adds 10 to the input value
        public int AddTen(int number)
        {
            return number + 10;
        }

        // Squares the input value
        public int Square(int number)
        {
            return number * number;
        }

        // Subtracts 5 from the input value
        public int SubtractFive(int number)
        {
            return number - 5;
        }
    }
}
