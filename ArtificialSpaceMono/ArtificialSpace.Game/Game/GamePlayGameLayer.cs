using System;
using System.Collections;
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
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        internal World map;

        internal Interactivity activities;

	    internal Resources Resources { get; set; }


        public bool GameStarted = false;

        public GameTime gameStarted;

        public GamePlayGameLayer()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1366;
			map = new World(this);
			activities = new Interactivity(this);
			map.GameScreenRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Content.RootDirectory = "Content";
			Resources = new Resources();
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
			Resources.Textures.Add("MainBackGround", Content.Load<Texture2D>(@"Tex\MainBackGround"));
			Resources.Textures.Add("BackGroundSparks", Content.Load<Texture2D>(@"Tex\BackGroundSparks"));
			Resources.Textures.Add("Asteroid2", Content.Load<Texture2D>(@"Tex\Asteroid2"));
			Resources.Textures.Add("Hole", Content.Load<Texture2D>(@"Tex\Hole"));
			Resources.Textures.Add("PlayerUp", Content.Load<Texture2D>(@"Tex\PlayerUp"));
			Resources.Textures.Add("PlayerLeft", Content.Load<Texture2D>(@"Tex\PlayerLeft"));
			Resources.Textures.Add("PlayerRight", Content.Load<Texture2D>(@"Tex\PlayerRight"));
			Resources.Textures.Add("Red", Content.Load<Texture2D>(@"Tex\Red"));
			Resources.Textures.Add("EarthBackground", Content.Load<Texture2D>(@"Tex\EarthBackground"));
			Resources.Textures.Add("ParallaxBackGround", Content.Load<Texture2D>(@"Tex\ParallaxBackGround"));
			Resources.Textures.Add("Interface", Content.Load<Texture2D>(@"Tex\Interface"));
			Resources.Textures.Add("ParallaxSpace", Content.Load<Texture2D>(@"Tex\ParallaxSpace"));
			Resources.Textures.Add("gradient", Content.Load<Texture2D>(@"Tex\spr2"));
			Resources.Textures.Add("Explosion", Content.Load<Texture2D>(@"Tex\explosion"));
			Resources.Textures.Add("EnemyShip", Content.Load<Texture2D>(@"Tex\enemyShip"));
			Resources.Textures.Add("MainBackGround2", Content.Load<Texture2D>(@"Tex\stage2"));
			Resources.Textures.Add("MainBackGround3", Content.Load<Texture2D>(@"Tex\stage3"));
			Resources.Textures.Add("NextStage", Content.Load<Texture2D>(@"Tex\NEXT_STAGE"));
			Resources.Textures.Add("LaserMissle", Content.Load<Texture2D>(@"Tex\laserMissle"));
			Resources.Textures.Add("ImpactMissle", Content.Load<Texture2D>(@"Tex\impactMissle"));
            Resources.Textures.Add("Loading", Content.Load<Texture2D>(@"Tex\loading"));
            #endregion
            #region Load Music
			//Resources.Music.Add("DeusEx", Content.Load<Song>(@"Music\Vi_Zav_track.xnb"));
			//Resources.MusicNames.Add("DeusEx");
			//Resources.Music.Add("Crysis", Content.Load<Song>(@"Music\Ha_Zm_track"));
			//Resources.MusicNames.Add("Crysis");
			//Resources.Music.Add("MassEffect", Content.Load<Song>(@"Music\Ma_Ef_track"));
			//Resources.MusicNames.Add("MassEffect");
            #endregion
            #region Load Fonts
			Resources.Fonts.Add("Title", Content.Load<SpriteFont>(@"Fonts\TitleFont"));
			Resources.Fonts.Add("Simple", Content.Load<SpriteFont>(@"Fonts\MenuItemFont"));
            #endregion
            #region Load Sound Effects
			Resources.Sounds.Add("Blast1", Content.Load<SoundEffect>(@"Sounds\Blast1"));
			Resources.Sounds.Add("Blast2", Content.Load<SoundEffect>(@"Sounds\Blast2"));
			Resources.Sounds.Add("Blast3", Content.Load<SoundEffect>(@"Sounds\Blast3"));
			Resources.Sounds.Add("Blast4", Content.Load<SoundEffect>(@"Sounds\Blast4"));
			Resources.Sounds.Add("Explosion", Content.Load<SoundEffect>(@"Sounds\Explosion"));
            #endregion
            #region Load Effects
            #endregion
            #endregion
			activities.ship = new Player(new Animation(Resources.Textures["PlayerUp"],
														 new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2),
														 80,
														 200,
														 1,
														 24,
														 Color.White,
														 1.0f,
														 true),
										Resources.Textures["PlayerLeft"],
										Resources.Textures["PlayerRight"]);
			map.ShiftOfBack = new Vector2(0, 0);
			map.mainBackground = Resources.Textures["ParallaxSpace"];

			map.simpleSprite = new Sprite(Resources.Textures["gradient"]);
			map.simpleSprite.OriginToCenter();
			map.simpleText = new SpriteText(Resources.Fonts["Simple"], new Vector2(30, 40)) { SpriteColor = Color.Red };
	        map.TerminalMsg += "System is under control...\n";
            for(int i = 0; i < 5; i++){
				activities.enemy = new Enemy(new Animation(Resources.Textures["EnemyShip"],
															new Vector2(10, 10),
															64,
															64,
															1,
															100,
															Color.White,
															1.0f,
															true),
												new Vector2(1, 1)) { Animation = { speed = 1, angle = new Vector2(0, 5) } };
	            activities.enemies.Add(activities.enemy);
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
			activities.Update(gameTime);
			map.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            map.Draw(spriteBatch);
			activities.Draw(spriteBatch);
            DrawInterface();
            map.simpleSprite.DrawSprite(spriteBatch);
            spriteBatch.End();
        }

        

        private void DrawInterface()
        {
			spriteBatch.Draw(Resources.Textures["Interface"], map.GameScreenRect, Color.White);
			spriteBatch.DrawString(Resources.Fonts["Simple"], map.TerminalMsg, new Vector2(90, 50), Color.White);
        }
    }
}
