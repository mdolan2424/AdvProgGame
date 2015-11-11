using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HunterGame;

namespace Tests
{
    [TestClass]
    public class DifficultyStateTest
    {
        Score score = new Score();
        DifficultyContext diffCtxt;
        
        [TestMethod]
        public void difficultyState_getState()
        {
            diffCtxt = new DifficultyContext(score);
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(DifficultyState));
        }

        [TestMethod]
        public void difficultyState_update_easy()
        {
            diffCtxt = new DifficultyContext(score);
            diffCtxt.update();
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(EasyState));

        }
        
        [TestMethod]
        public void difficultyState_update_medium()
        {
            diffCtxt = new DifficultyContext(score);
            score.ScoreVal += diffCtxt.MediumThreshold+10;
            diffCtxt.update();
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(MediumState));

        }

        [TestMethod]
        public void difficultyState_update_hard()
        {
            diffCtxt = new DifficultyContext(score);
            score.ScoreVal += diffCtxt.HardThreshold +10;
            diffCtxt.update();
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(HardState));

        }
    }
}
