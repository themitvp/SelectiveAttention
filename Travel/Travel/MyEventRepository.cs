using System;
using SQLite;
using System.Collections.Generic;

namespace Travel
{
	public class MyEventRepository
	{
		Database db = null;

		public MyEventRepository(SQLiteConnection conn)
		{
			db = new Database(conn);
		}

		public MyEvent GetTask(int id)
		{
			return db.GetItem(id);
		}

		public IEnumerable<MyEvent> GetTasks ()
		{
			return db.GetItems();
		}

		public int SaveTask (MyEvent item)
		{
			return db.SaveItem(item);
		}

		public int DeleteTask(int id)
		{
			return db.DeleteItem(id);
		}
	}
}

