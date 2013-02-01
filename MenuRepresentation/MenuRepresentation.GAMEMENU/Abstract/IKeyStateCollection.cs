// -----------------------------------------------------------------------
// <copyright file="IKeyStateCollection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.GAMEMENU
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Microsoft.Xna.Framework.Input;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public interface IKeyStateCollection
	{
		KeyboardState CurrentState { get; }

		KeyboardState PreviousState { get; }

		MouseState CurrentMouseState { get; }

		MouseState PreviousMouseState { get; }

		void UpdateControls();
	}
}
