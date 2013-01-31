using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASpace
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	public class World : IGame
    {
		private Game gameObj;

		internal Rectangle GameScreenRect;

		internal Sprite simpleSprite;

		internal SpriteText simpleText;

		internal Vector2 ShiftOfBack;

		internal Texture2D mainBackground;
		
		internal string TerminalMsg = string.Empty;

		public World(GamePlayGameLayer game)
		{
			this.gameObj = game;
		}

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
			spriteBatch.Draw(mainBackground, new Vector2(0, 0), new Rectangle((int)(-ShiftOfBack.X), (int)(-ShiftOfBack.Y), mainBackground.Width, mainBackground.Height), Color.White);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
			UpdateParallax();
			RecalcTerminal();
        }

		private void UpdateParallax()
		{
			if (ShiftOfBack.X < 0)
			{
				ShiftOfBack.X += mainBackground.Width;
			}
			else if (ShiftOfBack.X >= mainBackground.Width)
			{
				ShiftOfBack.X -= mainBackground.Width;
			}
			if (ShiftOfBack.Y < 0)
			{
				ShiftOfBack.Y += mainBackground.Height;
			}
			else if (ShiftOfBack.Y >= mainBackground.Height)
			{
				ShiftOfBack.Y -= mainBackground.Height;
			}
			ShiftOfBack.Y += 10;
		}

		void RecalcTerminal()
		{
			string[] terminalColocations = TerminalMsg.Split('\n');
			TerminalMsg = string.Empty;
			for (int i = ((terminalColocations.Length - 5) > 0) ? terminalColocations.Length - 5 : 0; i < terminalColocations.Length; i++)
			{
				if (terminalColocations[i].Length > 1)
				{
					TerminalMsg += string.Format("{0}\n", terminalColocations[i]);
				}
			}
		}
    }
}
