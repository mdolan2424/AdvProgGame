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
        public int stunShots { get; set; }
        
        public int ammo { get; set; }
        private IPlayerState state;
        //based on players current state
        public int damage { get; set; }
        private string stateText;
        private PlayerContext context;
        

        private Score score;

        public Score PlayerScore
        {
            get { return score; }
        }

       
        

        public Player(int lives)
        {
            //defaults
            name = "";
            this.lives = lives;
            this.damage = 1;
            score = new Score();
            state = new FiringState();
        }
        
        public void changeLives(int amount)
        {
            lives += amount;
        }
        
        public void reload()
        {
            
        }
        

        public int shootEnemy()
        {
            return state.shoot();
        }

        //reports state back to controller
        public string getState()
        {
            return state.ToString();
        }
        public void checkDanger(int killworth)
        {
            if (killworth == -1)
            {
                state = new StunnedState();
                damage = state.shoot();
                //stunned
                
            }

            else
            {
                state = new FiringState();
                damage = state.shoot();
            }
        }
    }
}
