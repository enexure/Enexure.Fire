using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Fire.Conversion
{
	public static class ByteExtensions
	{
		/// <summary>Converts a byte array into it's string hex representation</summary>
		/// <param name="target">Source byte array</param>
		/// <returns>Hex string</returns>
		public static string ToHexString(this byte[] target)
		{
			return ToHexString(target, 0, target.Length);
		}

		/// <summary>Converts a byte array into it's string hex representation</summary>
		/// <param name="target">Source byte array</param>
		/// <param name="startIndex">Starting index for the byte array</param>
		/// <param name="length">Number of bytes to convert</param>
		/// <returns>Hex string</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the bounds of the array are exceeded</exception>
		/// <exception cref="ArgumentException">Thrown when the selected range exceeds the bounds of the array</exception>
		public static string ToHexString(this byte[] target, int startIndex, int length)
		{
			if (target == null) {
				throw new ArgumentNullException("target");
			}

			var sourceLenght = target.Length;
			if ((startIndex < 0) || ((startIndex >= sourceLenght) && (startIndex > 0))) {
				throw new ArgumentOutOfRangeException("startIndex", ExceptionMessages.Enexure_ArgumentOutOfRange_Index);
			}

			if (length < 0) {
				throw new ArgumentOutOfRangeException("length", ExceptionMessages.Enexure_ArgumentOutOfRange_GenericPositive);
			}

			if (length > (sourceLenght - startIndex)) {
				throw new ArgumentException(ExceptionMessages.Enexure_ArgumentOutOfRange_SequenceExceedsBounds);
			}

			if (length == 0) {
				return string.Empty;
			}

			if (length > 0x2aaaaaaa) {
				throw new ArgumentOutOfRangeException("length", ExceptionMessages.Enexure_ArgumentOutOfRange_LengthTooLarge);
			}

			var hexStringLength = length * 2;
			var chArray = new char[hexStringLength];

			var index = 0;
			var currentIndex = startIndex;
			for (index = 0; index < hexStringLength; index += 2) {

				var currentByte = target[currentIndex++];
				chArray[index] = GetHexValue(currentByte / 0x10); // Or 16
				chArray[index + 1] = GetHexValue(currentByte % 0x10);
			}
			return new string(chArray);
		}

		private static char GetHexValue(int i)
		{
			if (i < 10) {
				return (char)(i + 0x30);
			}
			return (char)((i - 10) + 0x41);
		}
	}
}
