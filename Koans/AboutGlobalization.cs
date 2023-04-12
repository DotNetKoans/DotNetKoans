#pragma warning disable xUnit2009
using Xunit;
using System.Threading;
using System;
using System.Globalization;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

class AboutGlobalization : Koan
{
	[Step(1)]
	public void AllStringsAreUTF16()
	{
		// Unicode strings consist of several Char objects which
		// are represented by a UTF-16 code. Unicode exists for 
		// almost every character throughout the world.

		var str = "﻿ü";
		Assert.Equal("﻿ü", FILL_ME_IN);
	}

	[Step(2)]
	public void TreatStringsAsStrings()
	{
		// When utilizing string searches / comparasions, rather than
		// treating the string as a collection of Char objects, it is 
		// better to treat each Char as a string. This is because 
		// a single character may consist of 1 or more Char objects.
		// In the example below, the unicode character ﻿ü can be represented
		// two different ways, as a single code unit U00FC, or as two code
		// units U0075 and U0308.

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de-DE");

		string composite = "\u0075\u0308"; // ﻿ü
		Assert.Equal(0, composite.IndexOf('\u00fc'));

	}

	[Step(3)]
	public void TestingStringsForEquality()
	{
		// Non-linguistic comparasions should always be Ordinal rather than
		// culture specific. For passwords, you should use 
		// StringComparison.Ordinal and for filesystem access, you should use
		// StringComparison.OrdinalIgnoreCase

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR");

		string uri = @"file:\\c:\users\uname\Desktop\test.txt";

		Assert.True(uri.StartsWith("FILE", true, CultureInfo.CurrentCulture));

	}

	[Step(4)]
	public void OrderingAndSorting()
	{
		// Ordering and sorting strings should be done based on culture. 
		// This is mostly handled by .NET Framework. Strings are sorted
		// by the current culture. 

		string[] values = { "able", "ångström", "apple", "Æble",
			"Windows", "Visual Studio" };

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

		string[] expectedOrder = { "able", "Æble", "ångström", "apple", "Visual Studio", "Windows" };

		Array.Sort(FILL_ME_IN);

		Assert.Equal(expectedOrder, values);

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sv-SE");

		string[] expectedSVOrder = { "able", "Æble", "apple", "Windows", "Visual Studio", "ångström" };

		Array.Sort(FILL_ME_IN);

		Assert.Equal(expectedSVOrder, values);

	}
}