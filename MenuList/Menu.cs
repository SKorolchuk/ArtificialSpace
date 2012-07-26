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
    /// <summary>
    /// This class represents Menu for XNA-platform based apps
    /// Menu class used XML Markup
    /// </summary>
    public class Menu
    {
        public delegate void BehaviorFunc(GameTime gameTime, SpriteBatch spriteBatch, Game game);

        internal static class Commander
        {
             public static BehaviorFunc Process(string cmd)
             {
                 switch (cmd)
                 {
                     case "LAUNCH":
                         return ((time, batch, game) => {});
                         break;
                     case "EXIT":
                         return ((time, batch, game) => { game.Exit();});
                         break;
                     default:
                         break;
                 }
                 return ((time, batch, game) => { });
             }
        }

        public class MenuItem
        {
            
            public readonly string Id;
            public readonly string Name;
            public readonly BehaviorFunc Behavior;
            public MenuItem(string id, string name, string behavior)
            {
                Id = id;
                Name = name;
                Behavior = Commander.Process(behavior);
            }
        }

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
    }
}
