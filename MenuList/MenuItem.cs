using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASpace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MenuList
{
    public class MenuItem : IGame
    {
        public readonly string Id;
        public readonly string Name;
        public readonly BehaviorFunc Behavior;

        public string Title { get; set; }

        public Vector2 Place { get; set; }

        private readonly Color textColor;

        public SpriteFont Font { get; set; }

        public Menu MotherMenu { get; set; }

        public Menu LinkedMenu { get; set; }

        private bool isLinked;

        public MenuItem(string title, Vector2 place, SpriteFont font, Color txtCol, Menu mother, Menu linked)
        {
            Title = title;
            Place = place;
            Font = font;
            textColor = txtCol;
            MotherMenu = mother;
            LinkedMenu = linked;
            isLinked = true;
        }

        public MenuItem(string title, Vector2 place, SpriteFont font, Color txtCol, Menu mother)
        {
            Title = title;
            Place = place;
            Font = font;
            textColor = txtCol;
            MotherMenu = mother;
            isLinked = false;
        }

        public MenuItem(string value, string place, string font)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spBatch, Color txtCol)
        {
            spBatch.DrawString(Font, Title, Place, txtCol);
        }

        public void Draw(SpriteBatch spBatch)
        {
            spBatch.DrawString(Font, Title, Place, textColor);
        }

        public Menu Push()
        {
            return this.isLinked ? this.LinkedMenu : null;
        }
    }
}
