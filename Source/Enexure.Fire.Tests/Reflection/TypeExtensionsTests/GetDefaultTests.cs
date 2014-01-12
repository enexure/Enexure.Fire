using System;
using System.Reflection;
using Enexure.Fire.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Reflection.TypeExtensionsTests
{
	[TestClass]
	public class GetDefaultTests
	{
		[TestMethod]
		public void ValueTypes()
		{
			typeof(int).GetTypeInfo().GetDefault().Should().Be(default(int));
			typeof(DateTime).GetTypeInfo().GetDefault().Should().Be(default(DateTime));
		}

		[TestMethod]
		public void ReferenceTypesTypes()
		{
			typeof(object).GetTypeInfo().GetDefault().Should().Be(default(Object));
			typeof(object).GetTypeInfo().GetDefault().Should().Be(null);
		}
	}
}
