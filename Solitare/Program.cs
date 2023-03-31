namespace Solitare
{
    internal class Program
    {
        public static List<List<Card>> board;
        public static List<Card> deck = new();
        public static Random random = new();

        static void Main()
        {
            // Generate Deck
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 2; value <= 14; value++)
                {
                    deck.Add(new Card((Values)value, (Suits)suit));
                }
            }
            Shuffle(deck);

            // Fill the board
            int cardNumber = 0;
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 0; y <= x; y++)
                {
                    board[0][x] = deck[cardNumber];
                    cardNumber++;
                }
            }

            DisplayBoard();
            PrintCards(deck);
        }

        public static void DisplayBoard()
        {
            foreach (List<Card> list in board)
            {
                foreach (Card card in list)
                {
                    if (card.Revealed == true)
                    {
                        if ((card.Suit == Suits.Hearts) || (card.Suit == Suits.Diamonds))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if ((card.Suit == Suits.Clubs) || (card.Suit == Suits.Spades))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        Console.WriteLine(card.Name);
                    }
                    else
                    {
                        Console.WriteLine("?");
                    }
                }
                Console.ResetColor();
            }
        }

        public static void PrintCards(List<Card> cardList)
        {
            if (cardList == null)
            {
                Console.WriteLine("**EMPTY**");
            }
            else
            {
                foreach (Card card in cardList)
                {
                    if ((card.Suit == Suits.Hearts) || (card.Suit == Suits.Diamonds))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if ((card.Suit == Suits.Clubs) || (card.Suit == Suits.Spades))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine(card.Name);
                }
            }
            Console.ResetColor();
        }

        public static void Shuffle(List<Card> cards)
        {
            // Shuffle the cards using the Fisher-Yates shuffle algorithm
            for (int i = cards.Count - 1; i > 0; i--)
            {
                // Generate a random number j between 0 and i (inclusive)
                int j = random.Next(0, i + 1);

                // Swap the positions of cards[i] and cards[j]
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
        }
    }
}