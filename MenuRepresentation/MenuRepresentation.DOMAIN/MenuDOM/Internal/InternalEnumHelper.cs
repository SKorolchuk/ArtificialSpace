// -----------------------------------------------------------------------
// <copyright file="InternalEnumHelper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Internal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public static class InternalEnumHelper
	{
		public static BehaviorType GetBehaviorType(this BehaviorType el, string type)
		{
			switch (type)
			{
				case "NEXT":
					return BehaviorType.NEXT;
				case "PLAY_EASY":
					return BehaviorType.PLAY_EASY;
				case "PLAY_NORMAL":
					return BehaviorType.PLAY_NORMAL;
				case "PLAY_HARD":
					return BehaviorType.PLAY_HARD;
				case "EXIT":
					return BehaviorType.EXIT;
				default:
					return BehaviorType.NOTHING;
			}
		}

		public static string GetBehaviorTypeString(this BehaviorType el)
		{
			switch (el)
			{
				case BehaviorType.NEXT:
					return "NEXT";
				case BehaviorType.PLAY_EASY:
					return "PLAY_EASY";
				case BehaviorType.PLAY_NORMAL:
					return "PLAY_NORMAL";
				case BehaviorType.PLAY_HARD:
					return "PLAY_HARD";
				case BehaviorType.EXIT:
					return "EXIT";
				default:
					return "NOTHING";
			}
		}

		public static ItemType GetItemType(this ItemType el, string type)
		{
			switch (type)
			{
				case "Menu":
					return ItemType.Menu;
				case "MenuLetter":
					return ItemType.MenuLetter;
				default:
					throw new Exception("Type isn't correct!");
			}
		}

		public static string GetItemTypeString(this ItemType el)
		{
			switch (el)
			{
				case ItemType.Menu:
					return "Menu";
				case ItemType.MenuLetter:
					return "MenuLetter";
				default:
					throw new Exception("Type isn't correct!");
			}
		}
	}
}
