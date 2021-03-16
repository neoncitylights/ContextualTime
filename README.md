# ContextualTime
![GitHub](https://img.shields.io/github/license/neoncitylights/ContextualTime)
[![.NET](https://github.com/neoncitylights/ContextualTime/actions/workflows/dotnet.yml/badge.svg)](https://github.com/neoncitylights/ContextualTime/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/neoncitylights/ContextualTime/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/neoncitylights/ContextualTime/actions/workflows/codeql-analysis.yml)

**ContextualTime** is an experimental NLP library for understanding phrases related to dates and time, and convert it to
machine-readable data.

## System requirements
* .NET version: 5.x ([C# language version](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version#defaults): 9.0)

## Public API
### Usage
All phrases inherit from a common abstract class known as `TimePhrase`.

```c#
Parser parser = new();

// where today is e.g March 16th, 2021 00:52:19 (Tuesday)
var yesterday = parser.parse("yesterday"); // new YesterdayPhrase();
var tomorrow = parser.parse("tomorrow"); // new TomorrowPhrase();
var wayInTheFuture = parser.parse("next 2 centuries"); // new NextPhrase( 2, UnitOfTime.Century );
var friday = parser.parse("on Friday"); // new OnPhrase( DayOfWeek.Friday );
```

Every time phrase contains these properties:
 - `Quantity`: an `int` representing the amount of the specified unit of time
 - `UnitOfTime`: A member of the `UnitOfTime` enum
```c#
yesterday.Quantity; // -1 (integer)
yesterday.UnitOfTime; // UnitOfTime.Day (enum)

tomorrow.Quantity; // 1 (integer)
tomorrow.UnitOfTime; // UnitOfTime.Day (enum)

wayInTheFuture.Quantity; // 2 (integer)
wayInTheFuture.UnitOfTime; // UnitOfTime.Century (enum)

friday.Quantity; // 4 (integer) (number of days from current day)
friday.UnitOfTime; // UnitOfTime.Day (enum)
```

They can be turned into machine-readable data by calling
`GetAsDateTime()`, which will return an instance of `System.DateTime`.
```c#
// Getting machine-readable data from phrases
// The below examples convert them into strings, for the sake of an example
yesterday.GetAsDateTime().ToString(); // 03/15/2021 00:52:19
tomorrow.GetAsDateTime().ToString(); // 03/17/2021 00:52:19
wayInTheFuture.GetAsDateTime().ToString(); // 03/16/2221 00:52:19
friday.GetAsDateTime().ToString(); // 03/20/2021 00:52:19
```

### Extension methods for `System.DateTime`
The ContextualTime library provides 4 extension methods that extend the `System.DateTime` class:
 * `DateTime.AddWeeks()`: Implemented internally as `DateTime.AddDays(n * 7)`
 * `DateTime.AddDecades()`: Implemented internally as `DateTime.AddYears(n * 10)`
 * `DateTime.AddCenturies()`: Implemented internally as `DateTime.AddYears(n * 100)`
 * `DateTime.AddMillenniums()`: Implemented internally as `DateTime.AddYears(n * 1000)`

All of these methods will still handle exceptions the same way that the `AddNNN()` methods handles exceptions, in that they will throw a `ArgumentOutOfRangeException` if:
the resulting `DateTime` is less than `DateTime.MinValue` or greater than `DateTime.MaxValue`

**C# source documentation**:
 * [System.DateTime.AddDays()](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.adddays?view=net-5.0)
 * [System.DateTime.AddYears()](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addyears?view=net-5.0)
 * [System.DateTime.MinValue](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.minvalue?view=net-5.0)
 * [System.DateTime.MaxValue](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.maxvalue?view=net-5.0)
 * [System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception?view=net-5.0)

## Notes
 * Languages supported: English
 * Calendars supported: Gregorian

The current implementation is experimental and will change. As use cases are discovered and more time is spent developing, this library will eventually become stable, as with its architecture.

## License
ContextualTime is licensed under [Apache License 2.0](/LICENSE).
