using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class PlayerLogic
    {
        public Player player;

        public PlayerLogic(Player player, string name)
        {
            player.name = name;
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

        public void Logic(DeckController deck, PlayerLogic enemy)
        {
            if (player.name == "Player")
            {
                ConsoleView.ShowPlayerAction();
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        AddCard(deck);
                        break;
                    case 2:
                        player.turnContinued = false;
                        break;
                    default:
                        break;
                }
            }
            if (player.name == "Diller")
            {
                if (GetPoint() < 17 && GetPoint() <= enemy.GetPoint())
                {
                    AddCard(deck);
                    return;
                }
                    player.turnContinued = false;
            }
        }

        public void CardsClear()
        {
            player.cardsInHand.Clear();
        }
    }
}
