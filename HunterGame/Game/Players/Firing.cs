using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class Firing : IPlayerState
    {
        int damage;
        string notification;

        public Firing()
        {
            damage = 1;
            notification = "";

        }

        public int shoot()
        {
            return damage;
        }
    }
}
