using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class IsAfterTests
	{
		[TestMethod()]
		public void Today_Is_Not_After_Today()
		{
			DateTime.Today.IsAfter(DateTime.Today).Should().Be(false);
		}

		[TestMethod()]
		public void Today_Is_Not_After_Tomorrow()
		{
			DateTime.Today.IsAfter(DateTime.Today.AddDays(1)).Should().Be(false);
		}

		[TestMethod()]
		public void Today_Is_After_Yesterday()
		{
			DateTime.Today.IsAfter(DateTime.Today.AddDays(-1)).Should().Be(true);
		}
	}
}
