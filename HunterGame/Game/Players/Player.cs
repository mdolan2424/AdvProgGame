using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
namespace HunterGame
{
    public class Player
    {
        public string name { get; set; }
        public int lives { get; set; }
        public int power { get; set; }

        //player state changes
        private PlayerContext status;
        

        public Player(int lives)
        {
            name = "";
            this.lives = lives;
            this.power = 0;
            
        }
        
        public void changeLives(int amount)
        {
            lives += amount;
        }
        
        public void changePower(int amount)
        {
            power += amount;
        }



    }
}
