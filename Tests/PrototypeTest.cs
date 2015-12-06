using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HunterGame;

namespace Tests
{
    [TestClass]
    public class PrototypeTest
    {
        [TestMethod]
        public void prototype_hash_return()
        {

            //Reate random operator to set some random bounds for our window which we pass into the spawner proto
            Random ran = new Random();
            int x = ran.Next(500, 1000);
            int y = ran.Next(500, 1000);

            //Instantiate
            SpawnerProto NewProto = new SpawnerProto(x, y);

            //Calls on the class that will return the cloned object of the enemy Class
            //We display their hash code to show their different objects in memory as proof

            Console.Write("\nOur Clone Hash: " + NewProto.spawnEnemy().GetHashCode());

            //Now display the hash code of the original
            Console.Write("\nOur Original: " + NewProto.getOriginal().GetHashCode());

        }
    }
}
