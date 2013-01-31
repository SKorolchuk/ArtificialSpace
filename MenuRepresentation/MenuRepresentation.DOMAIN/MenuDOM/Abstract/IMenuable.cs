// -----------------------------------------------------------------------
// <copyright file="IMenuable.cs" company="">
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

	public interface IMenuable
	{
		ItemType TypeOfTheItem { get; }

		IList<IMenuable> NestedItems { get; }

		string Name { get; }

		IVector Position { get; }
	}
}
