using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    static class PlayerView
    {
        public static void ShowCards(this AbstractPlayerController player)
        {
            foreach (var item in player.player.cardsInHand)
            {
                Console.WriteLine("{0} {1} {2}", item.rank, item.suit, item.point);
            }
        }
    }
}
