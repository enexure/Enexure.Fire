using System;
using System.Text;
using System.Collections.Generic;
using Enexure.Fire.Conversion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Conversion.TypeConverterTests
{
	/// <summary>
	/// Summary description for ConvertToNumberTests
	/// </summary>
	[TestClass]
	public class ConvertToUnsupportedTests
	{
		[TestMethod]
		public void Convert_From_String_To_Object()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(object)))).ShouldThrow<InvalidOperationException>();
		}

		[TestMethod]
		public void Convert_From_String_To_Abstract_Class()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(object)))).ShouldThrow<InvalidOperationException>();
		}

		[TestMethod]
		public void Convert_From_String_To_Empty_Generic_Class()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(List<>)))).ShouldThrow<ArgumentException>();
		}

		private interface ITestInterface { }

		[TestMethod]
		public void Convert_From_String_To_Interface()
		{
			((Action)(() => TypeConverter.Convert("a", typeof(ITestInterface)))).ShouldThrow<ArgumentException>();
		}
	}
}
