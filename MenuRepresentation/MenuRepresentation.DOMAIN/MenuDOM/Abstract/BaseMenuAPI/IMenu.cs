// -----------------------------------------------------------------------
// <copyright file="IMenu.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Abstract
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;


	public interface IMenu : IMenuable
	{
		string Title { get; }
		IMenuable CurrentMenuLevel { get; set; }
	}
}
