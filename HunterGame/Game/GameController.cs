using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HunterGame
{
    public class GameController
    {
        //create player
        private Player player;
        private const int maxEnemies = 10;
        public GameController ()
        {
            //game controller will keep track of
            //player, enemies, score, items.
            player = new Player(3);
            
        }


        public void spawnItem()
        {
            

           
            

            

        }
        


        
    }
}
