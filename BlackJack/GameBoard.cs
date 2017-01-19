using System;
using System.Threading;


namespace BlackJack
{
    class GameBoard
    {
        public Player player = new Player();
        public Player ai = new Player();
        public Deck deck = new Deck();
    }
}
