using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne
{
    public class TwentyOneDealer : Dealer
    {
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } } //Dealer's hand, which is a list of Card objects
        public bool Stay { get; set; } //whether the dealer has chosen to stay or not
        public bool isBusted { get; set; } //whether the dealer has busted or not   
    }
}
