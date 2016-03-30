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

		public MyEvent GetTask(int id)
		{
			return repository.GetTask(id);
		}

		public IList<MyEvent> GetTasks ()
		{
			return new List<MyEvent>(repository.GetTasks());
		}

		public int SaveTask (MyEvent item)
		{
			return repository.SaveTask(item);
		}

		public int DeleteTask(int id)
		{
			return repository.DeleteTask(id);
		}
	}
}

