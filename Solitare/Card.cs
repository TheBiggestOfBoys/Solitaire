namespace Solitaire
{
    internal class Card
    {
        public Values Value { get; private set; }
        public Suits Suit { get; private set; }
        public bool Revealed { get; set; } = false;

        public Card(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }

        public void Flip()
        {
            Revealed = !Revealed;
        }

        public ConsoleColor GetColor() => Suit switch
        {
            Suits.Hearts or Suits.Diamonds => ConsoleColor.Red,
            Suits.Clubs or Suits.Spades => ConsoleColor.Red
        };

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }

        internal enum Suits
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        internal enum Values
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }
    }
}
