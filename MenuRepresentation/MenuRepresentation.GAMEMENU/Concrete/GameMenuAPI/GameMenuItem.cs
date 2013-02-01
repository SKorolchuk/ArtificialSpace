// -----------------------------------------------------------------------
// <copyright file="GameMenuItem.cs" company="">
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
	using Microsoft.Xna.Framework.Input;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class GameMenuItem : MenuItem, IGame
	{
		private Color selectedColor;

		private Color unselectedColor;

		private SpriteFont selectedFont;

		private SpriteFont unselectedFont;

		public Color TextColor { get; private set; }

		public SpriteFont Font { get; private set; }

		public event Action ElementSelected;

		public event Action ElementDeselected;

		public GameMenuItem(XElement ItemNode, IMenuable baseItm, Color color, SpriteFont font)
			: this(ItemNode, baseItm, color, color, font, font)
		{
		}

		public GameMenuItem(XElement ItemNode, IMenuable baseItm, Color color, Color selectedColor, SpriteFont font, SpriteFont selectedFont)
			: base(ItemNode, baseItm)
		{
			unselectedColor = TextColor = color;
			this.selectedColor = selectedColor;
			unselectedFont = Font = font;
			this.selectedFont = selectedFont;
			ElementSelected += () =>
				{ 
					Font = selectedFont;
					TextColor = selectedColor;
				};
			ElementDeselected += () =>
				{
					Font = unselectedFont;
					TextColor = unselectedColor;
				};
		}

		public void Update(GameTime time, IKeyStateCollection keyState)
		{
		}

		public void Draw(SpriteBatch sprite)
		{
			if (this.TypeOfTheItem == ItemType.MenuLetter)
			{
				sprite.DrawString(Font, this.Description, new Vector2(this.Position.X, this.Position.Y), TextColor);
			}
		}
	}
}
