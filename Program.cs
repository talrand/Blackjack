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
            Card card = null;

            for (int i = 1; i <6; i++)
            {
                card = deck.Draw();
                Console.WriteLine(card.Name);
            }

            Console.ReadLine();
        }
    }
}
