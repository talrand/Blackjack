using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        private static Deck deck = new Deck();

        static void Main(string[] args)
        {
            Hand playerHand = null;
            Card drawnCard = null;

            try
            {
                // Create player's hand
                playerHand = CreateStartingHand();
                OutputHand(playerHand);
                
                // If player's hand contains a natural blackjack they win
                if (playerHand.IsNaturalBlackjack() == true)
                {
                    Console.WriteLine("Congratulations! You win!");
                }
                else
                {
                    // Draw cards until player stands or their hand goes bust
                    while(GetPlayerAction() == "HIT")
                    {
                        drawnCard = deck.Draw(1)[0];
                        playerHand.AddCardToHand(drawnCard);
                        OutputHand(playerHand);

                        if (playerHand.IsBust() == true)
                        {
                            Console.WriteLine("Bust! You lose!");
                            break;
                        }
                    }
                }

                Console.WriteLine("Press any key to close...");
                Console.ReadLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine("ERR - " + ex.Message);
            }
        }     

        private static Hand CreateStartingHand()
        {
            Hand hand = new Hand();
            Card[] cards = deck.Draw(2);

            foreach(Card card in cards)
            {
                hand.AddCardToHand(card);
            }

            return hand;
        }

        private static void OutputHand(Hand hand)
        {
            Console.WriteLine("Cards in hand: " + hand.GetCardNames());
            Console.WriteLine("Total value: " + hand.GetTotalCardValue());
        }

        private static string GetPlayerAction()
        {
            Console.Write("Hit or Stand? ");
            return Console.ReadLine().ToUpper();
        }

    }
}
