using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    public class Enemy : Player
    {
        public Enemy(Animation animation, Texture2D leftTexture, Texture2D rightTexture) : base(animation, leftTexture, rightTexture)
        {
        }
    }
}
