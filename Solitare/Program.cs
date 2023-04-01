namespace Solitare
{
    internal class Program
    {
        public static List<List<Card>> board = new();
        public static List<List<Card>> discard = new();
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

            // Set board capacity
            for (int x = 0; x <= 6; x++)
            {
                board.Add(new List<Card>(x + 1));
            }

            // Set discard capacity
            for (int x = 0; x <= 3; x++)
            {
                discard.Add(new List<Card>(x + 1));
            }

            // Fill the board
            for (int x = 0; x <= 6; x++)
            {
                for (int y = 0; y <= x; y++)
                {
                    board[x].Add(deck[y]);
                    deck.Remove(deck[y]);
                    if (y == x)
                    {
                        board[x][y].Revealed = true;
                    }
                }
            }

            DisplayBoard();
            DisplayDiscard();
            Console.WriteLine($"Cards left in deck: {deck.Count}");
        }

        public static void DisplayBoard()
        {
            // Loops 7 times for each column
            foreach (List<Card> list in board)
            {
                // Loops for each card in the column
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
                        Console.WriteLine(ConvertToSmall(card));
                    }
                    else
                    {
                        Console.WriteLine("?");
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void DisplayDiscard()
        {
            // Loops 4 times for each pile
            foreach (List<Card> list in discard)
            {
                // Displays only the top card
                if (list.Count == 0)
                {
                    Console.WriteLine("#");
                }
                else
                {
                    Console.WriteLine(list[0]);
                }
            }
            Console.WriteLine();
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

        public static string ConvertToSmall(Card card)
        {
            if (card.Value <= Values.Ten)
            {
                return card.ToInt().ToString();
            }
            else
            {
                return card.Name[0].ToString();
            }
        }
    }
}