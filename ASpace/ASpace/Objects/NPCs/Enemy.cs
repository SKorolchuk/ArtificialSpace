using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
	using Microsoft.Xna.Framework;

	public class Enemy : Player
    {
        public Enemy(Animation animation, Texture2D leftTexture, Texture2D rightTexture, Vector2 angle) : base(animation, leftTexture, rightTexture)
        {
	        this.Animation.angle = angle;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public override void Move(int value, Animation.Way way, Rectangle display)
		{
			base.Move(value, way, display);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
    }
}
