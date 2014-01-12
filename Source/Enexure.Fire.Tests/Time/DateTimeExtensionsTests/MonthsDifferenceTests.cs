using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class MonthsDifferenceTests
	{
		[TestMethod()]
		public void Zero_Months_Appart()
		{
			new DateTime(2009, 1, 1).MonthsDifferenceWith(new DateTime(2009, 1, 1)).Should().Be(0);
		}

		[TestMethod()]
		public void One_Month_Appart()
		{
			new DateTime(2009, 1, 1).MonthsDifferenceWith(new DateTime(2009, 2, 1)).Should().Be(1);
		}

		[TestMethod()]
		public void Over_A_Year_Appart()
		{
			new DateTime(2009, 1, 1).MonthsDifferenceWith(new DateTime(2010, 12, 1)).Should().Be(23);
		}

	}
}
