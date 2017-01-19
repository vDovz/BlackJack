using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack
{
    class GameBoardController
    {
        GameBoard gameBoard;

        public PlayerController player;
        public AIController ai;
        public DeckController deck;

        public GameBoardController(GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
            player = new PlayerController(gameBoard.player);
            ai = new AIController(gameBoard.ai);
            deck = new DeckController(gameBoard.deck);
        }

        public void StartGame()
        {
            player.AddCard(deck);
            ai.AddCard(deck);

            while (player.turnContinued)
            {
                this.ShowTable();
                this.CheckBust(player);
                player.PlayerAction(deck);
            }
            while (ai.Logic(player))
            {
                ai.AddCard(deck);
                this.ShowTable();
                Thread.Sleep(1000);
                this.CheckBust(ai);    
            }
            this.ShowGameResult();
        }


    }
}
