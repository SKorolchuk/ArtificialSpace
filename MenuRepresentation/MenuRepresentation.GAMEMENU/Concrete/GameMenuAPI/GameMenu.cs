// -----------------------------------------------------------------------
// <copyright file="GameMenu.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.GAMEMENU
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml.Linq;

	using MenuRepresentation.DOMAIN.MenuDOM.Abstract;
	using MenuRepresentation.DOMAIN.MenuDOM.Internal;
	using MenuRepresentation.DOMAIN.MenuDOM.Model;

	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class GameMenu : Menu, IGame
	{
		private Color unselectedColor;

		protected Color selectedColor;

		private SpriteFont unselectedFont;

		private SpriteFont selectedFont;

		public IMenuable SelectedItem { get; private set; }

		public int ListPosition { get; private set; }

		public int PositionCount
		{
			get
			{
				return this.NestedItems.Count;
			}
		}

		public GameMenu(XDocument doc, Color color, SpriteFont font)
			: this(doc, color, color, font, font)
		{
		}

		public GameMenu(XDocument doc, Color color, Color selectedColor, SpriteFont font, SpriteFont selectedFont)
			: base(doc)
		{
			unselectedColor = TextColor = color;
			this.selectedColor = selectedColor;
			unselectedFont = Font = font;
			this.selectedFont = selectedFont;
		}

		public SpriteFont Font { get; private set; }

		public Color TextColor { get; private set; }

		public void Update(GameTime time, IKeyStateCollection keyState)
		{
			throw new NotImplementedException();
		}

		public void Draw(SpriteBatch sprite)
		{
			if (this.TypeOfTheItem == ItemType.Menu)
			{
				sprite.DrawString(Font, this.Title, new Vector2(this.Position.X, this.Position.Y), TextColor);
			}

			foreach (GameMenuItem item in NestedItems)
			{
				item.Draw(sprite);
			}
			
		}

		public override void LoadItem(XElement ItemNode)
		{
			foreach (XElement item in ItemNode.Elements())
			{
				this.NestedItems.Add(new GameMenuItem(item, this, TextColor, Font));
			}
		}
	}
}
