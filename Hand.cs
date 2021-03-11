using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        private List<Card> Cards = new List<Card>();

        public void AddCardToHand(Card card)
        {
            Cards.Add(card);
        }

        public bool IsNatural()
        {
            // Natural blackjacks can only have 2 cards
            if (Cards.Count != 2)
            {
                return false;
            }

            // Natural blackjack occurs when 1 card is an ace and the other is worth 10
            if(Cards[0].IsAce() == true && Cards[1].Value == 10 || (Cards[0].Value == 10 && Cards[1].IsAce() == true))
            {
                return true;
            }

            return false;
        }

        public bool IsBust()
        {
            // A hand is bust if the total value is over 21
            if(GetTotalCardValue() > 21)
            {
                return true;
            }

            return false;
        }

        public int GetTotalCardValue()
        {
            int handValue = 0;

            // Add up value of each card in hand
            foreach(Card card in Cards)
            {
                // Aces can be 1 or 11. If an Ace would cause a hand to go bust treat it as a value of 1
                if (card.IsAce() == true && (handValue + card.Value > 21))
                {
                    handValue = handValue + 1;
                }
                else
                {
                    handValue = handValue + card.Value;
                }
            }

            return handValue;
        }

        public string GetCardNames()
        {
            string cardNames = "";

            foreach (Card card in Cards)
            {
                if (cardNames != "")
                {
                    cardNames = cardNames + ", ";
                }

                cardNames = cardNames + card.Name;
            }

            return cardNames;
        }

        public string GetFirstCard()
        {
            return Cards[0].Name;
        }

        public bool IsSplittable()
        {
            // Hand only splittable if it contains 2 cards
            if (Cards.Count != 2)
            {
                return false;
            }

            // Both cards in hand must be the same
            if (Cards[0].Name.Equals(Cards[1].Name))
            {
                return true;
            }

            return false;
        }
    }
}