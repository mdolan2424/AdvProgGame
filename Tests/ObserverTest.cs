using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HunterGame;

namespace Tests
{
    [TestClass]
    public class ObserverTest
    {
        Score score = new Score();
        DifficultyContext diffCtxt; 
       
        [TestMethod]
        public void score_registers_osbservers()
        {
            diffCtxt = new DifficultyContext(score);
            int initialLength = score.ObserverList.Count;
            score.register(diffCtxt);
            Assert.AreEqual(initialLength + 1, score.ObserverList.Count);
            
        }

        [TestMethod]
        public void score_notifies_observers_easy()
        {
            diffCtxt = new DifficultyContext(score);
            score.register(diffCtxt);
            score.gainScore(10);
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(EasyState));
        }

        [TestMethod]
        public void score_notifies_observers_medium()
        {
            diffCtxt = new DifficultyContext(score);
            score.register(diffCtxt);
            score.gainScore(diffCtxt.MediumThreshold + 10);
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(MediumState));
        }

        [TestMethod]
        public void score_notifies_observers_hard()
        {
            diffCtxt = new DifficultyContext(score);
            score.register(diffCtxt);
            score.gainScore(diffCtxt.HardThreshold + 10);
            Assert.IsInstanceOfType(diffCtxt.getState(), typeof(HardState));
        }

        [TestMethod]
        public void score_unregisters_observer()
        {
            diffCtxt = new DifficultyContext(score);
            score.register(diffCtxt);
            int initialLength = score.ObserverList.Count;
            score.unregister(diffCtxt);
            Assert.AreEqual(initialLength-1, score.ObserverList.Count);
        }
    }
}
