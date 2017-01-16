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
            int sizeDeck = 52;
            GameBoard gameTable = new GameBoard(sizeDeck);
            gameTable.StartGame();
        }
    }
}
