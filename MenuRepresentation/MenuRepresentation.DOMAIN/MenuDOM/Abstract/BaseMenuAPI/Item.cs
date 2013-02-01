// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Abstract
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml.Linq;

	using MenuRepresentation.DOMAIN.MenuDOM.Internal;
	using MenuRepresentation.DOMAIN.MenuDOM.Model;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public abstract class Item : IMenuable
	{
		#region private fields

		private ItemType typeOfTheItem;
		private IList<IMenuable> nestedItems;
		private string name;
		
		private IVector position;

		#endregion

		#region public properties

		public ItemType TypeOfTheItem
		{
			get
			{
				return typeOfTheItem;
			}
		}

		public IList<IMenuable> NestedItems
		{
			get
			{
				return nestedItems;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		

		public IVector Position
		{
			get
			{
				return position;
			}
		}

		#endregion

		public virtual void LoadItem(XElement ItemNode)
		{
			foreach (XElement item in ItemNode.Elements())
			{
				this.nestedItems.Add(new MenuItem(item, this));
			}
		}

		public Item(XElement ItemNode)
		{
			this.nestedItems = new List<IMenuable>();
			typeOfTheItem = (new ItemType()).GetItemType(ItemNode.Attribute("type").Value ?? "");
			name = ItemNode.Attribute("name").Value ?? "";
			position = new Vector(ItemNode.Attribute("position").Value ?? "");
		}
	}
}
