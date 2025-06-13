using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public struct Card //classes are reference types, structs are value types. structs are more lightweight than classes, so they are used for small data structures like this. structs are copied by value, not by reference
    {
        public Suit Suit { get; set; } //card class has a property of data type string called suit. public = accesible to other parts of program
        public Face Face { get; set; }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
    }

    public enum Suit //essentially a new data type. underlying data type of enum is an int
    {
        Clubs, // value= 0
        Diamonds, //value =1, etc. can set values explicitly if desired
        Hearts,
        Spades
    }

    public enum Face
    {
        Two, // value = 0
        Three, // value = 1
        Four, // value = 2
        Five, // value = 3
        Six, // value = 4
        Seven, // value = 5
        Eight, // value = 6
        Nine, // value = 7
        Ten, // value = 8
        Jack, // value = 9
        Queen, // value = 10
        King, // value = 11
        Ace // value = 12
    }
}
