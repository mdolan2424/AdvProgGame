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
        public int gunCooldown { get; set; }


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
            this.damage = 1;
            score = new Score();
            
            
            time = 0;
            this.ammo = 20;
            this.maxAmmo = 20;
            shootTimer = new Timer();
            PlayerState = new PlayerContext();
            maxReloadTime = 3;
            
        }
        
        public void changeLives(int amount)
        {
            lives += amount;
        }
        
        public void shoot()
        {
            this.ammo -= 1;
            this.gunCooldown = 1;
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

        public void stun(int stunTime)
        {

                PlayerState.setState(new StunnedState());
                shootTimer.set(time, stunTime);
            
            
        }
        public void powerUp(int amount)
        {
            this.maxReloadTime = amount;
        }
        
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
