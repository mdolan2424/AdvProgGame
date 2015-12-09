using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
using HunterGame.Game;
namespace HunterGame.Game.Players
{
    public class Player
    {
        //player
        public string name { get; set; }
        public int lives { get; set; }
        
        
        //weapon
        public int ammo { get; set; }
       
        
        private int maxAmmo;
        private int maxReloadTime;

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
            
            score = new Score();
            
            
            time = 0;
            this.ammo = 20;
            this.maxAmmo = 20;
            shootTimer = new Timer();
            PlayerState = new PlayerContext();
            maxReloadTime = 3;
            
        }
        
        public int getMaxReloadTime()
        {
            return maxReloadTime;
        }

        public int getMaxAmmo()
        {
            return this.maxAmmo;
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
            this.ammo = this.maxAmmo;
            //set to 3 seconds reload time
            shootTimer.set(time, maxReloadTime);
            
        }

        //if player is stunned.
        public void stun(int stunTime)
        {
           
                PlayerState.setState(new StunnedState());
                shootTimer.set(time, stunTime);
            
        }
        //attempt to change the time it takes to reload
        public void powerUp(int amount)
        {
            this.maxReloadTime = amount;
        }
        
        //permanently increase max ammo after reload.
        public void increaseMaxAmmo(int amount)
        {
            this.maxAmmo += amount;
        }


        public Boolean canShoot()
        {
                     
            return PlayerState.getState().shoot();
        }

        //Allows player to report it's state.
        public string getState()
        {
            return PlayerState.getState().ToString();
        }


        public void  newGame(int lives)
        {
            score.resetScore();
            this.lives = lives;
            ammo = 20;
            time = 0;
            this.ammo = 20;
            this.maxAmmo = 20;
            shootTimer = new Timer();
            PlayerState = new PlayerContext();
            maxReloadTime = 3;
        }
        
        //will change the player back to normal firing state after a set amount of time.
        public void update(double time)
        {
            this.time = time;
            if (shootTimer.checkCompletion(time))
            {
                PlayerState.setState(new FiringState());
            }
        }
    }
}
