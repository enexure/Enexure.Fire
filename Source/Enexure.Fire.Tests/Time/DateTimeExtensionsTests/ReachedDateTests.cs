using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class ReachedDateTests
	{
		[TestMethod()]
		public void Today_Has_Been_Reached_Today()
		{
			DateTime.Today.HasReached(DateTime.Today).Should().Be(true);
		}

		[TestMethod()]
		public void Tomorrow_Has_Not_Been_Reached_Today()
		{
			DateTime.Today.HasReached(DateTime.Today.AddDays(1)).Should().Be(false);
		}

		[TestMethod()]
		public void Yesterday_Has_Been_Reached_Today()
		{
			DateTime.Today.HasReached(DateTime.Today.AddDays(-1)).Should().Be(true);
		}
	}
}
