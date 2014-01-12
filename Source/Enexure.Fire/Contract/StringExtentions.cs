using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Contract
{
	public static class StringExtentions
	{
		/// <summary>Specify a parameter as required</summary>
		/// <typeparam name="T">Type of the parameter</typeparam>
		/// <param name="item">Instance of the the parameter</param>
		/// <param name="name">Name of the parameter</param>
		/// <exception cref="ArgumentException">Thrown if <c>item</c> is <c>null</c>.</exception>
		public static void Require<T>(this T item, string name)
			where T : class
		{
			if (item == null) {
				throw new ArgumentException(string.Format(ExceptionMessages.Enexure_Fire_Contract_Required_ValueIsNull, name));
			}
		}
	}
}
