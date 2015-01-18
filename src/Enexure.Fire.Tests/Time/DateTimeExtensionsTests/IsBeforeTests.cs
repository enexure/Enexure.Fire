using System;
using Enexure.Fire.Time;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Time.DateTimeExtensionsTests
{
	[TestClass]
	public class IsBeforeTests
	{
		[TestMethod()]
		public void Today_Is_Not_Before_Today()
		{
			DateTime.Today.IsBefore(DateTime.Today).Should().Be(false);
		}

		[TestMethod()]
		public void Tomorrow_Is_Before_Today()
		{
			DateTime.Today.IsBefore(DateTime.Today.AddDays(1)).Should().Be(true);
		}

		[TestMethod()]
		public void Today_Is_Not_Before_Yesterday()
		{
			DateTime.Today.IsBefore(DateTime.Today.AddDays(-1)).Should().Be(false);
		}
	}
}
