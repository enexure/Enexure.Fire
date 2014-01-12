using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class YearsDifferenceTests
	{
		[TestMethod()]
		public void YearsDifferenceTest()
		{
			var startDate = new DateTime(2000, 1, 1);
			var endDate = new DateTime(2010, 1, 1);

			startDate.YearsDifference(endDate).Should().Be(10);
		}
	}
}
