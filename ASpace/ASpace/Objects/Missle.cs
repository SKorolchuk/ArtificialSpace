using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ASpace
{
    using Microsoft.Xna.Framework.Audio;

    public class Missle
    {
        public bool Alive;

        public int RemoveValue;

        public int Speed;

        public Animation MissleAnimation;

        private MouseState mouse;

        // Initialize the player
        public void Initialize(Animation animation, int inflictDmg, Vector2 angle, int speed, Vector2 basis)
        {
            MissleAnimation = animation;

            // Set the player to be active
            Alive = true;
            MissleAnimation.angle = angle;

            // Set the player health
            RemoveValue = inflictDmg;

            Speed = speed;
            MissleAnimation.speed = speed;
            MissleAnimation.angle = basis;
        }

        // Draw the player
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Alive)
                MissleAnimation.Draw(spriteBatch);
        }

        // Update the player animation
        public void Update(GameTime gameTime)
        {
            if (!Alive) return;
            MissleAnimation.Update(gameTime);
            MissleAnimation.Going();
           // MissleAnimation.Going(Speed);
        }
    }
}
