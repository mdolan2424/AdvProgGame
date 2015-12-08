

using HunterGame.Game.Players;
using HunterGame.Game.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestLifeItem()
        {
            
            Player player1 = new Player(4);
            LifePotion potion = new LifePotion();
            
            player1.changeLives(potion.increaseLives());
            Assert.AreEqual(5, player1.lives);
            
        }

        [TestMethod]
        public void TestPowerUp()
        {
            Player player1 = new Player(4);
            PowerUp powerup = new PowerUp();
            player1.powerUp(powerup.powerUp());
            Assert.AreEqual(player1.getMaxReloadTime(), 1);

        }

        [TestMethod]
        public void TestBadPowerUp()
        {
            Player player1 = new Player(4);

            IItem powerup = new BadPowerUp();
            player1.stun(powerup.stun());
            
            Assert.AreEqual(false, player1.canShoot());
            

        }

        [TestMethod]

        public void TestWeapon()
        {
            Player player1 = new Player(4);
            int ammo = player1.ammo;
            Weapon weapon = new Weapon();
            player1.increaseMaxAmmo(weapon.weaponUpgrade());
            Assert.AreEqual(ammo+5, player1.getMaxAmmo());

        }
    }
}
