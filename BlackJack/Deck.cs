using System;
using System.Collections.Generic;


namespace BlackJack
{
    class Deck : IDeck
    {
        private List<Card> deck;
        private int sizeDeck;
        Random random = new Random();

        public Deck(int sizeDeck)
        {
            if(sizeDeck != 52)
            {
                sizeDeck = 52;
            }
            this.sizeDeck = sizeDeck;
            deck = new List<Card>(sizeDeck);
            InitDeck();
        }

        public void InitDeck()
        {
            int rank = 0;
            for (int i = 0; i < sizeDeck; i++)
            {
                rank++;
                deck.Add(new Card(rank, i % 4, rank));
                if (rank == 13)
                {
                    rank = 0;
                }
            }
        }

        public Card GetRandomCard()
        {
            Card result;
            int indexOfCart = random.Next(0, deck.Count);
            result = deck[indexOfCart];
            deck.Remove(deck[indexOfCart]);
            return result;
        }
    }
}
