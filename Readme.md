Enexure.Fire
=================
[![Build status](https://ci.appveyor.com/api/projects/status/yi1juam8rmgmj7mo/branch/master?svg=true)](https://ci.appveyor.com/project/Daniel45729/enexure-fire/branch/master)

Fire is a library of useful helpers and extension methods.

> PM> Install-Package [Enexure.Fire](https://www.nuget.org/packages/Enexure.Fire/)

###Linq

**enumerable.None()**
 
Checks if there are no items in a sequence

	enumerable.None() // Should().Be(true)

**enumerable.Do()**

Iterates over the elements in the enumerable.

	enumerable.Do(x => x.Update())

**enumerable.Done()**

Iterates over the elements in the enumerable.

	enumerable.Done()

**enumerable.Prepend()**

Creatres a new enumerable with the new element prepended.

	enumerable.Prepend(element)

**enumerable.Append()**

Creatres a new enumerable with the new element appended.

	enumerable.Append(element)

###Conversion

**string.ToOrDefault&lt;T>()**

Convert string to T or Default

	"1".ToOrDefault<int>() // Should().Be(1);
    
Even works will nullable types

	"".ToOrDefault<int?>() // Should().Be(new int?());

**string.To&lt;T>()**

`To` will only work for properly formatted values

	"1".To<int>() // Should().Be(1);

	"".To<int>() // Throws FormatException

**string.ToHexString()**

	new byte[] {255, 0}.ToHexString().Should().Be("FF00");

###Formatting

**string.Capitalise()**

	"hello World".Capitalise() // Should().Be("Hello World");

**string.FormatWith()**

	"{0}".FormatWith("abc") // Should().Be("abc");

**string.FromPascelCase()**

	"CaseTestOne".FromPascelCase() // Should().Be("Case Test One");

###Time

**specificMonth.GetPlaceInMonth()**

Finds the {First | Second | Third | Last} {Day | Weekday | WeekendDay | Monday | Tuesday | etc...} in a given month.

	dateTime.ToSpecificMonth().GetPlaceInMonth(Place.Last, Weekday.Friday)

**dateTime.GetClosestWeekday()**

Gets the closest weekday from the given date.

	dateTime.GetClosestWeekday()

**dateTime.GetNextWeekday()**

Gets the next weekday from the given date.

	dateTime.GetNextWeekday()
