using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ASpace
{
    public class Animation : IGame
    {
        #region private fields
        Texture2D spriteStrip;

        float scale;

        int elapsedTime;

        int frameTime;

        int frameCount;

        int currentFrame;

        Color color;

        private Rectangle sRect;

        private Rectangle destRect;

        private int frameWidth;

        private int frameHeight;

        private bool active;

        private bool looping;

        private Vector2 position;
        private float angle;
        #endregion

        #region public fields
        /// <summary>
        /// Gets Position of Animation Object.
        /// </summary>
        public Vector2 Position { get { return position; } }

        /// <summary>
        /// Gets Destination Rectangle.
        /// </summary>
        public Rectangle Destination{ get { return destRect; } }

        public bool AnimationState
        { 
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        #endregion

        #region public methods
        public Animation(Texture2D texture, Vector2 position,
        int frameWidth, int frameHeight, int frameCount,
        int frametime, Color color, float scale, bool looping)
        {
            // Keep a local copy of the values passed in
            this.color = color;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            this.looping = looping;
            this.position = position;
            spriteStrip = texture;

            // Set the time to zero
            elapsedTime = 0;
            currentFrame = 0;

            sRect = new Rectangle();
            destRect = new Rectangle();

            // Set the Animation to active by default
            this.active = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(spriteStrip, destRect, sRect, color);
        }

        public void Initialize(Texture2D texture, Vector2 position,
        int frameWidth, int frameHeight, int frameCount,
        int frametime, Color color, float scale, bool looping)
        {
            // Keep a local copy of the values passed in
            this.color = color;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            this.looping = looping;
            this.position = position;
            spriteStrip = texture;

            sRect = new Rectangle();
            destRect = new Rectangle();

            // Set the time to zero
            elapsedTime = 0;
            currentFrame = 0;

            // Set the Animation to active by default
            this.active = true;
        }

        public void Update(GameTime gameTime)
        {
            // Do not update the game if we are not active
            if (this.active == false)
            {
                sRect.X = (int)angle * 2 * frameWidth;
                sRect.Y = 0;
                sRect.Width = frameWidth;
                sRect.Height = this.frameHeight;
                destRect.X = (int)this.position.X - (int)(frameWidth * scale) / 2;
                destRect.Y = (int)this.position.Y - (int)(this.frameHeight * scale) / 2;
                destRect.Width = (int)(frameWidth * scale);
                destRect.Height = (int)(this.frameHeight * scale);
                return;
            }
            // Update the elapsed time
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            // If the elapsed time is larger than the frame time
            // we need to switch frames
            if (elapsedTime > frameTime)
            {
                // Move to the next frame
                currentFrame++;

                // If the currentFrame is equal to frameCount reset currentFrame to zero
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    // If we are not looping deactivate the animation
                    if (this.looping == false)
                        this.active = false;
                }

                // Reset the elapsed time to zero
                elapsedTime = 0;
            }

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            sRect.X = (int)angle * frameWidth * 2 + currentFrame * frameWidth;
            sRect.Y = 0;
            sRect.Width = frameWidth;
            sRect.Height = this.frameHeight;
            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            destRect.X = (int)this.position.X - (int)(frameWidth * scale) / 2;
            destRect.Y = (int)this.position.Y - (int)(this.frameHeight * scale) / 2;
            destRect.Width = (int)(frameWidth * scale);
            destRect.Height = (int)(this.frameHeight * scale);
        }
        #endregion

        #region private methods
        #endregion
    }
}
