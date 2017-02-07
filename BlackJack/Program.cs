using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            board.StartGame();
        }
    }
}
