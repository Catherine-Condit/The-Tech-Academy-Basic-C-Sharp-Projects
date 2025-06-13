using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        public Player(string name) : this(name, 100)
        {
            // This constructor allows creating a Player with just a name, defaulting the balance to 100.
        }
        public Player(string name, int beginningBalance)
        {
            Hand = new List<Card>(); //initialize Hand as a new list of Card objects
            Balance = beginningBalance; //set Balance to the value of beginningBalance
            Name = name; //set Name to the value of name
        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;
            }
            else
            {
                Balance -= amount; //subtracts the bet amount from the player's balance
                return true; //returns true if the bet was successful
            }
        }

        public static Game operator+ (Game game, Player player)
        {
            game.Players.Add(player); //takes game, add player to the game
            return game; //and returns game
        }

        public static Game operator- (Game game, Player player)
        {
            game.Players.Remove(player); //takes game, remove player from the game
            return game; //and returns game
        }
    }
}
