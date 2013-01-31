// -----------------------------------------------------------------------
// <copyright file="Menu.cs" company="">
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

	public class Menu : Item, IMenu
	{
		private string title;

		

		public Menu(XDocument doc)
			: base(doc.Root)
		{
			CurrentMenuLevel = this;
		}

		public string Title
		{
			get
			{
				return title;
			}
		}

		public IMenuable CurrentMenuLevel { get; set; }

		public override void LoadItem(XElement ItemNode)
		{
			base.LoadItem(ItemNode);
			title = ItemNode.Attribute("title").Value ?? "";
		}

		public void Push(IMenuable item)
		{
			Commander.Proccess(item, this);
		}

		public void Prev()
		{
			if (CurrentMenuLevel is IMenuItem)
			{
				CurrentMenuLevel = ((IMenuItem)CurrentMenuLevel).BaseItem;
			}
		}
	}
}
