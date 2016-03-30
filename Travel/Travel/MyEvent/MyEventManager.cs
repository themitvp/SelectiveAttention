using System;
using SQLite;
using System.Collections.Generic;

namespace Travel
{
	public class MyEventManager
	{
		MyEventRepository repository; 

		public MyEventManager(SQLiteConnection conn)
		{
			repository = new MyEventRepository(conn);
		}

		public MyEvent GetMyEvent(int id)
		{
			return repository.GetMyEvent(id);
		}

		public IList<MyEvent> GetMyEvents ()
		{
			return new List<MyEvent>(repository.GetMyEvents());
		}

		public int SaveMyEvent (MyEvent item)
		{
			return repository.SaveMyEvent(item);
		}

		public int DeleteMyEvent(int id)
		{
			return repository.DeleteMyEvent(id);
		}
	}
}

