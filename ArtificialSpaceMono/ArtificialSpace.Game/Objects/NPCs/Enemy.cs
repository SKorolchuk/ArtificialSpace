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
        public Enemy(Animation animation, Vector2 angle)
        {
			this.Initialize(animation, angle);
        }

		public void Initialize(Animation animation, Vector2 angle)
		{
			this.Animation = animation;
			this.Animation.angle = angle;
			
			Alive = true;

			base.HP = 150;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			if (Alive)
				Animation.Draw(spriteBatch);
		}

		public override void Move(int value, Animation.Way way, Rectangle display)
		{
			Animation.Move(value, way, display);
		}

		public override void Update(GameTime gameTime)
		{
			Animation.Update(gameTime);
		}
    }
}
