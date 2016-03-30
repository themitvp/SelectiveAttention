using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;

namespace Travel
{
	public class Database
	{
		static object locker = new object ();

		public SQLiteConnection database;

		public string path;

		public Database(SQLiteConnection conn) 
		{
			database = conn;
			// create the tables
			database.CreateTable<MyEvent>();
		}

		public IEnumerable<MyEvent> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<MyEvent>() select i).ToList();
			}
		}

		public MyEvent GetItem (int id) 
		{
			lock (locker) {
				return database.Table<MyEvent>().FirstOrDefault(x => x.Id == id);
				// Following throws NotSupportedException - thanks aliegeni
				//return (from i in Table<T> ()
				//        where i.ID == id
				//        select i).FirstOrDefault ();
			}
		}

		public int SaveItem (MyEvent item) 
		{
			lock (locker) {
				if (item.Id != 0) {
					database.Update(item);
					return item.Id;
				} else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id) 
		{
			lock (locker) {
				return database.Delete<MyEvent>(id);
			}
		}
	}
}

