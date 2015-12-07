using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HunterGame;

namespace Tests
{
    [TestClass]
    public class ScoreTest
    {
        Score score = new Score();
        
        [TestMethod]
        public void gain_score()
        {
            score.gainScore(50);
            Assert.AreEqual(score.ScoreVal, 50);
        }
        [TestMethod]
        public void lose_score()
        {
            int origScore = score.ScoreVal;
            score.loseScore(30);
            Assert.AreEqual(score.ScoreVal, origScore - 30);
        }

        [TestMethod]
        public void reset_score()
        {

            score.resetScore();
            Assert.AreEqual(score.ScoreVal, 0);
        }

    }
}
