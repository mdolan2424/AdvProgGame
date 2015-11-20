using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HunterGame.Game.Items
{
    public interface IItem
    {
        string name { get; }
        string image { get; }


        int increaseLives();
        int weaponUpgrade();
        int powerUp();

        
        
        
        
    }
}
