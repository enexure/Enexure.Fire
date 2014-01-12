using System;
using System.Reflection;

namespace Enexure.Fire.Reflection
{
	public static class TypeExtensions
	{
		/// <summary>Creates a generic type through reflection</summary>
		/// <typeparam name="T">Return type</typeparam>
		/// <param name="generic">Generic type</param>
		/// <param name="innerType">Inner type</param>
		/// <param name="args">Constructor arguments</param>
		/// <returns>Object of type <c>T</c></returns>
		public static T CreateGeneric<T>(Type generic, Type innerType, params object[] args)
			where T : class
		{
			var specificType = generic.MakeGenericType(new[] { innerType });
			return (T)Activator.CreateInstance(specificType, args);
		}

		public static object GetDefault(this TypeInfo typeInfo)
		{
			return typeInfo.IsValueType ? Activator.CreateInstance(typeInfo.AsType()) : null;
		}

		public static bool IsNullable(this TypeInfo typeInfo)
		{
			return typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		public static bool IsInstantiable(this TypeInfo typeInfo)
		{
			if (typeInfo.IsInterface) { return false; }
			if (typeInfo.IsAbstract) { return false; }
			if (typeInfo.ContainsGenericParameters) { return false; }

			return true;
		}

		public static bool IsAssignableFrom<TTarget>(this TypeInfo type)
		{
			return type.IsAssignableFrom(typeof(TTarget).GetTypeInfo());
		}

		public static bool IsAssignableTo<TTarget>(this TypeInfo type)
		{
			return typeof(TTarget).GetTypeInfo().IsAssignableFrom(type);
		}

		public static bool IsAssignableTo(this TypeInfo type, TypeInfo target)
		{
			return target.IsAssignableFrom(type);
		}

	}
}
