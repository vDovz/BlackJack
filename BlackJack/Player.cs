using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
   public class Player
    {
        public List<Card> cardsInHand = new List<Card>();
        public TypePlayer name;
        public bool turnContinued = true;
        private int _enoughtPoint = 17; 

        public Player(TypePlayer name)
        {
            this.name = name;
        }

        public void AddCard(Deck deck)
        {
            cardsInHand.Add(deck.GetCard());
        }

        public int GetPoint()
        {
            int result = 0;
            foreach (var item in cardsInHand)
            {
                result += item.Point;
            }
            return result;
        }

        public void Logic(Deck deck, Player enemy)
        {
            if (name == TypePlayer.Player)
            {
                ConsoleView.ShowPlayerAction();
                int userInput = int.Parse(ConsoleView.UserInput());
                switch (userInput)
                {
                    case 1:
                        AddCard(deck);
                        break;
                    case 2:
                        turnContinued = false;
                        break;
                    default:
                        break;
                }
            }
            if (name == TypePlayer.Diller)
            {
                if (GetPoint() < _enoughtPoint && GetPoint() <= enemy.GetPoint())
                {
                    AddCard(deck);
                    return;
                }
                turnContinued = false;
            }
        }

        public void CardsClear()
        {
            cardsInHand.Clear();
        }
    }
}
