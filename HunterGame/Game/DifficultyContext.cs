using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    class DifficultyContext: Observer
    {
        private DifficultyState diffState;
        public DifficultyContext(Score score)
        {
            subject = score;

        }

        public override void update()
        {
            
        }
    }
}
