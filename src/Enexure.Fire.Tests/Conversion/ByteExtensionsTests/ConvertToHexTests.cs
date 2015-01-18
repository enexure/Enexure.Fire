using System;
using System.Text;
using System.Collections.Generic;
using Enexure.Fire.Conversion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Conversion.ByteExtensionsTests
{
	/// <summary>
	/// Summary description for ConvertToHex
	/// </summary>
	[TestClass]
	public class ToHexStringTests
	{
		[TestMethod]
		public void More_Than_One_Byte()
		{
			new byte[] {255, 0}.ToHexString().Should().Be("FF00");
		}

		[TestMethod]
		public void Empty_Array()
		{
			new byte[] {}.ToHexString().Should().Be("");
		}

	}
}
