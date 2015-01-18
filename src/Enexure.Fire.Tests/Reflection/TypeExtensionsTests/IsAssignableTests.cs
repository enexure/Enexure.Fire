using System;
using System.Reflection;
using Enexure.Fire.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Reflection.TypeExtensionsTests
{
	[TestClass]
	public class IsAssignableTests
	{
		[TestMethod]
		public void AssignableTo()
		{
			typeof(int).GetTypeInfo().IsAssignableTo<object>().Should().Be(true);
		}

		[TestMethod]
		public void AssignableFrom()
		{
			typeof(object).GetTypeInfo().IsAssignableFrom<int>().Should().Be(true);
		}

	}
}
