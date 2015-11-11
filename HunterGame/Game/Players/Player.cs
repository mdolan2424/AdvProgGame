using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
namespace HunterGame
{
    public class Player
    {
        private string name;
        public int lives { get; set; }
        private int power;
        private Score score;
        public Score PlayerScore
        {
            get { return score; }
        }

        //player state changes
        private PlayerContext status;
        

        public Player(int lives)
        {
            name = "";
            this.lives = lives;
            this.power = 0;
            score = new Score();
            
        }

        public void useItem(int item)
        {
            ItemFactory itemFac = new ItemFactory();
            IItem tempItem = itemFac.getItem(item);
            tempItem.apply(this);
        }
      
        public void changeLives(int amount)
        {
            lives += amount;
        }
        
        public void changePower(int amount)
        {
            power += amount;
        }



    }
}
