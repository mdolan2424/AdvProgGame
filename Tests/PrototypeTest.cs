using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HunterGame;

namespace Tests
{
    [TestClass]
    public class PrototypeTest
    {
        [TestMethod]
        public void PrototypeTestInitial()
        {
            //Instantiate
            SpawnerProto NewProto = new SpawnerProto();

            //Calls on the class that will return the cloned object of the 'Easy' Class
            //We display their hash code to show their different objects in memory as proof

            Console.Write("\nOur Clone Hash: " + NewProto.getClonedEnemy().GetHashCode());

            //Now display the hash code of the original
            Console.Write("\nOur Original: " + NewProto.getOriginal().GetHashCode());

        }
    }
}
