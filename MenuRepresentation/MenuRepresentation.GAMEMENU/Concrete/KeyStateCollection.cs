// -----------------------------------------------------------------------
// <copyright file="KeyStateCollection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.GAMEMENU.Concrete
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Microsoft.Xna.Framework.Input;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class KeyStateCollection : IKeyStateCollection
	{
		public KeyboardState CurrentState { get; private set; }

		public KeyboardState PreviousState { get; private set; }

		public MouseState CurrentMouseState { get; private set; }

		public MouseState PreviousMouseState { get; private set; }

		public void UpdateControls()
		{
			this.PreviousState = this.CurrentState;
			this.PreviousMouseState = this.CurrentMouseState;
			this.CurrentState = Keyboard.GetState();
			this.CurrentMouseState = Mouse.GetState();
		}
	}
}
