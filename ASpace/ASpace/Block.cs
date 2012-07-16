using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    public class Block
    {
        public Texture2D Texture;
        public Rectangle Place;
        public int HP;

        public Block(Texture2D texture, Rectangle placement, int hp)
        {
            Texture = texture;
            Place = placement;
            HP = hp;
        }
    }
}
