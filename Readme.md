#Enexure.Fire

Fire is a library of useful helpers and extension methods.

##Conversion

###Conversion string.ToOrDefault&lt;T>()

Convert string to T or Default

	"1".ToOrDefault<int>() // Should().Be(1);
    
Even works will nullable types

	"".ToOrDefault<int?>() // Should().Be(new int?());

###Conversion string.To&lt;T>()

`To` will only work for properly formatted values

	"1".To<int>() // Should().Be(1);

	"".To<int>() // Throws FormatException

###Conversion string.ToHexString()

	new byte[] {255, 0}.ToHexString().Should().Be("FF00");

##Formatting

###Conversion string.Capitalise()

	"hello World".Capitalise() // Should().Be("Hello World");

###Conversion string.FormatWith()

	"{0}".FormatWith("abc") // Should().Be("abc");

###Conversion string.FromPascelCase()

	"CaseTestOne".FromPascelCase() // Should().Be("Case Test One");

##Time

###Conversion specificMonth.GetPlaceInMonth()

Finds the {First | Second | Third | Last} {Day | Weekday | WeekendDay | Monday | Tuesday | etc...} in a given month.

	dateTime.ToSpecificMonth().GetPlaceInMonth(Place.Last, Weekday.Friday)

###Conversion dateTime.GetClosestWeekday()

Gets the closest weekday from the given date.

	dateTime.GetClosestWeekday()

###Conversion dateTime.GetNextWeekday()

Gets the next weekday from the given date.

	dateTime.GetNextWeekday()


##Database

Manipulate connection strings

	dynamic connection = new ConnectionString();
	
	connection.Server = "localhost";
	connection.Database = "database";
	connection["User Id"] = "Username";
	connection.Password = "Password";
	
	var connString = ((ConnectionString)connection);
	connString.ToString() // Should().Be("server=localhost;database=database;user id=Username;password=Password;");