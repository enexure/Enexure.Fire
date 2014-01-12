using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Text;
using System.Reflection;
using Enexure.Fire.Formatting;
using Enexure.Fire.Reflection;

namespace Enexure.Fire.Conversion
{
	public static class TypeConverter
	{
		/// <summary>
		/// Converts the value to the specified type.
		/// </summary>
		/// <param name="initialValue">The value to convert.</param>
		/// <param name="targetType">The type to convert the value to.</param>
		/// <param name="convertedValue">The converted value if the conversion was successful or the default value of <c>T</c> if it failed.</param>
		/// <returns>
		///     <c>true</c> if <para>initialValue</para> was converted successfully; otherwise, <c>false</c>.
		/// </returns>
		public static bool TryConvert(object initialValue, Type targetType, out object convertedValue)
		{
			return TryConvert(initialValue, CultureInfo.CurrentCulture, targetType, out convertedValue);
		}

		/// <summary>
		/// Converts the value to the specified type.
		/// </summary>
		/// <param name="initialValue">The value to convert.</param>
		/// <param name="culture">The culture to use when converting.</param>
		/// <param name="targetType">The type to convert the value to.</param>
		/// <param name="convertedValue">The converted value if the conversion was successful or the default value of <c>T</c> if it failed.</param>
		/// <returns>
		///     <c>true</c> if <para>initialValue</para> was converted successfully; otherwise, <c>false</c>.
		/// </returns>
		public static bool TryConvert(object initialValue, CultureInfo culture, Type targetType, out object convertedValue)
		{
			try {
				convertedValue = Convert(initialValue, culture, targetType);
				return true;
			} catch {
				convertedValue = null;
				return false;
			}
		}

		/// <summary>
		/// Converts the value to the specified type.
		/// </summary>
		/// <param name="initialValue">The value to convert.</param>
		/// <param name="targetType">The type to convert the value to.</param>
		/// <returns>The converted type.</returns>
		public static object Convert(object initialValue, Type targetType)
		{
			return Convert(initialValue, CultureInfo.CurrentCulture, targetType);
		}

		/// <summary>
		/// Converts the value to the specified type.
		/// </summary>
		/// <param name="initialValue">The value to convert.</param>
		/// <param name="culture">The culture to use when converting.</param>
		/// <param name="targetType">The type to convert the value to.</param>
		/// <returns>The converted type.</returns>
		public static object Convert(object initialValue, CultureInfo culture, Type targetType)
		{
			// Partially derived from ConvertUtils : James Newton-King

			if (initialValue == null) {
				throw new ArgumentNullException("initialValue");
			}

			if (targetType.GetTypeInfo().IsNullable()) {
				targetType = Nullable.GetUnderlyingType(targetType);
			}

			var initialType = initialValue.GetType();

			if (targetType == initialType) {
				return initialValue;
			}

			var targetTypeInfo = targetType.GetTypeInfo();

			// use Convert.ChangeType if both types are Convertible
			if (IsConvertible(initialType) && IsConvertible(targetType)) {
				if (targetTypeInfo.IsEnum) {
					if (initialValue is string) {
						return Enum.Parse(targetType, initialValue.ToString(), true);

					} else if (IsInteger(initialType)) {
						return Enum.ToObject(targetType, initialValue);
					}
				}

				return System.Convert.ChangeType(initialValue, targetType, culture);
			}

			if (initialValue is DateTime && targetType == typeof(DateTimeOffset)) {
				return new DateTimeOffset((DateTime)initialValue);
			}

			if (initialValue is byte[] && targetType == typeof(Guid)) {
				return new Guid((byte[])initialValue);
			}

			var str = initialValue as string;
			if (str != null) {
				if (targetType == typeof(Guid))
					return new Guid(str);

				if (targetType == typeof(Uri))
					return new Uri(str, UriKind.RelativeOrAbsolute);

				if (targetType == typeof(TimeSpan))
					return TimeSpan.Parse(str);

				if (targetType == typeof(byte[]))
					return System.Convert.FromBase64String(str);

				if (typeof(Type).GetTypeInfo().IsAssignableFrom(targetTypeInfo))
					return Type.GetType(str, true);
			}


			if (targetTypeInfo.IsInterface || targetTypeInfo.IsGenericTypeDefinition || targetTypeInfo.IsAbstract) {
				throw new ArgumentException(
					ExceptionMessages.Enexure_Fire_Conversion_TypeConverter_Argument_TypeNotSupported
					.FormatWith(CultureInfo.InvariantCulture, targetType), "targetType");
			}

			throw new InvalidOperationException(
					ExceptionMessages.Enexure_Fire_Conversion_TypeConverter_InvalidOperation_NotSupported
					.FormatWith(CultureInfo.InvariantCulture, initialType, targetType)
				);
		}

		private static bool IsConvertible(Type t)
		{
			return (
				   t == typeof(bool)
				|| t == typeof(byte)
				|| t == typeof(char)
				|| t == typeof(DateTime)
				|| t == typeof(decimal)
				|| t == typeof(double)
				|| t == typeof(short)
				|| t == typeof(int)
				|| t == typeof(long)
				|| t == typeof(sbyte)
				|| t == typeof(float)
				|| t == typeof(string)
				|| t == typeof(ushort)
				|| t == typeof(uint)
				|| t == typeof(ulong)
				|| t.GetTypeInfo().IsEnum);
		}

		private static bool IsInteger(Type t)
		{
			return (
				   t == typeof(byte)
				|| t == typeof(short)
				|| t == typeof(int)
				|| t == typeof(long)
				|| t == typeof(sbyte)
				|| t == typeof(ushort)
				|| t == typeof(uint)
				|| t == typeof(ulong));
		}
	}

}
