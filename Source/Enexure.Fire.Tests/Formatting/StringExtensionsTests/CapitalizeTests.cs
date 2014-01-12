using System;
using Enexure.Fire.Formatting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Formatting.StringExtensionsTests
{
	[TestClass]
	public class CapitalizeTests
	{
		[TestMethod]
		public void Made_Upper()
		{
			"hello World".Capitalise().Should().Be("Hello World");
		}

		[TestMethod]
		public void Already_Upper()
		{
			"Hello World".Capitalise().Should().Be("Hello World");
		}

		[TestMethod]
		public void Single_Letter()
		{
			"i".Capitalise().Should().Be("I");
		}

		[TestMethod]
		public void Number()
		{
			"1".Capitalise().Should().Be("1");
		}

		[TestMethod]
		public void Symbol()
		{
			"@".Capitalise().Should().Be("@");
		}
	}
}