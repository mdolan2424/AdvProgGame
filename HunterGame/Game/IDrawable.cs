using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace HunterGame.Game
{
    public interface IDrawable
    {
        void Draw(Microsoft.Xna.Framework.Game game, SpriteBatch spriteBatch);
        void Update(GameTime gametime);
    }
}
