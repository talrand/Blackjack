namespace Blackjack
{
    public static class CardFactory
    {
        public const string Ace = "Ace";

        public static Card Create(int cardNumber)
        {
            switch (cardNumber)
            {
                case 1:
                    return new Card(Ace, 11);
                case 11:
                    return new Card("Jack", 10);
                case 12:
                    return new Card("Queen", 10);
                case 13:
                    return new Card("King", 10);
                default:
                    return new Card(cardNumber.ToString(), cardNumber);
            }
        }
    }
}