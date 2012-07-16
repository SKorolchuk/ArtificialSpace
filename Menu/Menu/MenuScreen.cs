using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Menu
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MenuScreen : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Contains space of action screen
        /// </summary>
        private Rectangle GameScreenRect;

        /// <summary>
        /// Represent menu items
        /// </summary>
        private Menu ScreenMenu;

        private Texture2D BackGround;

        private SpriteFont mainFont;

        private SpriteFont backFont;

        private KeyboardState CurState;

        private KeyboardState PrevState;

        private int selectedindex;

        private const int lim = 1;

        public MenuScreen()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1366;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            BackGround = Content.Load<Texture2D>(@"Tex\MainScreen");
            GameScreenRect = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            mainFont = Content.Load<SpriteFont>(@"Fonts\TitleFont");
            backFont = Content.Load<SpriteFont>(@"Fonts\MenuItemFont");
            ScreenMenu = new Menu(new Vector2(1366 / 2, 768 / 2), 300, 300, Content.Load<Texture2D>(@"Tex\Red"), "Hello", mainFont);
            ScreenMenu.AddMenuItem("hello1", 40, 20, Color.Cyan, backFont);
            ScreenMenu.AddMenuItem("hello2", 60, 20, Color.Cyan, backFont);
            selectedindex = 1;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            CurState = Keyboard.GetState();
            // Allows the game to exit
            if (CurState.IsKeyUp(Keys.Q) && PrevState.IsKeyDown(Keys.Q))
                this.Exit();
            if (CurState.IsKeyUp(Keys.Up) && PrevState.IsKeyDown(Keys.Up) && ((ScreenMenu.SelectedIndex - 1) >= 0)) ScreenMenu.SelectedIndex--;
            if (CurState.IsKeyUp(Keys.Down) && PrevState.IsKeyDown(Keys.Down) && ((ScreenMenu.SelectedIndex + 1) <= lim)) ScreenMenu.SelectedIndex++;
            // TODO: Add your update logic here
            ScreenMenu.Update(gameTime);
            PrevState = CurState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
            spriteBatch.Begin();
            spriteBatch.Draw(BackGround, GameScreenRect, Color.White);
            ScreenMenu.Draw(spriteBatch);
            //spriteBatch.DrawString(mainFont, "Title Item", new Vector2(GameScreenRect.Width/2+80, GameScreenRect.Height/2), Color.DarkGray);
            //spriteBatch.DrawString(mainFont, gameTime.TotalGameTime.Milliseconds.ToString(), new Vector2(10, 10), Color.White);
            //if (selectedindex == 1) spriteBatch.DrawString(mainFont, "menu Item 1", new Vector2(GameScreenRect.Width / 2 + 80, GameScreenRect.Height / 2+40), Color.GreenYellow);
            //else
            //{
            //    spriteBatch.DrawString(mainFont, "menu Item 1", new Vector2(GameScreenRect.Width / 2 + 80, GameScreenRect.Height / 2+40), Color.Green);
            //}
            //if (selectedindex == 2) spriteBatch.DrawString(mainFont, "menu Item 2", new Vector2(GameScreenRect.Width / 2 + 80, GameScreenRect.Height / 2+80), Color.GreenYellow);
            //else
            //{
            //    spriteBatch.DrawString(mainFont, "menu Item 2", new Vector2(GameScreenRect.Width / 2 + 80, GameScreenRect.Height / 2+80), Color.Green);
            //}
            //if (selectedindex == 3) spriteBatch.DrawString(mainFont, "menu Item 3", new Vector2(GameScreenRect.Width / 2 + 80, GameScreenRect.Height / 2+120), Color.GreenYellow);
            //else
            //{
            //    spriteBatch.DrawString(mainFont, "menu Item 3", new Vector2(GameScreenRect.Width / 2 + 80, GameScreenRect.Height / 2+120), Color.Green);
            //}
            spriteBatch.End();
        }
    }
}
