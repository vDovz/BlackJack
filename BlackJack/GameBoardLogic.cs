using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace BlackJack
{
    class GameBoardLogic
    {
        private GameBoard _gameBoard;
        private PlayerLogic _player;
        private PlayerLogic _ai;
        private DeckController _deck;
        private bool _gameContinued = true;

        public GameBoardLogic(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _player = new PlayerLogic(gameBoard.player, "Player");
            _ai = new PlayerLogic(gameBoard.ai, "Diller");
            _deck = new DeckController(gameBoard.deck);
        }

        public void StartGame()
        {
            while (_gameContinued)
            {
                Turn();
            }
        }

        private void Turn()
        {
            _deck = new DeckController(_gameBoard.deck);
            _player.AddCard(_deck);
            _ai.AddCard(_deck);
            _player.player.turnContinued = true;
            _ai.player.turnContinued = true;
            while (_player.player.turnContinued && !CheckBust(_player, _ai))
            {
               ConsoleView.ShowTable(_player, _ai);
                _player.Logic(_deck, _ai);
                CheckBust(_player, _ai);
                ConsoleView.ShowTable(_player, _ai);
            }
            while (_ai.player.turnContinued && !CheckBust(_player, _ai))
            {
                _ai.Logic(_deck, _player);
                ConsoleView.ShowTable(_player, _ai);
                Thread.Sleep(1000);
                CheckBust(_ai, _player);
            }
            CheckResult(_player, _ai);
            RestartGame();
        }

        private void RestartGame()
        {
            ConsoleView.ShowGameRestart();
            string input = Console.ReadLine();
            if (input == "y")
            {
                _player.CardsClear();
                _ai.CardsClear();
                Console.Clear();
            }
            else
            {
                _gameContinued = false;
            }
        }

        private bool CheckBust(PlayerLogic player, PlayerLogic enemy)
        {
            if (player.GetPoint() > 21)
            {
                return true;
            }
            if(enemy.GetPoint() > 21)
            {
                return true;
            }
            return false;
        }

        private void CheckResult(PlayerLogic player, PlayerLogic enemy)
        {
            if ((player.GetPoint() < enemy.GetPoint() || player.GetPoint() > 21) && enemy.GetPoint() <= 21)
            {
                ConsoleView.ShowWin(enemy.player.name);
                return;
            }
            if (player.GetPoint() > enemy.GetPoint() || enemy.GetPoint() > 21)
            {
                ConsoleView.ShowWin(player.player.name);
                return;
            }
            if (player.GetPoint() == enemy.GetPoint())
            {
                ConsoleView.ShowWin("");
                return;
            }
        }

    }
}
