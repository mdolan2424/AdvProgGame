using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class FiringState : IPlayerState
    {
        private int damage;
        private string notification;
        public int stunShots { get; set; }
        public FiringState()
        {
            damage = 1;
            notification = "";
        }

        public int shoot()
        {
            return damage;
        }

       
        public override string ToString()
        {
            return notification;
        }
    }
}
