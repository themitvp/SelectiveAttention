using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;

namespace Travel
{
	public class Database<T> where T : Item, new()
	{
		static object locker = new object ();

		public SQLiteConnection database;

		public string path;

		public Database (SQLiteConnection conn) 
		{
			database = conn;
			// create the tables
			database.CreateTable<T>();
		}

		public IEnumerable<T> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<T>() select i).ToList();
			}
		}

		public T GetItem (int id)
		{
			lock (locker) {
				return database.Table<T>().FirstOrDefault(x => x.Id == id);
				// Following throws NotSupportedException - thanks aliegeni
				//return (from i in Table<T> ()
				//        where i.ID == id
				//        select i).FirstOrDefault ();
			}
		}

		public int SaveItem (T item)
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

		public int DeleteItem (int id) 
		{
			lock (locker) {
				return database.Delete<T>(id);
			}
		}
	}
}

