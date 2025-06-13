using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        public Deck()
        {
            // Constructor
            // This is a special method that is called when an object of this class is created.
            // It can be used to initialize properties or perform any setup needed for the object.
            //need to find efficent way to create a deck of cards
            Cards = new List<Card>(); //refers to property of class

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Create a new card and add it to the deck
                    Card card = new Card();
                    card.Face = (Face)i; // Cast the integer to the Face enum
                    card.Suit = (Suit)j; // Cast the integer to the Suit enum
                    Cards.Add(card);
                }
            }
        }
        public List<Card> Cards { get; set; } // List of Card objects

        public void Shuffle(int times = 1) //create optional parameter times by setting it to default 1, cleaner AND easier to read
        {
            for (int i = 0; i < times; i++)
            {
                // Shuffle the deck of cards
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex); //function of list method
                }
                Cards = TempList;
            }
        }

    }
}
