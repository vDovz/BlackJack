using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public Rank rank { get; set; }
        public Suit suit { get; set; }
        public int point { get; set; }

        public enum Suit { Hearts, Diamonds, Spades, Clubs };
        public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

        public Card(int rank, int suit, int point)
        {
            this.rank =(Rank) Enum.Parse(typeof(Rank),rank.ToString());
            this.suit = (Suit)Enum.Parse(typeof(Suit), suit.ToString()); 
            if(point > 10)
            {
                point = 10;
            }
            this.point = point;
        }
    }
    
}
