using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class Firing : IPlayerState
    {
        public Firing()
        {

        }

        public string shoot()
        {
            return "Success";
        }
    }
}
