using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    class Score:Observable
    {
        private int score;
        public int ScoreVal{
            get { return score;}
            set { score = value; }
        }

        public Score()
        {
            observerList = new List<Observer>();

        }
        
        public override void notify()
        {
            foreach(Observer obs in observerList)
            {
                obs.update();
            }
        }
        public void gainScore(int amount)
        {

        }
        public void loseScore(int amount)
        {

        }
    }
}
