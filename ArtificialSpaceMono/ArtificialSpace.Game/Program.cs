#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace ArtificialSpace.GAME
{
	using ASpace;

	/// <summary>
	/// The main class.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			using (MenuGameLayer game = new MenuGameLayer())
			{
				game.Run();
			}
		}
	}
}
