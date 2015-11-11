using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace HunterGame.Game.Items
{
    public class LifePotion : IItem
    {
        public int worth;
        public string name
        {
            get;    
        }
        public Texture2D texture;
        public Vector2 position;
        public LifePotion()
        {
            this.worth = 1;
            this.name = "Standard Life Potion";
            position = new Vector2(300, 400);
            
        }
        
        public void apply(Player player)
        {
            player.changeLives(worth);
        }

        public void Draw(Microsoft.Xna.Framework.Game game, SpriteBatch spritebatch)
        {
            
            spritebatch.Draw(game.Content.Load<Texture2D>("Graphics\\red-potion"), position);
            
            
        }
        public void Update(GameTime gametime)
        {
            
        }
    }
}
