using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Card[] hand = deck.Draw(7);

            foreach (Card card in hand)
            {
                Console.WriteLine(card.Name);
            }

            Console.ReadLine();
        }
    }
}
