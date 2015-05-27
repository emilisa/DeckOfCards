namespace DeckOfCards
{
    using System;
    using System.Collections.Generic;
    
    class DeckOfCards
    {
        static void Main()
        {
            //Card card1 = new Card("8", "Clubs", '♣', ConsoleColor.Green);
            //card1.Show();

            //Card card2 = new Card("7", "Hearts", '♥', ConsoleColor.Red);
            //card2.Show();

            //Card card3 = new Card("Q", "Spades", '♠', ConsoleColor.Gray);
            //card3.Show();

            Card[] cards = new Card [6];

            cards[0] = new Card("10", "Clubs");
            cards[1] = new Card("9", "Hearts");
            cards[2] = new Card("J", "Spades");
            cards[3] = new Card("A", "Diamonds");
            cards[4] = new Card("4", "Clubs");
            cards[5] = new Card("K", "Hearts");

            foreach (Card card in cards)
            {
                card.Show();
                Console.WriteLine();
            }
        }
    }
}
