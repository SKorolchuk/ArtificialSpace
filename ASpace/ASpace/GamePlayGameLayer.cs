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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        internal World map;

        internal Interactivity activities;

        /// <summary>
        /// Contains space of action screen
        /// </summary>
        internal Rectangle GameScreenRect;

        internal KeyboardState CurState;

        internal KeyboardState PrevState;

        internal MouseState MouseSt;

        internal Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        internal Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();

        internal Dictionary<string, Song> Music = new Dictionary<string, Song>();

        internal List<string> MusicNames = new List<string>();

        internal Dictionary<string, SoundEffect> Sounds = new Dictionary<string, SoundEffect>(); 

        internal Dictionary<string, Texture2D> Effects = new Dictionary<string, Texture2D>(); 

        private Random randomizer = new Random((int)DateTime.Now.Ticks);

        private Player ship;

        private Vector2 ShiftOfBack;

        private Texture2D mainBackground;

        private List<Missle> rockets = new List<Missle>();

        internal string TerminalMsg = string.Empty;

        private Sprite simpleSprite;

        private SpriteText simpleText;

        private Enemy vortrex;

        bool doonce = true;  

        void CheckMediaPlayerState()
        {
            if(MediaPlayer.State != MediaState.Playing) 
            {  
                if(doonce) doonce = false;  
                MediaPlayer.Play(Music[MusicNames[randomizer.Next(0, Music.Count-1)]]);  
            }  
            if(MediaPlayer.State == MediaState.Playing)
                doonce = true;  
        }


        public GamePlayGameLayer()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
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
            Textures.Add("EarthBackground", Content.Load<Texture2D>(@"Tex\EarthBackground"));
            Textures.Add("ParallaxBackGround", Content.Load<Texture2D>(@"Tex\ParallaxBackGround"));
            Textures.Add("Interface", Content.Load<Texture2D>(@"Tex\Interface"));
            Textures.Add("ParallaxSpace", Content.Load<Texture2D>(@"Tex\ParallaxSpace"));
            Textures.Add("gradient", Content.Load<Texture2D>(@"Tex\spr2"));
            #endregion
            #region Load Music
            Music.Add("DeusEx", Content.Load<Song>(@"Music\Vi_Zav_track"));
            MusicNames.Add("DeusEx");
            Music.Add("Crysis", Content.Load<Song>(@"Music\Ha_Zm_track"));
            MusicNames.Add("Crysis");
            Music.Add("MassEffect", Content.Load<Song>(@"Music\Ma_Ef_track"));
            MusicNames.Add("MassEffect");
            #endregion
            #region Load Fonts
            Fonts.Add("Title", Content.Load<SpriteFont>(@"Fonts\TitleFont"));
            Fonts.Add("Simple", Content.Load<SpriteFont>(@"Fonts\MenuItemFont"));
            #endregion
            #region Load Sound Effects
            Sounds.Add("Blast1", Content.Load<SoundEffect>(@"Sounds\Blast1"));
            Sounds.Add("Blast2", Content.Load<SoundEffect>(@"Sounds\Blast2"));
            Sounds.Add("Blast3", Content.Load<SoundEffect>(@"Sounds\Blast3"));
            Sounds.Add("Blast4", Content.Load<SoundEffect>(@"Sounds\Blast4"));
            #endregion
            #region Load Effects
            #endregion
            #endregion
            ship = new Player(new Animation(Textures["PlayerUp"], new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight/2), 80, 200, 1, 24, Color.White, 1.0f, true), Textures["PlayerLeft"], Textures["PlayerRight"]);
            ShiftOfBack = new Vector2(0, 0);
            mainBackground = Textures["ParallaxSpace"];

            simpleSprite = new Sprite(Textures["gradient"]);
            simpleSprite.OriginToCenter();
            simpleText = new SpriteText(Fonts["Simple"], new Vector2(30, 40));
            simpleText.SpriteColor = Color.Red;
            TerminalMsg += "System is under control...\n";
            vortrex = new Enemy(new Animation(Textures["Hole"], new Vector2(10, 10), 100, 100, 1, 24, Color.White, 1.0f, true), Textures["Hole"], Textures["Hole"]);
            vortrex.Animation.speed = 1;
            vortrex.Animation.angle = new Vector2(1, 1);
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
            MouseSt = Mouse.GetState();
            // Allows the game to exit
            if (PrevState.IsKeyDown(Keys.Q))
                this.Exit();
            if (PrevState.IsKeyDown(Keys.W))
            {
                ship.Move(10, Animation.Way.Up, GameScreenRect);
                ShiftOfBack.Y += 4;
            }
            else if (PrevState.IsKeyDown(Keys.S))
            {
                ship.Move(6, Animation.Way.Down, GameScreenRect);
                ShiftOfBack.Y -= 2;
            }
            else if (PrevState.IsKeyDown(Keys.A))
            {
                ship.Move(4, Animation.Way.Left, GameScreenRect);
            }
            else if (PrevState.IsKeyDown(Keys.D))
            {
                ship.Move(4, Animation.Way.Right, GameScreenRect);
            }
            else
            {
                ship.Move(0, Animation.Way.Up, GameScreenRect);
            }
            if (PrevState.IsKeyDown(Keys.Up) && CurState.IsKeyUp(Keys.Up) && MediaPlayer.Volume < 1.0f)
                MediaPlayer.Volume += 0.1f;
            if (PrevState.IsKeyDown(Keys.Down) && CurState.IsKeyUp(Keys.Up) && MediaPlayer.Volume > 0.0f)
                MediaPlayer.Volume -= 0.1f;
            simpleSprite.SpriteLocation = new Vector2(MouseSt.X, MouseSt.Y);
            SpellUpdate(gameTime);
            PrevState = CurState;
            ship.Update(gameTime);
            UpdateParallax();
            RecalcTerminal();
            CheckMediaPlayerState();
            CollapseRockets();
            UpdateRockets(gameTime);
            UpdateEnemies(gameTime);
            if (gameTime.TotalGameTime.Milliseconds % 2000 == 0)
                FireRocket();
            base.Update(gameTime);
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            if (!vortrex.Alive)
            {
                vortrex.Alive = true;
                vortrex.Animation.Position = new Vector2(randomizer.Next(0, GameScreenRect.Width), randomizer.Next(0, GameScreenRect.Height));
            }
            vortrex.Update(gameTime);
            vortrex.Animation.Going();
            if (!GameScreenRect.Contains((int) vortrex.Animation.Position.X,
                                         (int) vortrex.Animation.Position.Y))
            {
                if (vortrex.Animation.Position.X > GameScreenRect.X)
                {
                    vortrex.Animation.angle.X = -1;
                }
                else vortrex.Animation.angle.X = 1;
                if (vortrex.Animation.Position.Y > GameScreenRect.Y)
                {
                    vortrex.Animation.angle.Y = -1;
                }
                else vortrex.Animation.angle.Y = 1;
            }
            foreach (Missle rocket in rockets)
            {
                if (vortrex.Animation.destRect.Contains((int)rocket.MissleAnimation.Position.X, 
                                                        (int)rocket.MissleAnimation.Position.Y))
                    vortrex.Alive = false;
            }
        }

        private void UpdateRockets(GameTime gameTime)
        {
            foreach (Missle rocket in rockets)
            {
                if (rocket.MissleAnimation != null) rocket.Update(gameTime);
            }
        }

        private void SpellUpdate(GameTime gameTime)
        {
            if (PrevState.IsKeyDown(Keys.D1) && CurState.IsKeyUp(Keys.D1))
            {
                Sounds["Blast1"].Play();
                TerminalMsg += string.Format("{0}You use blaster 1...\n", TerminalMsg);
                FireRocket();
            }
            if (PrevState.IsKeyDown(Keys.D2) && CurState.IsKeyUp(Keys.D2))
            {
                Sounds["Blast2"].Play();
                TerminalMsg += string.Format("{0}You use blaster 2...\n", TerminalMsg);
            }
            if (PrevState.IsKeyDown(Keys.D3) && CurState.IsKeyUp(Keys.D3))
            {
                Sounds["Blast3"].Play();
                TerminalMsg += string.Format("{0}You use blaster 3...\n", TerminalMsg);
            }
            if (PrevState.IsKeyDown(Keys.D4) && CurState.IsKeyUp(Keys.D4))
            {
                Sounds["Blast4"].Play();
                TerminalMsg += string.Format("{0}You use blaster 4...\n", TerminalMsg);
            }
        }

        private void FireRocket()
        {
            var basis = new Vector2
                            {
                                X = Math.Abs(MouseSt.X - ship.Animation.Position.X),
                                Y = Math.Abs(MouseSt.Y - ship.Animation.Position.Y)
                            };
            basis.Normalize();
            if (MouseSt.X > ship.Animation.Position.X) basis.X *= 1;
            else basis.X *= -1;
            if (MouseSt.Y > ship.Animation.Position.Y) basis.Y *= 1;
            else basis.Y *= -1;
            AddRocket(basis);
        }

        private void AddRocket(Vector2 basis)
        {
            Missle newRocket = new Missle();
            newRocket.Initialize(
                new Animation(Textures["gradient"], ship.Animation.Position, 64, 64, 1, 25, Color.White, 1.0f, true),
                100,
                new Vector2(0, 0), 10,
                basis);
            rockets.Add(newRocket);
        }

        private void CollapseRockets()
        {
            foreach (Missle rocket in rockets)
            {
                if (!GameScreenRect.Contains((int)rocket.MissleAnimation.Position.X,
                                            (int)rocket.MissleAnimation.Position.Y))
                    rocket.Alive = false;
            }
            var rocketsToDelete = rockets.Where(rocket => !rocket.Alive).ToList();
            foreach (Missle missle in rocketsToDelete)
            {
                rockets.Remove(missle);
            }
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
            for (int i = ((terminalColocations.Length-5) > 0) ? terminalColocations.Length-5 : 0; i < terminalColocations.Length; i++)
            {
                if (terminalColocations[i].Length > 1)
                {
                    TerminalMsg += string.Format("{0}\n", terminalColocations[i]);
                }
            }
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
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            spriteBatch.Draw(mainBackground, new Vector2(0, 0), new Rectangle((int)(-ShiftOfBack.X), (int)(-ShiftOfBack.Y), mainBackground.Width, mainBackground.Height), Color.White);
            ship.Draw(spriteBatch);
            DrawRockets();
            vortrex.Draw(spriteBatch);
            DrawInterface();
            simpleSprite.DrawSprite(spriteBatch);
            spriteBatch.End();
        }

        private void DrawRockets()
        {
            foreach (Missle rocket in rockets)
            {
                if (rocket.MissleAnimation != null) rocket.Draw(spriteBatch);
            }
        }

        private void DrawInterface()
        {
            spriteBatch.Draw(Textures["Interface"], GameScreenRect, Color.White);
            spriteBatch.DrawString(Fonts["Simple"], TerminalMsg, new Vector2(90, 50), Color.White);
        }
    }
}
