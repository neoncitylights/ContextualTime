# ContextualTime
![GitHub](https://img.shields.io/github/license/neoncitylights/ContextualTime)
[![.NET](https://github.com/neoncitylights/ContextualTime/actions/workflows/dotnet.yml/badge.svg)](https://github.com/neoncitylights/ContextualTime/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/neoncitylights/ContextualTime/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/neoncitylights/ContextualTime/actions/workflows/codeql-analysis.yml)

**ContextualTime** is an experimental NLP library for understanding phrases related to dates and time, and convert it to
machine-readable data.

## Overview
- [ContextualTime](#contextualtime)
	- [Overview](#overview)
	- [System requirements](#system-requirements)
	- [Concepts](#concepts)
	- [Public API](#public-api)
		- [Usage](#usage)
		- [Extension methods for `System.DateTime`](#extension-methods-for-systemdatetime)
			- [Dynamically modifying a `System.DateTime`](#dynamically-modifying-a-systemdatetime)
	- [Notes](#notes)
	- [License](#license)

## System requirements
* .NET version: 5.x ([C# language version](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version#defaults): 9.0)

## Concepts
There are certain concepts that are mentioned throughout this documentation. It may help to read the [glossary](./GLOSSARY.md) file before proceeding further. 

## Public API
### Usage
All phrases inherit from a common abstract class known as `TimePhrase`.

```c#
Parser parser = new();

// where today is e.g March 16th, 2021 00:52:19 (Tuesday)
var yesterday = parser.parse( "yesterday" ); // new YesterdayPhrase();
var tomorrow = parser.parse( "tomorrow" ); // new TomorrowPhrase();
var wayInTheFuture = parser.parse( "next 2 centuries" ); // new NextPhrase( 2, UnitOfTime.Century );
var friday = parser.parse( "on Friday" ); // new OnPhrase( DayOfWeek.Tuesday, DayOfWeek.Friday );
```

Every time phrase contains these properties:
 - `Preposition`: A word as a `string`, representing the relationship of a point in time time to another point in time (specifically in this context)
 - `Quantity`: an `int` representing the amount of the specified unit of time
 - `UnitOfTime`: A member of the [UnitOfTime](./src/ContextualTime/UnitOfTime.cs) enum 
 - `Tense`: A member of the [Tense](./src/ContextualTime/Tense.cs) enum, which can either be the past, present, or future
```c#
yesterday.Preposition; // "yesterday"
yesterday.Quantity; // -1 (integer)
yesterday.UnitOfTime; // UnitOfTime.Day (enum)
yesterday.Tense; // Tense.Past (enum)

tomorrow.Preposition; // "tomorrow"
tomorrow.Quantity; // 1 (integer)
tomorrow.UnitOfTime; // UnitOfTime.Day (enum)
tomorrow.Tense; // Tense.Future (enum)

wayInTheFuture.Preposition; // "next"
wayInTheFuture.Quantity; // 2 (integer)
wayInTheFuture.UnitOfTime; // UnitOfTime.Century (enum)
wayInTheFuture.Tense; // Tense.Future (enum)

friday.Preposition; // "on"
friday.Quantity; // 3 (integer) (number of days from current day)
friday.UnitOfTime; // UnitOfTime.Day (enum)
friday.Tense; // Tense.Future (enum)
```

They can be turned into machine-readable data by calling
`GetAsDateTime()`, which will return an instance of `System.DateTime`.
```c#
// Getting machine-readable data from phrases
// The below examples convert them into strings, for the sake of an example
yesterday.GetAsDateTime().ToString(); // 03/15/2021 00:52:19
tomorrow.GetAsDateTime().ToString(); // 03/17/2021 00:52:19
wayInTheFuture.GetAsDateTime().ToString(); // 03/16/2221 00:52:19
friday.GetAsDateTime().ToString(); // 03/19/2021 00:52:19
```

### Extension methods for `System.DateTime`
The ContextualTime library provides the [DateTimeExtensions](./src/ContextualTime/DateTimeExtensions.cs) class, which holds extension methods for the `System.DateTime` class.
 * `DateTime.AddWeeks( int )`: Implemented internally as `DateTime.AddDays( n * 7 )`
 * `DateTime.AddDecades( int )`: Implemented internally as `DateTime.AddYears( n * 10 )`
 * `DateTime.AddCenturies( int )`: Implemented internally as `DateTime.AddYears( n * 100 )`
 * `DateTime.AddMillenniums( int )`: Implemented internally as `DateTime.AddYears( n * 1000 )`

> All of these methods will still handle exceptions the same way that the `AddNNN()` methods handles exceptions, in that they will throw a [System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception?view=net-5.0) if the resulting `DateTime` is less than [System.DateTime.MinValue](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.minvalue?view=net-5.0) or greater than [System.DateTime.MaxValue](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.maxvalue?view=net-5.0).

**C# source documentation**:
 * [System.DateTime.AddDays()](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.adddays?view=net-5.0)
 * [System.DateTime.AddYears()](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addyears?view=net-5.0)

#### Dynamically modifying a `System.DateTime`
The library provides another declarative extension method to dynamically modify a `System.DateTime` instance, called `DateTime.AddByUnit()`. Internally, it maps the member of the UnitOfTime enum to a function call. The method signature follows as:
```c#
AddByUnit( DateTime, int, UnitOfTime );
```
**Usage**
```c#
// e.g today is March 20th, 2021, at 1:35:59 PM (13:35:59), on Saturday
// outputted as a string in standard format as: 03/20/2021 13:35:59
DateTime today = DateTime.Now;

// Go forward 2 weeks
// internally calls `DateTime.AddWeeks( 2 )`, which calls `DateTime.AddDays( 14 )`
today.AddByUnit( 2, UnitOfTime.Week ); // 04/03/2021 13:35:59 (DateTime instance)

// Go back 3 days
// internally calls `DateTime.AddDays( -3 )`
today.AddByUnit( -3, UnitOfTime.Day ); // 03/17/2021 13:35:59 (DateTime instance)
```

## Notes
 * Languages supported: English
 * Calendars supported: Gregorian

The current implementation is experimental and will change. As use cases are discovered and more time is spent developing, this library will eventually become stable, as with its architecture.

## License
ContextualTime is licensed under [Apache License 2.0](/LICENSE).
