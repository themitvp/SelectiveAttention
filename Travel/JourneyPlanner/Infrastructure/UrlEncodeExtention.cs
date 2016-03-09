using System;
using System.Reflection;
using System.Collections.Generic;

namespace JourneyPlanner.Infrastructure
{
	internal static class UrlEncodeExtention
	{
		public static string UrlEncode<T> (this T entity) where T : JourneyPlannerRequestBase
		{
			var t = typeof(T);
			var properties = t.GetRuntimeProperties ();
			var url = "?";

			using (var e = properties.GetEnumerator ()) {
				if (!e.MoveNext ())
					return "";

				PropertyInfo p = e.Current;
				var val = "";
				while (e.MoveNext ()) {
					val = p.GetStringValue(entity);
					if (!string.IsNullOrEmpty (val))
						url += Concat(p.Name, val, "&");
					p = e.Current;
				}

				val = p.GetStringValue(entity);
				if (!string.IsNullOrEmpty (val))
					url += Concat(p.Name, val);
			}

			return url;
		}


		private static string GetStringValue<T> (this PropertyInfo p, T entity)
		{
			Type type = p.PropertyType;
			if (type == typeof(string))
				return "" + p.GetValue(entity, null);

			if (type  == typeof(int))
				return "" + p.GetValue(entity, null); 
			return "";
		}

		private static string Concat (string name, string val, string sep = "")
		{
			return sep + name + "=" + val;
		}

	}
}

