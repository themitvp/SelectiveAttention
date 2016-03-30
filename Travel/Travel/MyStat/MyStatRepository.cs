using System;
using SQLite;
using System.Collections.Generic;

namespace Travel
{
	public class MyStatRepository
	{
		Database<MyStat> db = null;

		public MyStatRepository(SQLiteConnection conn)
		{
			db = new Database<MyStat>(conn);
		}

		public MyStat GetMyStat(int id)
		{
			return db.GetItem(id);
		}

		public IEnumerable<MyStat> GetMyStats ()
		{
			return db.GetItems();
		}

		public int SaveMyStat (MyStat item)
		{
			return db.SaveItem(item);
		}

		public int DeleteMyStat(int id)
		{
			return db.DeleteItem(id);
		}
	}
}

