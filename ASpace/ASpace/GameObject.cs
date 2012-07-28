using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    public abstract class GameObject
    {
        internal Animation Animation;
        internal int HP;
        internal bool Alive;
        public void InflictDamage(int dmg)
        {
            if ((HP - dmg) < 0) Alive = false;
            else HP -= dmg;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract void Move(int value, Animation.Way way, Rectangle display);
    }
}
