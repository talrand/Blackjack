﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public static class Game
    {
        private static Deck deck = null;

        public static void Play()
        {
            Hand playerHand = null;
            Card drawnCard = null;
            Hand dealerHand = null;

            try
            {
                // Clear previous game
                Console.Clear();

                // Shuffle deck
                deck = new Deck();

                // Create player's hand
                playerHand = CreateStartingHand();
                OutputHand(playerHand);

                // If player's hand contains a natural blackjack they win
                if (playerHand.IsNatural() == true)
                {
                    Console.WriteLine("Congratulations! You win!");
                    return;
                }

                // Draw dealer's hand
                dealerHand = CreateStartingHand();

                // Reveal first card of dealer's hand
                Console.WriteLine("Dealer reveals : " + dealerHand.GetFirstCard());

                // Draw cards until player stands or their hand goes bust
                while (GetPlayerAction() == "HIT")
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

                if (playerHand.IsBust() == false)
                {
                    // Dealer logic
                    // Dealer will always draw if their hand is worth 17 or less
                    while (dealerHand.GetTotalCardValue() < 18)
                    {
                        dealerHand.AddCardToHand(deck.Draw(1)[0]);

                        // Check if dealer is bust
                        if (dealerHand.IsBust() == true)
                        {
                            // Inform user
                            Console.WriteLine("Dealer reveals their hand");
                            OutputHand(dealerHand);
                            Console.WriteLine("Dealer is bust. You win!");
                            return;
                        }
                    }

                    // If dealer didn't go bust, reveal hand and compare with player's hand
                    Console.WriteLine("Dealer reveals their hand");
                    OutputHand(dealerHand);

                    if (playerHand.GetTotalCardValue() > dealerHand.GetTotalCardValue())
                    {
                        Console.WriteLine("You win");
                    }
                    else
                    {
                        Console.WriteLine("You lose");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERR - " + ex.Message);
            }
        }

        private static Hand CreateStartingHand()
        {
            Hand hand = new Hand();
            Card[] cards = deck.Draw(2);

            foreach (Card card in cards)
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