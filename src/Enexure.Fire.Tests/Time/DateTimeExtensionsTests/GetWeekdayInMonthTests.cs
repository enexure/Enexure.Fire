using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class GetWeekdayInMonthTests
	{
		[TestMethod()]
		public void Test1()
		{
			var date = new DateTime(2010, 07, 1).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 1));

			date.Month.Should().Be(7);
			date.DayOfWeek.Should().Be(DayOfWeek.Thursday);
			date.Day.Should().Be(1);
		}

		[TestMethod()]
		public void Test2()
		{
			var date = new DateTime(2010, 08, 20).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 1));

			date.Month.Should().Be(8);
			date.DayOfWeek.Should().Be(DayOfWeek.Thursday);
			date.Day.Should().Be(5);
		}

		[TestMethod()]
		public void Test3()
		{
			var date = new DateTime(2010, 09, 11).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 1));

			date.Month.Should().Be(9);
			date.DayOfWeek.Should().Be(DayOfWeek.Thursday);
			date.Day.Should().Be(2);
		}


		[TestMethod()]
		public void Test4()
		{
			var date = new DateTime(2010, 07, 15).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 31));

			date.Month.Should().Be(7);
			date.DayOfWeek.Should().Be(DayOfWeek.Saturday);
			date.Day.Should().Be(31);
		}

		[TestMethod()]
		public void Test5()
		{
			var date = new DateTime(2010, 08, 21).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 31));

			date.Month.Should().Be(8);
			date.DayOfWeek.Should().Be(DayOfWeek.Saturday);
			date.Day.Should().Be(28);
		}

		[TestMethod()]
		public void Test6()
		{
			var date = new DateTime(2010, 09, 11).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 31));

			date.Month.Should().Be(9);
			date.DayOfWeek.Should().Be(DayOfWeek.Saturday);
			date.Day.Should().Be(25);
		}


		[TestMethod()]
		public void Test7()
		{
			var date = new DateTime(2010, 07, 30).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 16));

			date.Month.Should().Be(7);
			date.DayOfWeek.Should().Be(DayOfWeek.Friday);
			date.Day.Should().Be(16);
		}

		[TestMethod()]
		public void Test8()
		{
			var date = new DateTime(2010, 06, 11).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 16));

			date.Month.Should().Be(6);
			date.DayOfWeek.Should().Be(DayOfWeek.Friday);
			date.Day.Should().Be(18);
		}

		[TestMethod()]
		public void Test9()
		{
			var date = new DateTime(2010, 08, 12).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 16));

			date.Month.Should().Be(8);
			date.DayOfWeek.Should().Be(DayOfWeek.Friday);
			date.Day.Should().Be(20);
		}

		[TestMethod()]
		public void Test10()
		{
			var date = new DateTime(2010, 07, 17).ToSpecificMonth().GetDateMatching(new DateTime(2010, 7, 17));

			date.Month.Should().Be(7);
			date.DayOfWeek.Should().Be(DayOfWeek.Saturday);
			date.Day.Should().Be(17);
		}

		[TestMethod()]
		public void Test11()
		{
			const int month = 7;
			const int year = 2010;

			for (var i = 1; i < DateTime.DaysInMonth(year, month); i++) {

				// They are the same date
				var start = new DateTime(year, month, i);
				var current = new DateTime(year, month, i);

				var date = current.ToSpecificMonth().GetDateMatching(start);

				date.Month.Should().Be(month);
				date.DayOfWeek.Should().Be(start.DayOfWeek);
				date.Day.Should().Be(i);
			}
		}

	}
}
