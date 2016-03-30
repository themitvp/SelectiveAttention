using System;
using SQLite;
using System.Collections.Generic;

namespace Travel
{
	public class MyEventRepository
	{
		Database<MyEvent> db = null;

		public MyEventRepository(SQLiteConnection conn)
		{
			db = new Database<MyEvent>(conn);
		}

		public MyEvent GetMyEvent(int id)
		{
			return db.GetItem(id);
		}

		public IEnumerable<MyEvent> GetMyEvents ()
		{
			return db.GetItems();
		}

		public int SaveMyEvent (MyEvent item)
		{
			return db.SaveItem(item);
		}

		public int DeleteMyEvent(int id)
		{
			return db.DeleteItem(id);
		}
	}
}

