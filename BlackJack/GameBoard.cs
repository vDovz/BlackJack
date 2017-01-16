using System;
using System.Threading;


namespace BlackJack
{
    class GameBoard
    {
        private Player player;
        private AI ai;
        private Deck deck;

        public GameBoard(int sizeDeck)
        {
            player = new Player();
            ai = new AI();
            deck = new Deck(sizeDeck);
        }

        public void StartGame()
        {
            player.AddCard(deck);
            ai.AddCard(deck);

            while (player.turnContinued)
            {
                ShowTable();
                if (CheckBust(player))
                {
                    Console.WriteLine("Game Over. Diller win");
                    Environment.Exit(0);
                }
                player.PlayerAction(deck);
            }
            while (ai.Logic(player))
            {
                ai.AddCard(deck);
                ShowTable();
                Thread.Sleep(1000);
                if (CheckBust(ai))
                {
                    Console.WriteLine("Game Over. Player win");
                    Environment.Exit(0);
                }
            }
            ShowGameResult();
        }

        private bool CheckBust(AbstractPlayer player)
        {
            if(player.GetPoint() > 21)
            {
                return true;
            }
            return false;
        }

        private void ShowGameResult()
        {
            if (player.GetPoint() < ai.GetPoint())
            {
                Console.WriteLine("Game Over \n Diller wins");
            }
            else if (player.GetPoint() > ai.GetPoint())
            {
                Console.WriteLine("Game Over \n Player wins");
            }
            else
            {
                Console.WriteLine("Dead Heat");
            }
        }

        private void ShowTable()
        {
            Console.Clear();
            ai.ShowCards();
            Console.WriteLine("Diller point {0} \n", ai.GetPoint());
            Console.WriteLine("\n\n\n\n\n\n");
            player.ShowCards();
            Console.WriteLine("Player point {0} \n", player.GetPoint());
            Console.WriteLine();         
        }
    }
}
