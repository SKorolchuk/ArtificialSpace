using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ASpace
{
    public class GamePlayGameLayer : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Contains space of action screen
        /// </summary>
        internal Rectangle GameScreenRect;

        internal KeyboardState CurState;

        internal KeyboardState PrevState;

        internal Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        internal Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();

        internal Dictionary<string, Song> Music = new Dictionary<string, Song>();

        internal Dictionary<string, Texture2D> Effects = new Dictionary<string, Texture2D>(); 

        private Random randomizer = new Random(DateTime.Now.Millisecond);

        private Player ship;

        public GamePlayGameLayer()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1366;
            GameScreenRect = new Rectangle(0,0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
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
            #region Load Content
            #region Load Textures
            Textures.Add("MainBackGround", Content.Load<Texture2D>(@"Tex\MainBackGround"));
            Textures.Add("BackGroundSparks", Content.Load<Texture2D>(@"Tex\BackGroundSparks"));
            Textures.Add("Asteroid2", Content.Load<Texture2D>(@"Tex\Asteroid2"));
            Textures.Add("Hole", Content.Load<Texture2D>(@"Tex\Hole"));
            Textures.Add("PlayerUp", Content.Load<Texture2D>(@"Tex\PlayerUp"));
            Textures.Add("PlayerLeft", Content.Load<Texture2D>(@"Tex\PlayerLeft"));
            Textures.Add("PlayerRight", Content.Load<Texture2D>(@"Tex\PlayerRight"));
            Textures.Add("Red", Content.Load<Texture2D>(@"Tex\Red"));
            #endregion
            #region Load Music
            Music.Add("DeusEx", Content.Load<Song>(@"Music\Vi_Zav_track"));
            Music.Add("Crysis", Content.Load<Song>(@"Music\Ha_Zm_track"));
            Music.Add("MassEffect", Content.Load<Song>(@"Music\Ma_Ef_track"));
            #endregion
            #region Load Fonts
            Fonts.Add("Title", Content.Load<SpriteFont>(@"Fonts\TitleFont"));
            Fonts.Add("Simple", Content.Load<SpriteFont>(@"Fonts\MenuItemFont"));
            #endregion
            #region Load Effects
            #endregion
            #endregion
            MediaPlayer.Play(Music["MassEffect"]);
            MediaPlayer.IsRepeating = true;
            ship = new Player(new Animation(Textures["PlayerUp"], new Vector2(200, 200), 80, 200, 1, 24, Color.White, 1.0f, true), Textures["PlayerLeft"], Textures["PlayerRight"]);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            if (PrevState.IsKeyDown(Keys.Q))
                this.Exit();
            if (PrevState.IsKeyDown(Keys.W))
                ship.Move(4, Animation.Way.Up, GameScreenRect);
            else if (PrevState.IsKeyDown(Keys.S))
                ship.Move(3, Animation.Way.Down, GameScreenRect);
            else if (PrevState.IsKeyDown(Keys.A))
                ship.Move(2, Animation.Way.Left, GameScreenRect);
            else if (PrevState.IsKeyDown(Keys.D))
                ship.Move(2, Animation.Way.Right, GameScreenRect);
            PrevState = CurState;
            ship.Update(gameTime);
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
            spriteBatch.Draw(Textures["MainBackGround"], GameScreenRect, Color.White);
            ship.Draw(spriteBatch);
            spriteBatch.Draw(Textures["BackGroundSparks"], GameScreenRect, Color.White);
            spriteBatch.End();
        }
    }
}
