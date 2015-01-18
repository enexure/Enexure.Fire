using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Formatting
{
	public static class IntegerExtensions
	{
		public static string Ordinal(this int number)
		{
			var ones = number % 10;
			var tens = (int)Math.Floor(number / 10M) % 10;

			if (tens == 1) {
				return "th";
			} else {
				switch (ones) {
					case 1:
						return "st";
					case 2:
						return "nd";
					case 3:
						return "rd";
					default:
						return "th";
				}
			}
		}
	}
}
