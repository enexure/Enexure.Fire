using Enexure.Fire.Conversion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Conversion.StringExtensionsTests
{
	[TestClass]
	public class ToDefaultTests
	{
		[TestMethod]
		public void Convert_To_With_Valid_Value()
		{
			"1".ToOrDefault<int>().Should().Be(1);
			"-1".ToOrDefault<int>().Should().Be(-1);
			"0".ToOrDefault<int>().Should().Be(0);
		}

		[TestMethod]
		public void Convert_To_Nullable_With_Valid_Value()
		{
			"1".ToOrDefault<int?>().Should().Be(new int?(1));
			"-1".ToOrDefault<int?>().Should().Be(new int?(-1));
			"0".ToOrDefault<int?>().Should().Be(new int?(0));
		}

		[TestMethod]
		public void Convert_To_With_Invalid_Value()
		{
			"".ToOrDefault<int?>().Should().Be(new int?());
			".".ToOrDefault<int?>().Should().Be(new int?());
			".".ToOrDefault<int?>().Should().Be(new int?());
			"-".ToOrDefault<int?>().Should().Be(new int?());
			"a".ToOrDefault<int?>().Should().Be(new int?());
		}
	}
}
