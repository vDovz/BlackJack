using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public Enums.Rank rank { get; set; }
        public Enums.Suit suit { get; set; }
        public int point { get; set; }

        public Card(int rank, int suit, int point)
        {
            this.rank =(Enums.Rank) Enum.Parse(typeof(Enums.Rank),rank.ToString());
            this.suit = (Enums.Suit)Enum.Parse(typeof(Enums.Suit), suit.ToString()); 
            if(point > 10)
            {
                point = 10;
            }
            this.point = point;
        }
    }
    
}
