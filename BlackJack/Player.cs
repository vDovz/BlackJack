using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player: AbstractPlayer
    {

        public bool turnContinued = true;

        public void PlayerAction(Deck deck)
        {
            Console.WriteLine("1. Add card");
            Console.WriteLine("2. Enough Card");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    AddCard(deck);
                    break;
                case 2:
                    turnContinued = false;
                    break;
                default:
                    Console.WriteLine("Not correct value. Try again");
                    break;
            }
        }
    }
}
