using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class StunnedState : IPlayerState
    {

        private float Timer;

        public StunnedState()
        {
            Timer = 3.0F;
        }
        public Boolean shoot()
        {
            return false;
        }

        
        public override string ToString()
        {

            return "You are stunned!!";
        }

        
    }
}
