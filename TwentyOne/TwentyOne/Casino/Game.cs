using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public abstract class Game //base class = abstract class, no instance needed/allowed of Game object/class, so can be made abstract, "locking in code"
    {
        //design towards abstraction! (reason why I didnt name this class "TwentyOneGame") 

        private List<Player> _players = new List<Player>();
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();  
        public List<Player> Players { get { return _players; } set { _players = value; } } // List of Player objects
        public string Name { get; set; } // Name of the game
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }

        public abstract void Play(); //abstract method, no implementation here, but must be implemented in ALL derived classes (like TwentyOneGame)
        
        //a virtual method (always exist inside an abstract class) means this method gets inherited by an inheriting class, but it has the ability to override it
        public virtual void ListPlayers() //void bc doesnt return anything, just printing list to console
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
