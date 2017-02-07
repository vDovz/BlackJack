using System;
using System.Threading;


namespace BlackJack
{
    public class GameBoard
    {
        private Player _player = new Player(TypePlayer.Player);
        private Player _diller = new Player(TypePlayer.Diller);
        private Deck _deck = new Deck();
        private bool _gameContinued = true;
        private int _maxPoint = 21;

        public GameBoard()
        {
        
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
            _deck = new Deck();
            _player.AddCard(_deck);
            _diller.AddCard(_deck);
            _player.turnContinued = true;
            _diller.turnContinued = true;
            while (_player.turnContinued && !CheckBust(_player, _diller))
            {
                ConsoleView.ShowTable(_player, _diller);
                _player.Logic(_deck, _diller);
                CheckBust(_player, _diller);
                ConsoleView.ShowTable(_player, _diller);
            }
            while (_diller.turnContinued && !CheckBust(_player, _diller))
            {
                _diller.Logic(_deck, _player);
                ConsoleView.ShowTable(_player, _diller);
                Thread.Sleep(1000);
                CheckBust(_diller, _player);
            }
            CheckResult(_player, _diller);
            RestartGame();
        }

        private void RestartGame()
        {
            ConsoleView.ShowGameRestart();
            string input = ConsoleView.UserInput();
            if (input == "y")
            {
                _player.CardsClear();
                _diller.CardsClear();
                Console.Clear();
            }
            else
            {
                _gameContinued = false;
            }
        }

        private bool CheckBust(Player player, Player enemy)
        {
            if (player.GetPoint() > _maxPoint)
            {
                return true;
            }
            if (enemy.GetPoint() > _maxPoint)
            {
                return true;
            }
            return false;
        }

        private void CheckResult(Player player, Player enemy)
        {
            if ((player.GetPoint() < enemy.GetPoint() || player.GetPoint() > _maxPoint) && enemy.GetPoint() <= _maxPoint)
            {
                ConsoleView.ShowWin(enemy.name);
                return;
            }
            if (player.GetPoint() > enemy.GetPoint() || enemy.GetPoint() > _maxPoint)
            {
                ConsoleView.ShowWin(player.name);
                return;
            }
            if (player.GetPoint() == enemy.GetPoint())
            {
                ConsoleView.ShowWin(TypePlayer.Unknown);
                return;
            }
        }
    }
}
