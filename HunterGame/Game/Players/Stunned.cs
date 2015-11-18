using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class Stunned : IPlayerState
    {
        int damage;
        string notification;
        public Stunned()
        {
            damage = 0;
            notification = "You are stunned!";
        }
        public int shoot()
        {
            return damage;
        }
    }
}
