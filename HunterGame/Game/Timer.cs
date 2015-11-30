using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace HunterGame.Game
{
    class Timer
    {
        private Boolean isActive;
        private double start;
        private double stop;
        public Boolean isDone;
        public Timer()
        {
            this.isActive = false;
            this.start = 0;
            this.stop = 0;
            this.isDone = false;

        }

        public Boolean getActivation()
        {
            return isActive;
        }
        public void set(double gametime, int seconds)
        {
            this.isActive = true;
            this.start = gametime;
            this.stop = this.start + seconds;
            

        }

        public Boolean checkCompletion(double gametime)
        {
            if (gametime > this.stop)
            {

                return true;
            }

            return false;
        }
    }
}
