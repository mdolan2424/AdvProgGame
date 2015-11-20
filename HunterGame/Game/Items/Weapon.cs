using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Items
{
    class Weapon : IItem
    {
        private int Lives;
        public string name
        {
            get; set;
        }

        string IItem.image

        {
            get
            {
                return this.image;
            }
        }

        private string image;

        public Weapon()
        {
            this.Lives = 1;
            this.name = "Standard Rifle";
            image = "Graphics\\HuntingRifle";

        }

        public string getImage()
        {
            return this.image;
        }


        public int increaseLives()
        {
            return 0;
        }

        public int powerUp()
        {
            return 0;
        }

        public int weaponUpgrade()
        {
            return 1;
        }
    }

}
