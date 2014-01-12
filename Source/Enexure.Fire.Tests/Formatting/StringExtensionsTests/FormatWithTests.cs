using System;
using Enexure.Fire.Formatting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Formatting.StringExtensionsTests
{
	/// <summary>
	/// Summary description for FormatWithTests
	/// </summary>
	[TestClass]
	public class FormatWithTests
	{
		[TestMethod]
		public void ComposedCorrectly()
		{
			"{0}".FormatWith("abc").Should().Be("abc");
		}
	}
}
