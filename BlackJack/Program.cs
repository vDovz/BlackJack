using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoardController board = new GameBoardController(new GameBoard());
            board.StartGame();
        }
    }
}
