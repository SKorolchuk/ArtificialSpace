// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Vector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MenuRepresentation.DOMAIN.MenuDOM.Model
{
	using MenuRepresentation.DOMAIN.MenuDOM.Abstract;

	public class Vector : IVector
	{
		public Vector(string pos)
		{
			string[] xy_array = pos.Split(',');
			this.X = int.Parse(xy_array[0]);
			this.Y = int.Parse(xy_array[1]);
		}

		public int X { get; set; }

		public int Y { get; set; }
	}
}