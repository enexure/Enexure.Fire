using System;
using System.Text;
using System.Collections.Generic;
using Enexure.Fire.Database;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Database.ConnectionStringTests
{
	[TestClass]
	public class ConnectionStringTests
	{
		[TestMethod]
		public void Construct_With_Api()
		{
			var connection = new ConnectionString();
			connection["Server"] = "localhost";
			connection["Database"] = "database";
			connection["User Id"] = "Username";
			connection["Password"] = "Password";
			connection["param one"] = "Value1";

			connection.ToString().Should()
				.Be("server=localhost;database=database;user id=Username;password=Password;param one=Value1;");
		}

		[TestMethod]
		public void Construct_With_Dynamic_Api()
		{
			dynamic connection = new ConnectionString();

			connection.Server = "localhost";
			connection.Database = "database";
			connection["User Id"] = "Username";
			connection.Password = "Password";

			((ConnectionString)connection).ToString().Should()
				.Be("server=localhost;database=database;user id=Username;password=Password;");
		}

		[TestMethod]
		public void Key_And_Value_Special_Characters()
		{
			var connection = new ConnectionString();
			connection["Server"] = "localhost";
			connection["Database"] = "database";
			connection["User Id"] = "Username";
			connection["Password"] = "Password";
			connection["param one"] = "Value1";

			connection.ToString().Should()
				.Be("server=localhost;database=database;user id=Username;password=Password;param one=Value1;");
		}

		[TestMethod]
		public void Parse_Connection_String()
		{
			var connection = new ConnectionString("server=localhost;database=database;user id=Username;password=Password;param one=Value1;");

			connection["Server"].Should().Be("localhost");
			connection["Database"].Should().Be("database");
			connection["User Id"].Should().Be("Username");
			connection["Password"].Should().Be("Password");
			connection["param one"].Should().Be("Value1");
		}
	}
}
