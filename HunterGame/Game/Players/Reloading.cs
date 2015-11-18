using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class Reloading : IPlayerState
    {

        int damage;
        string notification;
        public Reloading()
        {
            damage = 0;
            notification = "You are reloading!";
        }
        
        public int shoot()
        {
            return damage;
        }
    }
}
