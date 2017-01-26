using System;
using System.Collections.Generic;


namespace BlackJack
{
    class Deck
    {
        private Random _rand = new Random();
        private int _countSuit = Enum.GetValues(typeof(Suit)).Length;
        private int _countRank = Enum.GetValues(typeof(Rank)).Length;
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            InitDeck();
            Shuffle();
        }

        private void InitDeck()
        {
            for (int i = 0; i < _countSuit; i++)
            {
                for (int j = 1; j < _countRank + 1; j++)
                {
                    _deck.Add(new Card(j, i, j));
                }
            }
        }

        private void Shuffle()
        {
            for (int i = 0; i < _deck.Count; i++)
            {
                int randomIndex = _rand.Next(0, _deck.Count);
                Card temp = _deck[i];
                _deck[i] = _deck[randomIndex];
                _deck[randomIndex] = temp;
            }
        }

        public Card GetCard()
        {
            var result = _deck[0];
            _deck.Remove(_deck[0]);
            return result;
        }
    }
}
