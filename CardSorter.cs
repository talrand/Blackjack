using System.Collections.Generic;

namespace Blackjack
{
    public class CardSorter : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}