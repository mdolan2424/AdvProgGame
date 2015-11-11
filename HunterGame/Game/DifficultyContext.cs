using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class DifficultyContext: Observer
    {
        private DifficultyState diffState;
        private int mediumThreshold = 100;
        private int hardThreshold = 200;
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
            subject = score;
            diffState = new EasyState();

        }

        public override void update()
        {
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

        public DifficultyState getState()
        {
            return diffState;
        }
    }
}
