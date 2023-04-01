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

        public int ToInt()
        {
            int value = 0;
            switch (Value)
            {
                case Values.Two:
                    value = 2; 
                    break;
                case Values.Three:
                    value = 3;
                    break;
                case Values.Four:
                    value = 4;
                    break;
                case Values.Five:
                    value = 5;
                    break;
                case Values.Six:
                    value = 6;
                    break;
                case Values.Seven:
                    value = 7;
                    break;
                case Values.Eight:
                    value = 8;
                    break;
                case Values.Nine:
                    value = 9;
                    break;
                case Values.Ten:
                    value = 10;
                    break;
            }
            return value;
        }
    }
}
