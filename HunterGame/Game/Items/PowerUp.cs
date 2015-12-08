using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Items
{
    class PowerUp: IItem
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
        public PowerUp()
        {

            this.name = "Standard PowerUp";
            image = "Graphics\\greenpotion";

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

            return 1;
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
