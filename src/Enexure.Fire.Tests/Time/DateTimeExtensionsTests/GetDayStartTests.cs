using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class GetDayStartTests
	{
		[TestMethod()]
		public void Given_Standard_Time()
		{
			new DateTime(2010, 7, 21, 11, 11, 11).GetDayStart().Should().Be(new DateTime(2010, 7, 21, 0, 0, 0));
		}

		[TestMethod()]
		public void Given_Start_Of_Day()
		{
			new DateTime(2010, 7, 21, 0, 0, 0).GetDayStart().Should().Be(new DateTime(2010, 7, 21, 0, 0, 0));
		}
	}
}
