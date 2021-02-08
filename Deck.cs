using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        private List<Card> Cards = new List<Card>();

        public Deck()       
        {
            Card card = null;

            // Initialize card list
            for (int i = 1; i < 14; i++)
            {
                // Create card
                card = CardFactory.Create(i);

                // Add 4 of each card to deck
                for (int j = 1; j < 5; j++)
                {
                    Cards.Add(card);
                }
            }

            // Randomly sort cards
            Shuffle();
        }

        public void Shuffle()
        {
            Cards.Shuffle();
        }

        public Card[] Draw(int numberOfCards)
        {
            Card[] drawnCards = new Card[numberOfCards];
            Card nextCard = null;

            for (int i = 1; i <= numberOfCards; i++)
            {
                // Get next card from deck
                nextCard = Cards[1];

                // Remove card from deck
                Cards.Remove(nextCard);

                // Add to return array
                drawnCards[i - 1] = nextCard;
            }

            // Return card to player
            return drawnCards;
        }
    }
}
