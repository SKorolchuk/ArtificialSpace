using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    using Microsoft.Xna.Framework.Audio;

    //public class Missle
    //{
    //    public bool Alive;

    //    public int Angle;

    //    public int RemoveValue;

    //    public int Speed;

    //    public Animation MissleAnimation;

    //    public Player Owner;

    //    public SoundEffect MissleEffect;

    //    // Initialize the player
    //    public void Initialize(Animation animation, Vector2 position, int inflictDmg, float angle, int speed, Player owner, SoundEffect explosionEffect)
    //    {
    //        MissleAnimation = animation;

    //        // Set the starting position of the player around the middle of the screen and to the back
    //        MissleAnimation.Position = position;

    //        // Set the player to be active
    //        Alive = true;
    //        MissleAnimation.Angle = angle;

    //        // Set the player health
    //        RemoveValue = inflictDmg;

    //        Speed = speed;
    //        this.Owner = owner;
    //        this.MissleEffect = explosionEffect;
    //    }

    //    // Draw the player
    //    public void Draw(SpriteBatch spriteBatch)
    //    {
    //        if (Alive)
    //                 MissleAnimation.Draw(spriteBatch);
    //    }

    //    // Update the player animation
    //    public void Update(GameTime gameTime)
    //    {
    //        if (!Alive) return;
    //        MissleAnimation.Update(gameTime);
    //        if (MissleAnimation.Angle == 0)
    //            MissleAnimation.Position.Y-=Speed;
    //        if (MissleAnimation.Angle == 1)
    //            MissleAnimation.Position.X+=Speed;
    //        if (MissleAnimation.Angle == 2)
    //            MissleAnimation.Position.Y+=Speed;
    //        if (MissleAnimation.Angle == 3)
    //            MissleAnimation.Position.X-=Speed;
    //    }
    //}
}
