using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class AbstractPlayer
    {
        private List<Card> cardsInHand = new List<Card>();

        public void AddCard(Deck deck)
        {
            cardsInHand.Add(deck.GetRandomCard());
        }

        public void ShowCards()
        {
            foreach (var item in cardsInHand)
            {
                Console.WriteLine("{0} {1} {2}", item.rank, item.suit, item.point);
            }
        }

        public int GetPoint()
        {
            int result = 0;
            foreach (var item in cardsInHand)
            {
                result += item.point;
            }
            return result;
        }
    }
}
