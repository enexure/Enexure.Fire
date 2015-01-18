using System;
using Enexure.Fire.Formatting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Formatting.StringExtensionsTests
{
	[TestClass]
	public class FromPascelCaseTests
	{
		[TestMethod()]
		public void Aplha_Characters()
		{
			"CaseTest".FromPascelCase().Should().Be("Case Test");
		}

		[TestMethod()]
		public void Digits_After_Aplha_Characters()
		{
			"Word123".FromPascelCase().Should().Be("Word 123");
		}

		[TestMethod()]
		public void Word_After_Uppercase_Characters()
		{
			"NApples".FromPascelCase().Should().Be("N Apples");
		}

		[TestMethod()]
		public void Word_After_Number_Characters()
		{
			"1Apple".FromPascelCase().Should().Be("1 Apple");
		}

		[TestMethod()]
		public void Symbols_Stay_Together()
		{
			"1A^B@C#D%E".FromPascelCase().Should().Be("1A^B@C#D%E");
		}

	}
}
