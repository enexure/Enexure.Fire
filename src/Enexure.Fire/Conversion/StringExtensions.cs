using System;
using System.Globalization;
using System.Reflection;
using Enexure.Fire.Reflection;

namespace Enexure.Fire.Conversion
{
	public static class StringExtensions
	{
		/// <summary>Converts string to specifiec type</summary>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="value">cachedValue to convert from</param>
		/// <returns>Converted value</returns>
		/// <exception cref="FormatException">Thrown when the format of the value cannot be converted</exception>
		public static T To<T>(this string value)
		{
			var type = typeof(T);
			return (T)To(value, type, false);
		}

		/// <summary>Converts string to specifiec type</summary>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="value">cachedValue to convert from</param>
		/// <returns>Converted value or the default value for the type</returns>
		public static T ToOrDefault<T>(this string value)
		{
			var type = typeof(T);
			return (T)To(value, type, true);
		}

		/// <summary>Converts string to specifiec type</summary>
		/// <param name="value">cachedValue to convert from</param>
		/// <param name="type">Type to convert to</param>
		/// <returns>Converted value</returns>
		/// <exception cref="FormatException">Thrown when the format of the value cannot be converted</exception>
		public static object To(this string value, Type type)
		{
			return To(value, type, false);
		}

		/// <summary>Converts string to specifiec type</summary>
		/// <param name="value">cachedValue to convert from</param>
		/// <param name="type">Type to convert to</param>
		public static object ToOrDefault(this string value, Type type)
		{
			return To(value, type, true);
		}

		private static object To(this string value, Type type, bool useDefault)
		{
			
			var coreType = Nullable.GetUnderlyingType(type);
			var isNullable = coreType != null;
			var convertType = coreType ?? type;
			var convertTypeInfo = convertType.GetTypeInfo();
			var isValueType = convertTypeInfo.IsValueType;

			object result = null;

			try {

				result = Convert(convertType, value);

			} catch (Exception ex) {

				if (!useDefault) {
					throw;
				}
			}

			if (isNullable) {
				return result;

			} else {
				return useDefault && isValueType && (result == null) ? convertTypeInfo.GetDefault() : result;
			}

		}

		private static object Convert(Type type, string value)
		{
			var typeInfo = type.GetTypeInfo();

			if (!typeInfo.IsValueType && string.IsNullOrWhiteSpace(value)) {
				return null;
			}
			
			return TypeConverter.Convert(value, CultureInfo.CurrentCulture, type);
		}

	}
}
