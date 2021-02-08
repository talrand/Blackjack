using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> Cards { get; }

        public Hand()
        {
            Cards = new List<Card>();
        }

    }
}