using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class DeckController
    {
        private Deck _deck;
        private Random _rand = new Random();
        private int _sizeDeck = 52;
        private int _countSuit = 4;
        private int _countRank = 13;

        public DeckController(Deck deck)
        {
            _deck = deck;
            _deck.sizeDeck = _sizeDeck;
            deck.deck = new List<Card>(_sizeDeck);
            InitDeck();
            Shuffle();
        }

        private void InitDeck()
        {
            for (int i = 0; i < _countSuit; i++)
            {
                for (int j = 1; j < _countRank + 1; j++)
                {
                    _deck.deck.Add(new Card(j, i, j));
                }        
            }
        }

        private void Shuffle()
        {
            for (int i = 0; i < _deck.deck.Count; i++)
            {
                int randomIndex = _rand.Next(0, _deck.deck.Count);
                Card temp = _deck.deck[i];
                _deck.deck[i] = _deck.deck[randomIndex];
                _deck.deck[randomIndex] = temp;
            }
        }

        public Card GetCard()
        {
            var result = _deck.deck[0];
            _deck.deck.Remove(_deck.deck[0]);
            return result;
        }
    }
}
