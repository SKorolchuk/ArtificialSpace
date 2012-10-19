using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASpace
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Audio;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework.Input;
	using Microsoft.Xna.Framework.Media;

	public class MenuGameLayer : GamePlayGameLayer
	{
		private MouseState currentMouseState;
		private MouseState prevMouseState;

		private KeyboardState currentKeyState;
		private KeyboardState prevKeyState;

		public bool GameStarted = false;

		public MenuGameLayer() : base()
        {
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
			base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (GameStarted) base.Draw(gameTime);
            else
            {
	            spriteBatch.Begin();
				spriteBatch.DrawString(Resources.Fonts["Title"], "Press Enter!", new Vector2(map.GameScreenRect.Width/2f -100f, map.GameScreenRect.Height/2f-20f), Color.White);
				spriteBatch.End();
            }
        }
    }
}
