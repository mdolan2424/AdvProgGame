using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    /// <summary>
    /// Difficulty context to store the difficulty state, observe the score for change
    /// and update the dificulty state accordingly
    /// </summary>
    public class DifficultyContext: Observer
    {

        private DifficultyState diffState;

        //set the thresholds for changing the difficulty
        private const int mediumThreshold = 100;
        private const int hardThreshold = 200;

        //getters for the thresholds
        public int MediumThreshold
        {
            get {return mediumThreshold; }
        }
        public int HardThreshold
        {
            get { return hardThreshold; }
        }
        
        public DifficultyContext(Score score)
        {
            //Set the subject for the observer to be the score
            subject = score;
            //Set the initial state to Easy
            diffState = new EasyState();

        }
        /// <summary>
        /// update to be called when the observable (the score) notifies the observer (difficulty context) 
        /// of a change in the score.
        /// </summary>
        public override void update()
        {
            //check if the thresholds have been reached and change state if they have
            if(((Score)subject).ScoreVal>hardThreshold)
            {
                diffState = new HardState();
            }
            else if(((Score)subject).ScoreVal>mediumThreshold)
            {
                diffState = new MediumState();
            }
            else
            {
                diffState = new EasyState();
            }
        }

        /// <summary>
        /// gets the current state of the difficulty
        /// </summary>
        /// <returns></returns>
        public DifficultyState getState()
        {
            return diffState;
        }
    }
}
