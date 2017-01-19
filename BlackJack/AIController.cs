using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class AIController : AbstractPlayerController
    {
        public AIController(Player player) : base(player)
        {

        }

        public bool Logic(AbstractPlayerController player)
        {
            if (GetPoint() < 17 && GetPoint() < player.GetPoint())
            {
                return true;
            }
            return false;
        }
    }
}
