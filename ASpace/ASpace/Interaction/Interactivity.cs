using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASpace
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework.Input;
	using Microsoft.Xna.Framework.Media;

	public class Interactivity : IGame
	{
		private GamePlayGameLayer gameObj;

		internal KeyboardState CurState;

		internal KeyboardState PrevState;

		internal MouseState MouseSt;

		internal Random randomizer = new Random((int)DateTime.Now.Ticks);

		internal Player ship;

		internal List<Missle> rockets = new List<Missle>();

		internal Enemy enemy;

		internal List<Enemy> enemies = new List<Enemy>();

		internal List<Effect> explosion = new List<Effect>();

		internal int stage = 1;

		bool doonce = true;

		public Interactivity(GamePlayGameLayer game)
		{
			this.gameObj = game;
		}

		public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
			ship.Draw(spriteBatch);
			DrawRockets(spriteBatch);
			foreach (Enemy enemy in enemies)
			{
				enemy.Draw(spriteBatch);
			}
			foreach (Effect effect in explosion)
			{
				effect.Draw(spriteBatch);
			}
        }

		private void DrawRockets(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			foreach (Missle rocket in rockets)
			{
				if (rocket.MissleAnimation != null) rocket.Draw(spriteBatch);
			}
		}

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
			CurState = Keyboard.GetState();
			MouseSt = Mouse.GetState();
			// Allows the game to exit
			if (PrevState.IsKeyDown(Keys.Q))
				gameObj.Exit();
			if (PrevState.IsKeyDown(Keys.W))
			{
				ship.Move(10, Animation.Way.Up, gameObj.map.GameScreenRect);
				gameObj.map.ShiftOfBack.Y += 4;
			}
			else if (PrevState.IsKeyDown(Keys.S))
			{
				ship.Move(6, Animation.Way.Down, gameObj.map.GameScreenRect);
				gameObj.map.ShiftOfBack.Y -= 2;
			}
			else if (PrevState.IsKeyDown(Keys.A))
			{
				ship.Move(4, Animation.Way.Left, gameObj.map.GameScreenRect);
			}
			else if (PrevState.IsKeyDown(Keys.D))
			{
				ship.Move(4, Animation.Way.Right, gameObj.map.GameScreenRect);
			}
			else
			{
				ship.Move(0, Animation.Way.Up, gameObj.map.GameScreenRect);
			}
			if (PrevState.IsKeyDown(Keys.Up) && CurState.IsKeyUp(Keys.Up) && MediaPlayer.Volume < 1.0f)
				MediaPlayer.Volume += 0.1f;
			if (PrevState.IsKeyDown(Keys.Down) && CurState.IsKeyUp(Keys.Up) && MediaPlayer.Volume > 0.0f)
				MediaPlayer.Volume -= 0.1f;
			gameObj.map.simpleSprite.SpriteLocation = new Vector2(MouseSt.X, MouseSt.Y);
			SpellUpdate(gameTime);
			PrevState = CurState;
			ship.Update(gameTime);
			CheckMediaPlayerState();
			CollapseRockets();
			CollapseEffects();
			UpdateRockets(gameTime);
			UpdateEnemies(gameTime);
			UpdateStages(gameTime);
			foreach (Effect effect in explosion)
			{
				effect.Update(gameTime);
			}
			if (gameTime.TotalGameTime.Milliseconds % 2000 == 0)
				FireRocket(gameObj.Resources.Textures["LaserMissle"]);
        }

		void CheckMediaPlayerState()
		{
			if (MediaPlayer.State != MediaState.Playing)
			{
				if (doonce) doonce = false;
				MediaPlayer.Play(gameObj.Resources.Music[gameObj.Resources.MusicNames[randomizer.Next(0, gameObj.Resources.Music.Count - 1)]]);
			}
			if (MediaPlayer.State == MediaState.Playing)
				doonce = true;
		}

		private void UpdateEnemies(GameTime gameTime)
		{
			foreach (Enemy enemy in enemies)
			{
				if (!enemy.Alive)
				{
					enemy.Alive = true;
					enemy.Animation.Position = new Vector2(randomizer.Next(0, gameObj.map.GameScreenRect.Width), 10);
				}
				enemy.Update(gameTime);
				enemy.Animation.Going();
				if (!gameObj.map.GameScreenRect.Contains((int)enemy.Animation.Position.X,
											 (int)enemy.Animation.Position.Y))
				{
					enemy.Alive = false;
				}
			}
			foreach (Missle rocket in rockets)
			{
				foreach (Enemy enemy in enemies)
				{
					if (enemy.Animation.destRect.Contains((int)rocket.MissleAnimation.Position.X,
															(int)rocket.MissleAnimation.Position.Y))
					{
						enemy.Alive = false;
						var expOfRocket = new Effect();
						expOfRocket.Initialize(new Animation(gameObj.Resources.Textures["Explosion"],
															 enemy.Animation.Position,
															 64, 64,
															 10, 50,
															 Color.White, 1.0f, true),
											   500,
											   gameObj.Resources.Sounds["Explosion"]);
						explosion.Add(expOfRocket);
					}
				}
			}
		}

		private void SpellUpdate(GameTime gameTime)
		{
			if (PrevState.IsKeyDown(Keys.D1) && CurState.IsKeyUp(Keys.D1))
			{
				gameObj.Resources.Sounds["Blast1"].Play();
				gameObj.map.TerminalMsg += string.Format("{0}You use blaster 1...\n", gameObj.map.TerminalMsg);
				FireRocket(gameObj.Resources.Textures["LaserMissle"]);
			}
			if (PrevState.IsKeyDown(Keys.D2) && CurState.IsKeyUp(Keys.D2))
			{
				gameObj.Resources.Sounds["Blast2"].Play();
				gameObj.map.TerminalMsg += string.Format("{0}You use blaster 2...\n", gameObj.map.TerminalMsg);
				FireRocket(gameObj.Resources.Textures["ImpactMissle"]);
			}
			if (PrevState.IsKeyDown(Keys.D3) && CurState.IsKeyUp(Keys.D3))
			{
				gameObj.Resources.Sounds["Blast3"].Play();
				gameObj.map.TerminalMsg += string.Format("{0}You use blaster 3...\n", gameObj.map.TerminalMsg);
			}
			if (PrevState.IsKeyDown(Keys.D4) && CurState.IsKeyUp(Keys.D4))
			{
				gameObj.Resources.Sounds["Blast4"].Play();
				gameObj.map.TerminalMsg += string.Format("{0}You use blaster 4...\n", gameObj.map.TerminalMsg);
			}
		}

		private void UpdateRockets(GameTime gameTime)
		{
			foreach (Missle rocket in rockets)
			{
				if (rocket.MissleAnimation != null) rocket.Update(gameTime);
			}
		}

		private void FireRocket(Texture2D tex)
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
			AddRocket(basis, tex);
		}

		private void UpdateStages(GameTime time)
		{
			if (this.stage == 1)
			{
				if (time.TotalGameTime.Seconds >= 20)
				{
					var next = new Effect();
					next.Initialize(new Animation(gameObj.Resources.Textures["NextStage"],
												  new Vector2(gameObj.map.GameScreenRect.X - 128, gameObj.map.GameScreenRect.Y - 32),
												  256, 64,
												  1, 1000,
												  Color.White, 1.0f, true),
									2000,
									null);
					explosion.Add(next);
					gameObj.map.mainBackground = gameObj.Resources.Textures["MainBackGround2"];
					stage = 2;
				}
			}
			else if (stage == 2)
			{
				if (time.TotalGameTime.Seconds >= 40)
				{
					var next = new Effect();
					next.Initialize(new Animation(gameObj.Resources.Textures["NextStage"],
												  new Vector2(gameObj.map.GameScreenRect.X - 128, gameObj.map.GameScreenRect.Y - 32),
												  256, 64,
												  1, 1000,
												  Color.White, 1.0f, true),
									4000,
									null);
					explosion.Add(next);
					gameObj.map.mainBackground = gameObj.Resources.Textures["MainBackGround3"];
					stage = 3;
				}
			}
		}

		private void AddRocket(Vector2 basis, Texture2D texture)
		{
			Missle newRocket = new Missle();
			newRocket.Initialize(
				new Animation(texture, ship.Animation.Position, texture.Width, texture.Height, 1, 25, Color.White, 1.0f, true),
				100,
				new Vector2(0, 0), 10,
				basis);
			rockets.Add(newRocket);
		}

		private void CollapseRockets()
		{
			foreach (Missle rocket in rockets)
			{
				if (!gameObj.map.GameScreenRect.Contains((int)rocket.MissleAnimation.Position.X,
											(int)rocket.MissleAnimation.Position.Y))
					rocket.Alive = false;
			}
			var rocketsToDelete = rockets.Where(rocket => !rocket.Alive).ToList();
			foreach (Missle missle in rocketsToDelete)
			{
				rockets.Remove(missle);
			}
		}

		private void CollapseEffects()
		{
			var effectsTodel = explosion.Where(exp => !exp.Alive).ToList();
			foreach (var exp in effectsTodel)
			{
				explosion.Remove(exp);
			}
		}
    }
}
