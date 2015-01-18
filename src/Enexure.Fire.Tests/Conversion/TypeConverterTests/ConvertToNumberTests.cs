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
	public class ConvertToNumberTests
	{
		[TestMethod]
		public void Convert_From_String_To_Int()
		{
			TypeConverter.Convert("1", typeof(int)).Should().Be(1);
		}

		[TestMethod]
		public void Convert_From_Invalid_String_To_Int()
		{
			((Action)(() => TypeConverter.Convert("1.0", typeof(int)))).ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void Convert_From_String_To_Float()
		{
			TypeConverter.Convert("1.0", typeof(float)).Should().Be(1.0f);
		}

		[TestMethod]
		public void Convert_From_Invalid_String_To_Float()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(float)))).ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void Convert_From_String_To_Double()
		{
			TypeConverter.Convert("1.0", typeof(double)).Should().Be(1.0d);
		}

		[TestMethod]
		public void Convert_From_Invalid_String_To_Double()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(double)))).ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void Convert_From_String_To_Decimal()
		{
			TypeConverter.Convert("1.0", typeof(decimal)).Should().Be(1.0m);
		}

		[TestMethod]
		public void Convert_From_Invalid_String_To_Decimal()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(decimal)))).ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void Convert_From_Invalid_To_Long()
		{
			TypeConverter.Convert("1", typeof(long)).Should().Be(1L);
		}

		[TestMethod]
		public void Convert_From_Invalid_String_To_Long()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(long)))).ShouldThrow<FormatException>();
		}

	}
}
