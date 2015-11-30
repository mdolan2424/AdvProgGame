using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
using HunterGame.Game;
namespace HunterGame
{
    public class Player
    {
        //player
        public string name { get; set; }
        public int lives { get; set; }
        public int stunShots { get; set; }
        
        //weapon
        public int ammo { get; set; }
        public int reloadTime { get; set; }
        public int damage { get; set; }
        public int shootSpeed { get; set; }

        
        private string stateText;
        private PlayerContext PlayerState;

        private Timer shootTimer;
        
        private Score score;
        private double time;
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
            
            //1 per second
            shootSpeed = 1;
            time = 0;
            this.ammo = 20;
            shootTimer = new Timer();
            PlayerState = new PlayerContext();
        }
        
        public void changeLives(int amount)
        {
            lives += amount;
        }
        
        public void shoot()
        {
            this.ammo -= 1;
            if (this.ammo <= 0)
            {
                reload();
            }
        }
        public void reload()
        {
            //change state
            PlayerState.setState(new ReloadingState());
            this.ammo = 20;
            //set to 3 seconds reload time
            shootTimer.set(time, 3);
            
        }
        
        public Boolean canShoot()
        {
            //check time resolved;
            if (!shootTimer.checkCompletion(time))
            {
                return false;
            }
            PlayerState.setState(new FiringState());
            return PlayerState.getState().shoot();
        }

        //Allows player to report it's state.
        public string getState()
        {
            return PlayerState.getState().ToString();
        }

        
        //TODO: Reevaluate this.
        public void checkDanger(int killworth)
        {
            if (killworth == -1)
            {
                PlayerState.setState(new StunnedState());
                
                //stunned
                
            }

            else
            {
                PlayerState.setState(new FiringState());

            }
        }

        public void update(double time)
        {
            this.time = time;
        }
    }
}
