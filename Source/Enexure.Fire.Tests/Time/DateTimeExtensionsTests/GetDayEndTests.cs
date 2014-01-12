using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class GetDayEndTests
	{
		[TestMethod()]
		public void Given_Standard_Time()
		{
			new DateTime(2010, 7, 21, 11, 11, 11).GetDayEnd().Should().Be(new DateTime(2010, 7, 21, 23, 59, 59));
		}

		[TestMethod()]
		public void Given_End_Of_Day()
		{
			new DateTime(2010, 7, 21, 23, 59, 59).GetDayEnd().Should().Be(new DateTime(2010, 7, 21, 23, 59, 59));
		}
	}
}
