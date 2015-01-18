using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class GetNextWeekdayTests
	{
		[TestMethod()]
		public void Saturday_Shows_Monday()
		{
			new DateTime(2010, 7, 17).GetNextWeekday().Should().Be(new DateTime(2010, 7, 19));
		}

		[TestMethod()]
		public void Sunday_Shows_Monday()
		{
			new DateTime(2010, 7, 18).GetNextWeekday().Should().Be(new DateTime(2010, 7, 19));
		}

		[TestMethod()]
		public void Weekday_Shows_Same_Day()
		{
			new DateTime(2010, 7, 19).GetNextWeekday().Should().Be(new DateTime(2010, 7, 19));
		}
	}
}
