// -----------------------------------------------------------------------
// <copyright file="Commander.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Internal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using MenuRepresentation.DOMAIN.MenuDOM.Abstract;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public static class Commander
	{
		private static readonly IDictionary<BehaviorType, Action<IMenuItem, IMenu>> BehaviorActions;

		static Commander()
		{
			BehaviorActions = new Dictionary<BehaviorType, Action<IMenuItem, IMenu>>();
			BehaviorActions.Add(
				new KeyValuePair<BehaviorType, Action<IMenuItem, IMenu>>(
					BehaviorType.NEXT, (menuItem, menu) => menu.CurrentMenuLevel = menuItem));
			BehaviorActions.Add(
				new KeyValuePair<BehaviorType, Action<IMenuItem, IMenu>>(
					BehaviorType.EXIT, (menuItem, menu) => Environment.Exit(0)));
		}


		public static void Proccess(IMenuable item, IMenu menu)
		{
			IMenuItem currentMItem = item as IMenuItem;
			if (currentMItem == null)
			{
				return;
			}

			BehaviorActions.First(x => x.Key == currentMItem.ItemBehavor).Value(currentMItem, menu);
		}
	}
}
