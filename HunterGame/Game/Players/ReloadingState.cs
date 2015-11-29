using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class ReloadingState : IPlayerState
    {
        public int shoot()
        {
            return 0;
        }

        public string ToString()
        {

            return "You are reloading!!";
        }
    }
}
