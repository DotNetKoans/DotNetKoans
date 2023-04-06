using Xunit;
using System;
using System.Globalization;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutStrings : Koan
{
	//Note: This is one of the longest katas and, perhaps, one
	//of the most important. String behavior in .NET is not
	//always what you expect it to be, especially when it comes
	//to concatenation and newlines, and is one of the biggest
	//causes of memory leaks in .NET applications

	[Step(1)]
	public void DoubleQuotedStringsAreStrings()
	{
		var str = "Hello, World";
		Assert.Equal(typeof(FillMeIn), str.GetType());
	}

	[Step(2)]
	public void SingleQuotedStringsAreNotStrings()
	{
		var str = 'H';
		Assert.Equal(typeof(FillMeIn), str.GetType());
	}

	[Step(3)]
	public void CreateAStringWhichContainsDoubleQuotes()
	{
		var str = "Hello, \"World\"";
		Assert.Equal(FILL_ME_IN, str.Length);
	}

	[Step(4)]
	public void AnotherWayToCreateAStringWhichContainsDoubleQuotes()
	{
		//The @ symbol creates a 'verbatim string literal'. 
		//Here's one thing you can do with it:
		var str = @"Hello, ""World""";
		Assert.Equal(FILL_ME_IN, str.Length);
	}

	[Step(5)]
	public void VerbatimStringsCanHandleFlexibleQuoting()
	{
		var strA = @"Verbatim Strings can handle both ' and "" characters (when escaped)";
		var strB = "Verbatim Strings can handle both ' and \" characters (when escaped)";
		Assert.Equal(FILL_ME_IN, strA.Equals(strB));
	}

	[Step(6)]
	public void VerbatimStringsCanHandleMultipleLinesToo()
	{
		//Tip: What you create for the literal string will have to 
		//escape the newline characters. For Windows, that would be
		// \r\n. If you are on non-Windows, that would just be \n.
		//We'll show a different way next.
		var verbatimString = @"I
am a
broken line";

		// Make sure to use a literal string.
		// Escaped characters in verbatim strings are covered later.
		var literalString = FILL_ME_IN;
		Assert.Equal(FILL_ME_IN, verbatimString.Length);

		// For verbatim strings, the newline character used will depend on
		// whether the source file uses a \r\n or a \n ending and they have
		// to match the ones on the literal string
		// If you are using Visual Studio Code, you can see which line ending is
		// in use at the bottom right of the screen

		Assert.Equal(literalString, verbatimString);
	}

	[Step(7)]
	public void ACrossPlatformWayToHandleLineEndings()
	{
		//Since line endings are different on different platforms
		//(\r\n for Windows, \n for Linux) you shouldn't just type in
		//the hardcoded escape sequence. A much better way
		//(We'll handle concatenation and better ways of that in a bit)
		var literalString = "I" + System.Environment.NewLine + "am a" + System.Environment.NewLine + "broken line";
		var verbatimString = FILL_ME_IN;
		Assert.Equal(literalString, verbatimString);
	}

	[Step(8)]
	public void PlusWillConcatenateTwoStrings()
	{
		var str = "Hello, " + "World";
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(9)]
	public void PlusConcatenationWillNotModifyOriginalStrings()
	{
		var strA = "Hello, ";
		var strB = "World";
		var fullString = strA + strB;
		Assert.Equal(FILL_ME_IN, strA);
		Assert.Equal(FILL_ME_IN, strB);
	}

	[Step(10)]
	public void PlusEqualsWillModifyTheTargetString()
	{
		var strA = "Hello, ";
		var strB = "World";
		strA += strB;
		Assert.Equal(FILL_ME_IN, strA);
		Assert.Equal(FILL_ME_IN, strB);
	}

	[Step(11)]
	public void StringsAreReallyImmutable()
	{
		//So here's the thing. Concatenating strings is cool
		//and all. But if you think you are modifying the original
		//string, you'd be wrong. 

		var strA = "Hello, ";
		var originalString = strA;
		var strB = "World";
		strA += strB;
		
		Assert.Equal(FILL_ME_IN, originalString);
		Assert.False(Object.ReferenceEquals(FILL_ME_IN, originalString));
		//What just happened? Well, the string concatenation actually
		//takes strA and strB and creates a *new* string in memory
		//that has the new value. It does *not* modify the original
		//string. This is a very important point - if you do this kind
		//of string concatenation in a tight loop, you'll use a lot of memory
		//because the original string will hang around in memory until the
		//garbage collector picks it up. Let's look at a better way
		//when dealing with lots of concatenation
	}

	[Step(12)]
	public void ABetterWayToConcatenateLotsOfStrings()
	{
		//Concatenating lots of strings is a Bad Idea(tm). If you need to do that, then consider StringBuilder.
		var strBuilder = new System.Text.StringBuilder();
		strBuilder.Append("The ");
		strBuilder.Append("quick ");
		strBuilder.Append("brown ");
		strBuilder.Append("fox ");
		strBuilder.Append("jumped ");
		strBuilder.Append("over ");
		strBuilder.Append("the ");
		strBuilder.Append("lazy ");
		strBuilder.Append("dog.");
		var str = strBuilder.ToString();
		Assert.Equal(FILL_ME_IN, str);

		//When doing lots and lots of concatenation in a loop, StringBuilder will be more efficient than concatenation using the +-operator.
		//However, even in the above example simple concatenation would actually be more efficient.
	}
	
	[Step(13)]
	public void YouCouldAlsoUseStringFormatToConcatenate()
	{
		var world = "World";
		var str = String.Format("Hello, {0}", world);
		Assert.Equal(FILL_ME_IN, str);
		// Note that string concatenation and interpolation is more efficient than string.Format
	}

	[Step(14)]
	public void AnyExpressionCanBeUsedInFormatString()
	{
		var str = String.Format("The square root of 9 is {0}", Math.Sqrt(9));
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(15)]
	public void StringsCanBePaddedToTheLeft()
	{
		//You can modify the value inserted into the result
		var str = string.Format("{0,3:}", "x");
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(16)]
	public void StringsCanBePaddedToTheRight()
	{
		var str = string.Format("{0,-3:}", "x");
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(17)]
	public void SeparatorsCanBeAdded()
	{
		var str = string.Format("{0:n}", 123456);
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(18)]
	public void CurrencyDesignatorsCanBeAdded()
	{
		var str = string.Format("{0:c}", 123456);
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(19)]
	public void NumberOfDisplayedDecimalsCanBeControlled()
	{
		var str = string.Format("{0:.##}", 12.3456);
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(20)]
	public void MinimumNumberOfDisplayedDecimalsCanBeControlled()
	{
		var str = string.Format("{0:.00}", 12.3);
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(21)]
	public void BuiltInDateFormatters()
	{
		var str = string.Format("{0:t}", DateTime.Parse("12/16/2011 2:35:02 PM", CultureInfo.InvariantCulture));
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(22)]
	public void CustomDateFormatters()
	{
		var str = string.Format("{0:t m}", DateTime.Parse("12/16/2011 2:35:02 PM", CultureInfo.InvariantCulture));
		Assert.Equal(FILL_ME_IN, str);
	}
	//These are just a few of the formatters available. Dig some and you may find what you need.


	[Step(23)]
	public void StringBuilderCanUseFormatAsWell()
	{
		var strBuilder = new System.Text.StringBuilder();
		strBuilder.AppendFormat("{0} {1} {2}", "The", "quick", "brown");
		strBuilder.AppendFormat("{0} {1} {2}", "jumped", "over", "the");
		strBuilder.AppendFormat("{0} {1}.", "lazy", "dog");
		var str = strBuilder.ToString();
		Assert.Equal(FILL_ME_IN, str);
	}

	[Step(24)]
	public void LiteralStringsInterpretsEscapeCharacters()
	{
		var str = "\n";
		Assert.Equal(FILL_ME_IN, str.Length);
	}

	[Step(25)]
	public void VerbatimStringsDoNotInterpretEscapeCharacters()
	{
		var str = @"\n";
		Assert.Equal(FILL_ME_IN, str.Length);
	}

	[Step(26)]
	public void VerbatimStringsStillDoNotInterpretEscapeCharacters()
	{
		var str = @"\\\";
		Assert.Equal(FILL_ME_IN, str.Length);
	}

	[Step(27)]
	public void YouCanGetASubstringFromAString()
	{
		var str = "Bacon, lettuce and tomato";
		Assert.Equal(FILL_ME_IN, str.Substring(19));
		Assert.Equal(FILL_ME_IN, str.Substring(7, 3));
	}

	[Step(28)]
	public void YouCanGetASingleCharacterFromAString()
	{
		var str = "Bacon, lettuce and tomato";
		Assert.Equal(FILL_ME_IN, str[0]);
	}

	[Step(29)]
	public void SingleCharactersAreRepresentedByIntegers()
	{
		Assert.Equal(97, 'a');
		Assert.Equal(98, 'b');
		Assert.Equal(FILL_ME_IN, 'b' == ('a' + 1));
	}

	[Step(30)]
	public void StringsCanBeSplit()
	{
		var str = "Sausage Egg Cheese";
		string[] words = str.Split();
		Assert.Equal(new[] { FILL_ME_IN }, words);
	}

	[Step(31)]
	public void StringsCanBeSplitUsingCharacters()
	{
		var str = "the:rain:in:spain";
		string[] words = str.Split(':');
		Assert.Equal(new[] { FILL_ME_IN }, words);
	}

	[Step(32)]
	public void StringsCanBeSplitUsingRegularExpressions()
	{
		var str = "the:rain:in:spain";
		var regex = new System.Text.RegularExpressions.Regex(":");
		string[] words = regex.Split(str);
		Assert.Equal(new[] { FILL_ME_IN }, words);

		//A full treatment of regular expressions is beyond the scope
		//of this tutorial. The book "Mastering Regular Expressions"
		//is highly recommended to be on your bookshelf
	}

	[Step(33)]
	public void YouCanInterpolateVariablesIntoAString()
	{
		var name = "John Doe";
		var age = 33;
		var str = $"Mr. {name} is {age} years old";
		Assert.Equal(FILL_ME_IN, str);
	}
	
	[Step(34)]
	public void InterpolationSupportsFormatAsWell()
	{
		var str = $"{DateTime.Parse("12/16/2011 2:35:02 PM", CultureInfo.InvariantCulture):t m}";
		Assert.Equal(FILL_ME_IN, str);
	}
}