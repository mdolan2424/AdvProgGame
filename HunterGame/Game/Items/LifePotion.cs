using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Items
{
    class LifePotion : IItem
    {
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
        
        public LifePotion()
        {
            
            this.name = "Life Increase";
            image = "Graphics\\heart";

        }

        public string getImage()
        {
            return this.image;
        }

        
        public int increaseLives()
        {
            return 1;
        }

        public int powerUp()
        {
            return 3;
        }

        public int weaponUpgrade()
        {
            return 0;
        }

        public int stun()
        {
            return 0;
        }
    }
}
