using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class FiringState : IPlayerState
    {
        private Boolean canShoot;
        private string notification;
        public int stunShots { get; set; }
        public FiringState()
        {
            canShoot = true;
            this.notification = "Firing: OK";
        }

        public Boolean shoot()
        {
            return canShoot;
        }

       
        public override string ToString()
        {
            return this.notification;
        }
    }
}
