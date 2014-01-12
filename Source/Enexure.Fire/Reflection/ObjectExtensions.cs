using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Enexure.Fire.Reflection
{
	public static class ObjectExtensions
	{
		/// <summary>Gets the name of the property used in an expression</summary>
		/// <typeparam name="T">Property owner</typeparam>
		/// <typeparam name="P">Property return type</typeparam>
		/// <param name="instance">Instance used to derive <c>T</c></param>
		/// <param name="expression">Expression used to derive <c>P</c></param>
		/// <returns>Property name</returns>
		public static string GetPropertyName<T, P>(this T instance, Expression<Func<T, P>> expression)
		{
			var member = expression.Body as MemberExpression;
			if (member != null) {

				var property = (member.Member as PropertyInfo);
				if (property != null) {
					return property.Name;
				}
			}
			throw new NullReferenceException("Expression body or body member are null");
		}


		/// <summary>Gets the name and type of the property used in an expression</summary>
		/// <typeparam name="T">Property owner</typeparam>
		/// <typeparam name="P">Property return type</typeparam>
		/// <param name="instance">Instance used to derive <c>T</c></param>
		/// <param name="expression">Expression used to derive <c>P</c></param>
		/// <returns>Property details in the form of a <c>PropertyDetails</c> instance</returns>
		public static PropertyDetails GetPropertyDetail<T, P>(this T instance, Expression<Func<T, P>> expression)
		{
			var member = expression.Body as MemberExpression;
			if (member != null) {

				var property = (member.Member as PropertyInfo);
				if (property != null) {
					return new PropertyDetails(property.PropertyType, property.Name);
				}
			}
			throw new NullReferenceException("Expression body or body member are null");
		}

		public class PropertyDetails
		{
			public PropertyDetails(Type type, string name)
			{
				Type = type;
				Name = name;
			}

			public Type Type { get; internal set; }
			public string Name { get; internal set; }
		}
	}
}
