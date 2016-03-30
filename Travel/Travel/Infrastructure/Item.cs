using System;
using SQLite;

namespace Travel
{
	public abstract class Item
	{
		public Item(){}

		/// <summary>
		/// Id
		/// </summary>
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}

