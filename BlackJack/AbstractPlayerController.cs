using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    abstract class AbstractPlayerController
    {
        public Player player;

        public AbstractPlayerController(Player player)
        {
            this.player = player;
        }

        public void AddCard(DeckController deck)
        {
            player.cardsInHand.Add(deck.GetCard());
        }

        public int GetPoint()
        {
            int result = 0;
            foreach (var item in player.cardsInHand)
            {
                result += item.point;
            }
            return result;
        }
    }
}
