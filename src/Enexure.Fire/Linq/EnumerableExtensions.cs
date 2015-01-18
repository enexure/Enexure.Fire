using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enexure.Fire.Contract;

namespace Enexure.Fire.Linq
{
	public static class EnumerableExtensions
	{
		/// <summary>Checks if there are no items in a sequence</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="items">The System.Collections.Generic.IEnumerable&lt;T&gt; to check for emptiness.</param>
		/// <returns><c>true</c> if the source sequence contains no elements; otherwise, <c>false</c>.</returns>
		public static bool None<T>(this IEnumerable<T> items)
		{
			return !items.Any();
		}

		/// <summary>Checks if there are no items in a sequence matching a condition</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="items">The System.Collections.Generic.IEnumerable&lt;T&gt; to check for emptiness.</param>
		/// <param name="predicate">A function to test each source element for a condition</param>
		/// <returns><c>true</c> if the source sequence contains no elements; otherwise, <c>false</c>.</returns>
		public static bool None<T>(this IEnumerable<T> items, Func<T, bool> predicate)
		{
			return !items.Any(predicate);
		}

		/// <summary>Filters out <c>null</c> items from an Enumerable</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="items">Items to iterate</param>
		/// <returns>Filtered set of items</returns>
		public static IEnumerable<T> NotNull<T>(this IEnumerable<T> items) where T : class
		{
			return items.Where(item => item != null);
		}

		/// <summary>Invokes an action for each item an an Enumerable</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="items">Items to iterate</param>
		/// <param name="action">Action to perform</param>
		/// <returns><c>items</c></returns>
		public static IEnumerable<T> Do<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (var item in items) {
				action(item);
				yield return item;
			}
		}

		/// <summary>Force enumeration</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="items">Items to enumeratye</param>
		public static void Done<T>(this IEnumerable<T> items)
		{
			var enumerator = items.GetEnumerator();
			while (enumerator.MoveNext()) {
				// Just force enumeration; that's all.
			}
		}

		/// <summary>Adds a single element to the end of an IEnumerable.</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <returns>
		/// IEnumerable containing all the input elements, followed by the
		/// specified additional element.
		/// </returns>
		public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T last)
		{
			list.Require("list");

			foreach (var item in list) {
				yield return item;
			}
			yield return last;
		}

		/// <summary>Adds a single element to the start of an IEnumerable.</summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <returns>
		/// IEnumerable containing the specified additional element, followed by
		/// all the input elements.
		/// </returns>
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> tail, T head)
		{
			tail.Require("tail");

			yield return head;
			foreach (var item in tail) {
				yield return item;
			}
		}

	}
}
