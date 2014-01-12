using System;
using System.Text;
using System.Collections.Generic;
using Enexure.Fire.Conversion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Conversion.TypeConverterTests
{
	/// <summary>
	/// Summary description for ConvertToNumberTests
	/// </summary>
	[TestClass]
	public class ConvertToEnumTests
	{
		private enum SampleEnum
		{
			Zero = 0,
			One = 1
		}

		[TestMethod]
		public void Convert_From_String_To_Enum()
		{
			TypeConverter.Convert("One", typeof(SampleEnum)).Should().Be(SampleEnum.One);
		}

		[TestMethod]
		public void Convert_From_Int_To_Enum()
		{
			TypeConverter.Convert(1, typeof(SampleEnum)).Should().Be(SampleEnum.One);
		}

		[TestMethod]
		public void Convert_From_Invalid_To_Enum()
		{
			((Action)(() => TypeConverter.Convert("Two", typeof(SampleEnum)))).ShouldThrow<ArgumentException>();
		}

		[TestMethod]
		public void Convert_From_Invalid_Int_To_Enum()
		{
			TypeConverter.Convert(2, typeof(SampleEnum)).Should().Be((SampleEnum)2);
		}
	}
}
