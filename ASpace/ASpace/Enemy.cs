using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASpace
{
    public class Enemy : GameObject, IGame
    {
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Move(int value, Animation.Way way, Microsoft.Xna.Framework.Rectangle display)
        {
            throw new NotImplementedException();
        }
    }
}
