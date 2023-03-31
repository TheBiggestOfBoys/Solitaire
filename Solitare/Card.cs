namespace Solitare
{
    internal class Card
    {
        private bool revealed = false;

        public Values Value { get; private set; }
        public Suits Suit { get; private set; }
        public string Name { get { return $"{Value} of {Suit}"; } }
        public bool Revealed { get; set; }

        public Card(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }

        public void Reveal()
        {
            revealed = true;
        }
    }
}
