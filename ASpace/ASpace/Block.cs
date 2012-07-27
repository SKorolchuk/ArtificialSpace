using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASpace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    public class Block : GameObject
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
