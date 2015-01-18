using System;
using Enexure.Fire.Conversion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Conversion.StringExtensions
{
	[TestClass]
	public class ToIntTest
	{
		[TestMethod]
		public void Convert_To_With_Valid_Value()
		{
			"1".To<int>().Should().Be(1);
			"-1".To<int>().Should().Be(-1);
			"0".To<int>().Should().Be(0);
		}

		[TestMethod]
		public void Convert_To_Nullable_With_Valid_Value()
		{
			"1".To<int?>().Should().Be(new int?(1));
			"-1".To<int?>().Should().Be(new int?(-1));
			"0".To<int?>().Should().Be(new int?(0));
		}

		[TestMethod]
		public void Convert_To_With_Invalid_Value()
		{
			((Action)(() => "".To<int>())).ShouldThrow<FormatException>();
			((Action)(() => ".".To<int?>())).ShouldThrow<FormatException>();

			((Action)(() => ".".To<int>())).ShouldThrow<FormatException>();
			((Action)(() => "-".To<int>())).ShouldThrow<FormatException>();
			((Action)(() => "a".To<int>())).ShouldThrow<FormatException>();
		}

	}
}
