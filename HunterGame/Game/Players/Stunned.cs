using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class Stunned : IPlayerState
    {

        public Stunned()
        {

        }
        public string shoot()
        {
            return "You are stunned!";
        }
    }
}
