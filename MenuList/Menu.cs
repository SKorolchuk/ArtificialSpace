using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MenuList
{
    public delegate void BehaviorFunc(GameTime gameTime, SpriteBatch spriteBatch, Game game);

    /// <summary>
    /// This class represents Menu for XNA-platform based apps
    /// Menu class used XML Markup
    /// </summary>
    public class Menu
    {
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

        private readonly XDocument menuDocument;
        private IEnumerable<XElement> rootElements;
        public string Name { get; private set; }
        public List<MenuItem> menuItems { get; private set; }

        public Menu(string Uri)
        {
            try
            {
                menuDocument = XDocument.Load(Uri);
                XElement xElement = menuDocument.Element("Menu");
                rootElements = xElement.Elements();
                Name = xElement.Attribute("name").Value;
                menuItems = new List<MenuItem>();
                foreach (XElement element in rootElements)
                {
                    menuItems.Add(new MenuItem(element.Attribute("id").Value, 
                                                element.Attribute("name").Value,
                                                element.Attribute("behavior").Value));
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Menu(Vector2 position, int height, int width, Texture2D tex, string title, SpriteFont font)
        {
            Position = position;
            Place = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            BackTex = tex;
            Title = title;
            menuItems = new List<MenuItem>();
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
            menuItems = new List<MenuItem>();
            fontOfTitle = font;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in menuItems)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spBatch)
        {
            spBatch.Draw(BackTex, Place, Color.White);
            spBatch.DrawString(fontOfTitle, Title, new Vector2(Place.X, Place.Y - 20), Color.White);
            foreach (var item in menuItems)
            {
                if (menuItems.IndexOf(item) == SelectedIndex) item.Draw(spBatch);
                else item.Draw(spBatch, UnselectedColor);
            }
        }

        public void AddMenuItem(string title, int height, int width, Color cl, SpriteFont font, Menu link)
        {
            menuItems.Add(new MenuItem(title, new Vector2(Position.X + width, Position.Y + height * menuItems.Count), font, cl, this, link));
        }

        public void AddMenuItem(string title, int height, int width, Color cl, SpriteFont font)
        {
            menuItems.Add(new MenuItem(title, new Vector2(Position.X + width, Position.Y + height * menuItems.Count), font, cl, this));
        }

        public Menu PushResult()
        {
            return menuItems[SelectedIndex].Push();
        }
    }
}
