using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using Enexure.Fire.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Reflection.TypeExtensionsTests
{
	[TestClass]
	public class IsNullableTypeTests
	{
		[TestMethod]
		public void NullableTypes()
		{
			typeof(int?).GetTypeInfo().IsNullable().Should().Be(true);
			typeof(DateTime?).GetTypeInfo().IsNullable().Should().Be(true);
		}

		[TestMethod]
		public void NonNullableTypes()
		{
			typeof(List<int>).GetTypeInfo().IsNullable().Should().Be(false);
			typeof(int[]).GetTypeInfo().IsNullable().Should().Be(false);
		}
	}
}
