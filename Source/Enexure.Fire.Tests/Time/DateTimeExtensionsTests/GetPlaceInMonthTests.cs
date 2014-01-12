using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class GetPlaceInMonthTests
	{
		[TestMethod()]
		public void First_Day()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.First, Weekday.Day).Should().Be(new DateTime(2011, 1, 1));
		}

		[TestMethod()]
		public void Second_Day()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Second, Weekday.Day).Should().Be(new DateTime(2011, 1, 2));
		}

		[TestMethod()]
		public void Third_Day()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Third, Weekday.Day).Should().Be(new DateTime(2011, 1, 3));
		}

		[TestMethod()]
		public void Last_Day()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Last, Weekday.Day).Should().Be(new DateTime(2011, 1, 31));
		}


		[TestMethod()]
		public void First_Weekday()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.First, Weekday.Weekday).Should().Be(new DateTime(2011, 1, 3));
		}

		[TestMethod()]
		public void Second_Weekday()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Second, Weekday.Weekday).Should().Be(new DateTime(2011, 1, 4));
		}

		[TestMethod()]
		public void Third_Weekday()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Third, Weekday.Weekday).Should().Be(new DateTime(2011, 1, 5));
		}

		[TestMethod()]
		public void Last_Weekday()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Last, Weekday.Weekday).Should().Be(new DateTime(2011, 1, 31));
		}


		[TestMethod()]
		public void First_WeekendDay()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.First, Weekday.WeekendDay).Should().Be(new DateTime(2011, 1, 1));
		}

		[TestMethod()]
		public void Second_WeekendDay()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Second, Weekday.WeekendDay).Should().Be(new DateTime(2011, 1, 2));
		}

		[TestMethod()]
		public void Third_WeekendDay()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Third, Weekday.WeekendDay).Should().Be(new DateTime(2011, 1, 8));
		}

		[TestMethod()]
		public void Last_WeekendDay()
		{
			new DateTime(2011, 1, 1).ToSpecificMonth().GetPlaceInMonth(Place.Last, Weekday.WeekendDay).Should().Be(new DateTime(2011, 1, 30));
		}

	}
}
