using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class StunnedState : IPlayerState
    {

        private int stunShots;

        public StunnedState()
        {
            stunShots = -3;
        }
        public int shoot()
        {
            stunShots += 1;
            return stunShots;
        }

        
        public override string ToString()
        {

            return "You are stunned!!";
        }
    }
}
