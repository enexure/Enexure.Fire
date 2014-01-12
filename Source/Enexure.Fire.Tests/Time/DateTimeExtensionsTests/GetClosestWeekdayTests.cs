using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class UniGetClosestWeekdayTeststTests
	{
		[TestMethod()]
		public void From_Saturday()
		{
			new DateTime(2010, 7, 17).GetClosestWeekday().Should().Be(new DateTime(2010, 7, 16));
		}

		[TestMethod()]
		public void From_Sunday()
		{
			new DateTime(2010, 7, 18).GetClosestWeekday().Should().Be(new DateTime(2010, 7, 19));
		}

		[TestMethod()]
		public void From_Weekday()
		{
			new DateTime(2010, 7, 19).GetClosestWeekday().Should().Be(new DateTime(2010, 7, 19));
		}
	}
}
