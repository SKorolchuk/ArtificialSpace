// -----------------------------------------------------------------------
// <copyright file="IMenuItem.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Abstract
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using MenuRepresentation.DOMAIN.MenuDOM.Internal;

	public interface IMenuItem : IMenuable
	{
		string Description { get; }

		IMenuable BaseItem { get; }

		BehaviorType ItemBehavor { get; }
	}
}
