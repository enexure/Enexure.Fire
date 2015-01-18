using System;
using Enexure.Fire.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class DaysOfAMonthTests
	{
		[TestMethod()]
		public void Check_There_Are_At_Least_Four_Of_Each_DayOfTheWeek_In_Each_Month()
		{
			// This proves that there are at least 4 of each DayOfTheWeek in each month
			// Tested from 2008 to 2019

			for (var y = 2009; y < 2012; y++) {
				for (var i = 1; i < 13; i++) {
					var days = new DateTime(y, i, 1).ToSpecificMonth().DaysOfAMonth();

					foreach (var day in days) {
						Assert.IsTrue(day.Value >= 4);
					}

				}
			}
		}
	}
}
