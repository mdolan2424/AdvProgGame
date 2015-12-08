using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HunterGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Tests
{
    [TestClass]
    public class ControllerTest
    {
        static int testWidth = 1000;
        static int testHeight = 1000;
        GameController controller = new GameController(testWidth,testHeight);

        [TestMethod]
        public void spawn_enemy()
        {
            controller.spawnEnemy();
            Assert.AreEqual(controller.EnemiesOnScreen.Count, 1);
        }
        [TestMethod]
        public void update_enemy()
        {
            controller.spawnEnemy();
            Vector2 pt = controller.EnemiesVector[0];
            controller.updateEnemies();
            Assert.AreNotEqual(controller.EnemiesVector[0].X, pt.X);
            Assert.AreNotEqual(controller.EnemiesVector[0].Y, pt.Y);

        }

        [TestMethod]
        public void create_destination()
        {
            Vector2 dest = controller.createDestination(0,0);
            Assert.IsTrue(dest.X <= testWidth && dest.X >=0, "Destination Off Screen");
            Assert.IsTrue(dest.Y <= testHeight && dest.Y >= 0, "Destination Off Screen");
            Assert.IsTrue(dest.X != 0 || dest.Y != 0, "Destination is the same as initial point");
        }

        [TestMethod]
        public void check_lives()
        {
           Assert.IsTrue(controller.checkLives());

        }

        [TestMethod]
        public void get_score()
        {
            Assert.AreEqual(controller.getScore(), 0);
        }

        [TestMethod]
        public void get_lives()
        {
            Assert.AreEqual(controller.getLives(), 3);
        }

        [TestMethod]
        public void get_ammo()
        {
            Assert.AreEqual("20", controller.getAmmo());
        }
        
    }
}
