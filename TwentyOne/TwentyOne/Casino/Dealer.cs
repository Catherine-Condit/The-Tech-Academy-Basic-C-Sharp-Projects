using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {
        //rule for inheritance/Composition Over Inheritance (err on side of class prop as opposed to inheriting):
        // /if it IS a... = inherit. If it HAS a... = do not inherit, instead include it as a class property.
        //inheritance IS a relationship, it does not HAVE a relationship. So, for example,
        // the TwentyOneGame IS a game, therefore it can inherit from the Game class.
        //however, a Dealer IS NOT a deck, but rather HAS a deck, so it is not inheriting from the Deck class.
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First()); //add the first card from the deck to the player's hand
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card);
            using (StreamWriter file = new StreamWriter(@"C:\Users\conca\logs\logs.txt", true)) //true says To append some text to the file
            {
                file.WriteLine(DateTime.Now); //value type
                file.WriteLine(card);
            }
            Deck.Cards.RemoveAt(0); //remove the first card from the deck after dealing it
        }
    }
}
