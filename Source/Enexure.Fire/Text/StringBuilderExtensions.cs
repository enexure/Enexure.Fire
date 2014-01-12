using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Text
{
	public static class StringBuilderExtensions
	{
		/// <summary>
		/// Removes all text from a string builder
		/// </summary>
		public static void Clear(this StringBuilder target)
		{
			target.Remove(0, target.Length);
		}
	}
}
