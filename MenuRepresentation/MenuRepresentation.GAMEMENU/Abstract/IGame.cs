// -----------------------------------------------------------------------
// <copyright file="IGame.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.GAMEMENU
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public interface IGame
	{
		void Update(GameTime time, IKeyStateCollection keyState);

		void Draw(SpriteBatch sprite);
	}
}
