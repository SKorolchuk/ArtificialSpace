using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASpace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ASpace
{
    public class Player : GameObject, IGame
    {
        private Texture2D leftTex;
        private Texture2D rightTex;
        private Texture2D commonTex;

        public Player(Animation animation, Texture2D leftTexture, Texture2D rightTexture)
        {
            this.Initialize(animation, leftTexture, rightTexture);
        }

		public Player(){}

        // Initialize the player
        public void Initialize(Animation animation, Texture2D leftTexture, Texture2D rightTexture)
        {
            base.Animation = animation;

            // Set the player to be active
            Alive = true;

            // Set the player health
            base.HP = 150;

            commonTex = animation.ObjectTexture;
            leftTex = leftTexture;
            rightTex = rightTexture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Alive)
                base.Animation.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Animation.Update(gameTime);
        }

        public override void Move(int value, Animation.Way way, Rectangle display)
        {
            if (way == Animation.Way.Left)
            {
                Animation.ObjectTexture = leftTex;
            }
            if (way == Animation.Way.Right)
            {
                Animation.ObjectTexture = rightTex;
            }
            if (way == Animation.Way.Down || way == Animation.Way.Up)
            {
                Animation.ObjectTexture = commonTex;
            }
            Animation.Move(value, way, display);
        }
    }
}
