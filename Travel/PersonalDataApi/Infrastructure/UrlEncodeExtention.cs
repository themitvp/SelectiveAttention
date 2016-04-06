using System;
using System.Reflection;
using System.Collections.Generic;

namespace PersonalDataApi
{
	public static class UrlEncodeExtention
	{
		public static string UrlEncode<T> (this T entity) where T : RequestBase, IRequestBase
		{
			var t = typeof(T);
			var properties = t.GetRuntimeProperties ();
			var url = "";

			using (var e = properties.GetEnumerator ()) {
				if (!e.MoveNext ())
					return "";

				PropertyInfo p = e.Current;
			
				var val = "";
				var name = "";
				while (e.MoveNext ()) {
					val = p.GetStringValue(entity);
					name = ResolveName (p.Name, entity);
					if (!string.IsNullOrEmpty (val))
						url += Concat(name, val, "&");
					p = e.Current;
				}

				val = p.GetStringValue(entity);
				name = ResolveName (p.Name, entity);
				if (!string.IsNullOrEmpty (val))
						url += Concat(name, val);
			}

			return url.TrimEnd('&');
		}

		private static string ResolveName(string name, IRequestBase entity)
		{
			string oName;
			var success = entity.NameDictionary().TryGetValue (name, out oName);
			return success ? oName : name;	
		}

		private static string GetStringValue<T> (this PropertyInfo p, T entity)
		{
			Type type = p.PropertyType;
			if (type == typeof(string))
				return "" + p.GetValue(entity, null);

			if (type  == typeof(int?))
				return "" + p.GetValue(entity, null); 

			if (type == typeof(Guid))
				return p.GetValue (entity, null).ToString (); 

			return "";
		}

		private static string Concat (string name, string val, string sep = "")
		{
			return string.IsNullOrEmpty(name) ? val : name + "=" + val + sep;
		}
	}
}

