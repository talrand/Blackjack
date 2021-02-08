namespace Blackjack
{
    public class Card
    {
        public string Name { get; }
        public int Value { get; }

        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}