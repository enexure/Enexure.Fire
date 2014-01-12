using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Formatting
{
	public static class StringExtensions
	{
		/// <summary>
		/// Replaces the format item in a specified string with the string representation
		/// of a corresponding object in a specified array.
		/// </summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>
		/// A copy of format in which the format items have been replaced by the string
		/// representation of the corresponding objects in args.
		/// </returns>
		/// <exception cref="ArgumentNullException">format or args is null.</exception>
		/// <exception cref="FormatException">
		/// format is invalid.-or- The index of a format item is less than zero, or greater
		/// than or equal to the length of the args array.
		/// </exception>
		public static string FormatWith(this string format, params object[] args)
		{
			return string.Format(format, args);
		}

		/// <summary>
		/// Ensures the first character of the string is uppercase
		/// </summary>
		public static string Capitalise(this string value)
		{
			if (!string.IsNullOrEmpty(value)) {
				return char.ToUpper(value[0]) + value.Substring(1);
			} else {
				return value;
			}
		}

		/// <summary>
		/// Tries to create a phrase string from PascelCase text.
		/// Can handle uppercase groups, dates, numbers and spaces
		/// </summary>
		public static string FromPascelCase(this string value)
		{
			if (value != null && value.Length > 1) {

				var sb = new StringBuilder(value.Length + 5);

				var first = true;
				var wasSpace = false;
				var charBefore = '\0';
				var charCurrent = '\0';
				var charAfter = value[0];
				var lengthMinusOne = value.Length - 1;

				int charIndex = 0;
				for (; charIndex < lengthMinusOne; charIndex++) {
					// Pre
					charCurrent = charAfter;
					charAfter = value[charIndex + 1];

					// Action

					if (!first &&
						!wasSpace &&
						!char.IsWhiteSpace(charCurrent) &&
						(char.IsUpper(charCurrent) && char.IsLower(charAfter) || // Start of Word
						 char.IsDigit(charCurrent) && char.IsLetter(charBefore) // Letter to Number
						)) {

						sb.Append(' ');
					}

					sb.Append(charCurrent);
					wasSpace = char.IsWhiteSpace(charCurrent);
					first = false;

					// Post
					charBefore = charCurrent;
				}

				sb.Append(value[charIndex]);
				return sb.ToString();

			} else {
				return value;
			}
		}
	}
}
