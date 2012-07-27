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

        public TimeSpan TimeOfLiving;

        public bool Alive;

        public SoundEffect VisualEffectSound;

        public void Initialize()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public Effect()
        {
        }
    }
}
