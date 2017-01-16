using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IDeck
    {
        void InitDeck();

        Card GetRandomCard();
    }
}
