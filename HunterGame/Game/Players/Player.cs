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

        
        private Score score;
        public Score PlayerScore
        {
            get { return score; }
        }

        //player state changes
        private PlayerContext status;
        

        public Player(int lives)
        {
            //defaults
            name = "";
            this.lives = lives;
            this.power = 1;
            score = new Score();
            
        }
        
        public void changeLives(int amount)
        {
            lives += amount;
        }
        
        public void changePower(int amount)
        {
            power += amount;
        }

        public int shootEnemy()
        {
            IPlayerState state = status.getState();
            //damage calculation
            int damage = this.power * state.shoot();

            return damage;
        }


    }
}
