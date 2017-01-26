using System;

namespace BlackJack
{
    static class ConsoleView
    {
        public static void ShowCards(this Player player)
        {
            foreach (var item in player.cardsInHand)
            {
                Console.WriteLine("{0} {1} {2}", item.rank, item.suit, item.point);
            }
        }

        public static void ShowWin(string name)
        {
            if (name == "")
            {
                Console.WriteLine("Dead Heat");
                return;
            }
            Console.WriteLine("Win {0}", name);
        }

        public static void ShowTable(Player player, Player diller)
        {
            Console.Clear();
            diller.ShowCards();
            Console.WriteLine("Diller point {0} \n", diller.GetPoint());
            Console.WriteLine("\n\n\n\n\n\n");
            player.ShowCards();
            Console.WriteLine("Player point {0} \n", player.GetPoint());
            Console.WriteLine();
        }

        public static void ShowGameRestart()
        {
            Console.WriteLine("If you want restart game write 'y' , else write any key");
        }

        public static void ShowPlayerAction()
        {
            Console.WriteLine("1. Add card");
            Console.WriteLine("2. Enough Card");
        }
    }
}
