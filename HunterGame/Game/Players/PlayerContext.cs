using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class PlayerContext
    {
        private IPlayerState playerState;
        
        public PlayerContext()
        {
            playerState = new FiringState();
        }

        public void setState(IPlayerState state)
        {
            playerState = state;
        }

        public IPlayerState getState()
        {
            return playerState;
        }

       
    }
}
