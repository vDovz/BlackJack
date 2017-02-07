using System;
using System.Collections.Generic;


namespace BlackJack
{
    public class Deck
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
            int point = 0;
            for (int suit = 0; suit < _countSuit; suit++)
            {
                for (int rank = 0; rank < _countRank; rank++)
                {
                    point = rank + 1;
                    if(point > 10)
                    {
                        point = 10;
                    }
                    _deck.Add(new Card()
                    {
                        Rank = (Rank)Enum.Parse(typeof(Rank), rank.ToString()),
                        Suit = (Suit)Enum.Parse(typeof(Suit), suit.ToString()),
                        Point = point,
                    });
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
