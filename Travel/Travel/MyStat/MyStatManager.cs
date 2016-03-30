using System;
using SQLite;
using System.Collections.Generic;

namespace Travel
{
	public class MyStatManager
	{
		MyStatRepository repository; 

		public MyStatManager(SQLiteConnection conn)
		{
			repository = new MyStatRepository(conn);
		}

		public MyStat GetMyStat(int id)
		{
			return repository.GetMyStat(id);
		}

		public IList<MyStat> GetMyStats ()
		{
			return new List<MyStat>(repository.GetMyStats());
		}

		public int SaveMyStat (MyStat item)
		{
			return repository.SaveMyStat(item);
		}

		public int DeleteMyStat(int id)
		{
			return repository.DeleteMyStat(id);
		}
	}
}

