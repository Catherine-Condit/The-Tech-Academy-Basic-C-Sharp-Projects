using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Interfaces;

namespace Casino.TwentyOne
{
    public class TwentyOneGame : Game, IWalkAway //how to inherit from class = current class name : base class name
    {
        public TwentyOneDealer Dealer { get; set; }
        //MUST PUT PLAY METHOD HERE (THATS HOW SERIOUS THESE ABSTRACT METHODS (FROM GAME CLASS) ARE). OTHERWISE WOULDNT COMPILE
        public override void Play() //method to play the game, specific to TwentyOneGame class by override
        {
            Dealer = new TwentyOneDealer(); //create a new dealer object
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle(); //shuffle the deck before dealing cards

            foreach (Player player in Players)
            {
                bool validAnswer = false; //set validAnswer to false to start
                int bet = 0;
                while (!validAnswer) //while validAnswer is false, keep asking for input
                {
                    Console.WriteLine("Place your bet!");
                    validAnswer = int.TryParse(Console.ReadLine(), out bet); //try to parse the input as an integer, if successful, set validAnswer to true
                    if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals."); 
                }
                if (bet < 0)
                {
                    throw new FraudException("Security! Kick this person out.");
                }
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet)
                {
                    return; //if the player could not place a bet, exit the method. goes back to "place your bet" play method
                }
                Bets[player] = bet; //add the bet to the Bets dictionary, where the key is the player and the value is the bet amount
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);
                    if (i == 1)
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand); //check if player has blackjack
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}!", player.Name, Bets[player] * 1.5);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]); //if player has blackjack, they win 1.5x their bet plus bet amount back
                            return;
                        }
                    }
                }
                Console.WriteLine("Dealer: ");
                Dealer.Deal(Dealer.Hand); //deal cards to dealer
                if (i == 1)
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand); //check if dealer has blackjack
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }
                }
            }
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are: ");
                    foreach(Card card in player.Hand)
                    {
                        Console.WriteLine("{0} ", card.ToString());
                    }
                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower(); //get input from player
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                    }
                    bool busted = TwentyOneRules.IsBusted(player.Hand); //check if player is busted
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                        Console.WriteLine("Do you want to play again?");
                        answer = Console.ReadLine().ToLower(); //ask player if they want to play again
                        if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya" || answer == "yea")
                        {
                            player.isActivelyPlaying = true; //set player to actively playing
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false; //set player to not actively playing
                            return;
                        }
                    }
                }
            }
            Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand); //check if dealer is busted
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand); //dealer always stays after dealing cards
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand); //check if dealer is busted
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand); //check if dealer should stay
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying.");
            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer Busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2); //double the bet amount for each player that won. Where() method produces a list
                    Dealer.Balance -= entry.Value; //subtract the bet amount from the dealer's balance
                }
                return;
            }
            foreach (Player player in Players)
            {
                //turns bool into nullable bool
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand); //compare player's hand to dealer's hand
                if (playerWon == null)
                {
                    Console.WriteLine("Push! No one wins.");
                    player.Balance += Bets[player]; //if it's a push, return the player's bet
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += Bets[player] * 2; //if player won, double the bet amount
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player]; //if dealer won, add the bet amount to the dealer's balance
                }
                Console.WriteLine("Play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya" || answer == "yea")
                {
                    player.isActivelyPlaying = true; //set player to actively playing
                }
                else
                {
                    player.isActivelyPlaying = false; //set player to not actively playing
                }
            }
        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 players:");
            base.ListPlayers(); //equal to what is happening in the Game class, but can add more functionality here if needed
        }

        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
