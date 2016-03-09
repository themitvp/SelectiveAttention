using System;
using System.Reflection;
using System.Collections.Generic;

namespace JourneyPlanner.Infrastructure
{
	internal static class UrlEncodeExtention
	{
		public static string UrlEncode<T> (this T collection) where T : JourneyPlannerResponseBase
		{
			var t = typeof(T);
			var properties = t.GetRuntimeProperties ();
			var url = "?";

			using (var e = properties.GetEnumerator ()) {
				if (!e.MoveNext ())
					return;

				PropertyInfo p = e.Current;
				var val = "";
				while (e.MoveNext ()) {
					val = p.GetStringValue ();
					if (!string.IsNullOrEmpty (val))
						url += Concat(p.Name, val, "&");
					p = e.Current;
				}

				val = p.GetStringValue ();
				if (!string.IsNullOrEmpty (val))
					url += Concat(p.Name, val);
			}

			return url;
		}


		private static string GetStringValue (this PropertyInfo p)
		{
			var type = p.GetType ();
			if (type is string)
				return p.GetValue;

			if (type is int)
				return "" + p.GetValue; 
			return "";
		}

		private string Concat (string name, string val, string sep = "")
		{
			return sep + name + "=" + val;
		}

	}
}

