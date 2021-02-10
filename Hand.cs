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

        public bool IsNaturalBlackjack()
        {
            // Natural blackjacks can only have 2 cards
            if (Cards.Count != 2)
            {
                return false;
            }

            // Natural blackjack occurs when 1 card is an ace and the other is worth 10
            if(Cards[1].IsAce() == true && Cards[2].Value == 10 || (Cards[1].Value == 10 && Cards[2].IsAce() == true))
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
                handValue = handValue + card.Value;
            }

            return handValue;
        }
    }
}