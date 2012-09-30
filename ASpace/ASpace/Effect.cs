// -----------------------------------------------------------------------
// <copyright file="Effect.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ASpace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Effect : IGame
    {
        public Animation EffectAnimation;

        public int TimeOfLiving;

        public bool Alive;

        public SoundEffect VisualEffectSound;

        public int SpawnMillisec = 0;

        public void Initialize(Animation anim, int timeOflife, SoundEffect sound)
        {
            this.EffectAnimation = anim;
            this.TimeOfLiving = timeOflife;
            VisualEffectSound = sound;
            Alive = true;
            VisualEffectSound.Play();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Alive)
                EffectAnimation.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (SpawnMillisec == 0)
                SpawnMillisec = gameTime.TotalGameTime.Milliseconds;
            if ((Math.Abs(gameTime.TotalGameTime.Milliseconds - SpawnMillisec)) >= TimeOfLiving)
                Alive = false;
            if (Alive)
            {
                EffectAnimation.Update(gameTime);
            }
        }
    }
}
