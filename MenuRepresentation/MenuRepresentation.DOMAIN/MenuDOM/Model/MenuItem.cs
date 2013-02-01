// -----------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml.Linq;

	using MenuRepresentation.DOMAIN.MenuDOM.Abstract;
	using MenuRepresentation.DOMAIN.MenuDOM.Internal;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class MenuItem : Item, IMenuItem
	{
		private readonly IMenuable baseItem;

		private BehaviorType itemBehavior;

		private string description;

		public MenuItem(XElement ItemNode, IMenuable baseItm)
			: base(ItemNode)
		{
			this.LoadItem(ItemNode);
			baseItem = baseItm;
		}

		public string Description
		{
			get
			{
				return description;
			}
		}

		public IMenuable BaseItem
		{
			get
			{
				return baseItem;
			}
		}

		public BehaviorType ItemBehavor
		{
			get
			{
				return itemBehavior;
			}
		}

		public virtual void LoadItem(XElement ItemNode)
		{
			base.LoadItem(ItemNode);
			description = ItemNode.Attribute("description").Value ?? "";
			itemBehavior = (new BehaviorType()).GetBehaviorType(ItemNode.Attribute("behavior").Value ?? "");
		}
	}

}