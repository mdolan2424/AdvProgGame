using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    /// <summary>
    /// Score class that inherits from the observable class
    /// used to store the score and is observed in order to update the difficulty state
    /// </summary>
    public class Score:Observable
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
        
        /// <summary>
        /// notify the observers of change
        /// </summary>
        public override void notify()
        {
            foreach(Observer obs in observerList)
            {
                obs.update();
            }
        }

        /// <summary>
        /// add score and call method to notify observes
        /// </summary>
        /// <param name="amount"></param>
        public void gainScore(int amount)
        {
            ScoreVal += amount;
            notify();
        }

        /// <summary>
        /// lose score and call method to notify observers
        /// </summary>
        /// <param name="amount"></param>
        public void loseScore(int amount)
        {
            ScoreVal -= amount;
        }

        /// <summary>
        /// reset score to zero for new games
        /// </summary>
        public void resetScore()
        {
            ScoreVal = 0;
            notify();
        }
    }
}
