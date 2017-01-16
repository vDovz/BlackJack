using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack
{
    class AI : AbstractPlayer
    {
        public bool Logic(AbstractPlayer player)
        {
            if (GetPoint() < 17 && GetPoint() < player.GetPoint())
            {
                return true;
            }
            return false;
        }
    }
}
