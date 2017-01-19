using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class DeckController
    {
        private Deck deck;
        private Random rand = new Random();
        private int sizeDeck = 52;
        private int countSuit = 4;
        private int countRank = 13;

        public DeckController(Deck deck)
        {
            this.deck = deck;
            this.deck.sizeDeck = sizeDeck;
            deck.deck = new List<Card>(sizeDeck);
            InitDeck();
            Shuffle();
        }

        private void InitDeck()
        {
            for (int i = 0; i < countSuit; i++)
            {
                for (int j = 1; j < countRank + 1; j++)
                {
                    deck.deck.Add(new Card(j, i, j));
                }        
            }
        }

        private void Shuffle()
        {
            for (int i = 0; i < deck.deck.Count; i++)
            {
                int randomIndex = rand.Next(0, deck.deck.Count);
                Card temp = deck.deck[i];
                deck.deck[i] = deck.deck[randomIndex];
                deck.deck[randomIndex] = temp;
            }
        }

        public Card GetCard()
        {
            var result = deck.deck[0];
            deck.deck.Remove(deck.deck[0]);
            return result;
        }
    }
}
