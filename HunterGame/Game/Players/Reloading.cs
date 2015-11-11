using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class Reloading : IPlayerState
    {
        public Reloading()
        {
            
        }
        
        public string shoot()
        {
            return "You are reloading!";
        }
    }
}
