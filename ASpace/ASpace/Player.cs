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
    //public class Player
    //{
    //    private bool Alive;

    //    private int Health;

    //    private Animation PlayerAnimation;

    //    // Initialize the player
    //    public void Initialize(Animation animation)
    //    {
    //        PlayerAnimation = animation;

    //        // Set the starting position of the player around the middle of the screen and to the back
    //        PlayerAnimation.Position = position;

    //        // Set the player to be active
    //        Alive = true;

    //        // Set the player health
    //        Health = 150;
            
    //    }

    //    // Draw the player
    //    public void Draw(SpriteBatch spriteBatch)
    //    {
    //        if (Alive)
    //        PlayerAnimation.Draw(spriteBatch);
    //    }

    //    // Update the player animation
    //    public void Update(GameTime gameTime)
    //    {
    //        PlayerAnimation.Update(gameTime);
    //    }

    //    public void InflictDamage(int dmg)
    //    {
    //        if ((Health - dmg) < 0) Alive = false;
    //        else Health -= dmg;
    //    }

    //    //public void 
    //}
    public class Player : GameObject, IGame
    {
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
