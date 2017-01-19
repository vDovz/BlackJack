using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    static class GameBoardView
    {
        public static void CheckBust(this GameBoardController gameboard, AbstractPlayerController player)
        {
            if (player.GetPoint() > 21)
                if (player.GetType() == typeof(PlayerController))
                {
                    Console.WriteLine("Game Over. Diller win");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Game Over. Player win");
                    Environment.Exit(0);
                }
        }

        public static void ShowGameResult(this GameBoardController gameboard)
        {
            if (gameboard.player.GetPoint() < gameboard.ai.GetPoint())
            {
                Console.WriteLine("Game Over \n Diller wins");
            }
            else if (gameboard.player.GetPoint() > gameboard.ai.GetPoint())
            {
                Console.WriteLine("Game Over \n Player wins");
            }
            else
            {
                Console.WriteLine("Dead Heat");
            }
        }

        public static void ShowTable(this GameBoardController gameboard)
        {
            Console.Clear();
            gameboard.ai.ShowCards();
            Console.WriteLine("Diller point {0} \n", gameboard.ai.GetPoint());
            Console.WriteLine("\n\n\n\n\n\n");
            gameboard.player.ShowCards();
            Console.WriteLine("Player point {0} \n", gameboard.player.GetPoint());
            Console.WriteLine();
        }

    }
}
