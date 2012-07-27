// -----------------------------------------------------------------------
// <copyright file="Menu.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MS.Internal.Xml.XPath;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// represent all menu items of current menu object
        /// </summary>
        public List<MenuItem> GameMenuItems { get; set; }

        /// <summary>
        /// title of current menu
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// high-left start position of menu
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// place when menu can be placed
        /// </summary>
        public Rectangle Place { get; set; }

        /// <summary>
        /// background texture {not necessary}
        /// </summary>
        public Texture2D BackTex { get; set; }

        public int SelectedIndex { get; set; }

        public Color UnselectedColor { get; set; }

        private SpriteFont fontOfTitle;

        public Menu(Vector2 position, int height, int width, Texture2D tex, string title, SpriteFont font)
        {
            Position = position;
            Place = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            BackTex = tex;
            Title = title;
            GameMenuItems = new List<MenuItem>();
            fontOfTitle = font;
            UnselectedColor = Color.White;
            SelectedIndex = 0;
        }

        public void Initialize(Vector2 position, int height, int width, Texture2D tex, string title, SpriteFont font)
        {
            Position = position;
            Place = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            BackTex = tex;
            Title = title;
            GameMenuItems = new List<MenuItem>();
            fontOfTitle = font;
        }

        

        public void Update(GameTime gameTime)
        {
            foreach (var item in GameMenuItems)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spBatch)
        {
            spBatch.Draw(BackTex, Place, Color.White);
            spBatch.DrawString(fontOfTitle, Title, new Vector2(Place.X, Place.Y-20), Color.White);
            foreach ( var item in GameMenuItems)
            {
                if (GameMenuItems.IndexOf(item) == SelectedIndex) item.Draw(spBatch);
                else item.Draw(spBatch, UnselectedColor);
            }
        }

        public void AddMenuItem(string title, int height, int width, Color cl, SpriteFont font, Menu link)
        {
            GameMenuItems.Add(new MenuItem(title, new Vector2(Position.X+width, Position.Y+height*GameMenuItems.Count), font, cl, this, link));
        }

        public void AddMenuItem(string title, int height, int width, Color cl, SpriteFont font)
        {
            GameMenuItems.Add(new MenuItem(title, new Vector2(Position.X + width, Position.Y + height * GameMenuItems.Count), font, cl, this));
        }

        public Menu PushResult()
        {
            return GameMenuItems[SelectedIndex].Push();
        }
    }
}
