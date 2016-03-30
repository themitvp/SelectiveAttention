using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JourneyPlanner
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class KeyValueAttribute : Attribute
	{
		public string Value { get; set; }
		public string Key { get; set; }
	}

	public static class EnumUtilities
	{
		public static string Value(this System.Enum constant)
		{
			return GetKeyValueAttribute(constant).Value;
		}

		public static string Key(this System.Enum constant)
		{
			return GetKeyValueAttribute(constant).Key;
		}

		public static IEnumerable<KeyValueAttribute> GetEnumerable<T>()
		{
			var instancia = Activator.CreateInstance<T>();

			var objInfos = instancia.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
			return from objFileInfo in objInfos
				let constant = (Enum)objFileInfo.GetValue(objFileInfo)
						where objFileInfo.GetCustomAttributes(typeof(KeyValueAttribute), false).Length != 0
					select new KeyValueAttribute()
			{
				Value = GetKeyValueAttribute(constant).Value,
				Key = GetKeyValueEnumValue(constant)
			};
		}
		private static KeyValueAttribute GetKeyValueAttribute(Enum constant)
		{
			var objInfos = constant.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
			return (from objFileInfo in objInfos let constantItem = (Enum)objFileInfo.GetValue(objFileInfo)
				where constantItem.GetHashCode().Equals(constant.GetHashCode())
				select objFileInfo.GetCustomAttributes(typeof(KeyValueAttribute), false) 
				into attributes
				where attributes.Length > 0
				select (KeyValueAttribute)attributes[0]).FirstOrDefault();
		}
		private static string GetKeyValueEnumValue(Enum constant)
		{
			var sValue = (constant.GetHashCode()).ToString();
			var objRet = GetKeyValueAttribute(constant);
			if (objRet == null) return sValue;

			var sAux = objRet.Key;
			if (!string.IsNullOrEmpty(sAux))
				sValue = objRet.Key;
			return sValue;
		}
	}
}

