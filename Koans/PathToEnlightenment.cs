using System;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class PathToEnlightenment : Path
{
	public PathToEnlightenment()
	{
		Types = new Type[]
		{
			typeof(AboutAsserts),
			typeof(AboutBooleans),
			typeof(AboutStrings),
			typeof(AboutFloats),
			typeof(AboutDecimals),
			typeof(AboutNull),
			typeof(AboutConstants),
			typeof(AboutArrays),
			typeof(AboutArrayAssignment),
			typeof(AboutEnumerations),
			typeof(AboutDictionary),
			typeof(AboutClasses),
			typeof(AboutInheritance),
			typeof(AboutMethods),
			typeof(AboutControlStatements),
			typeof(AboutIteration),
			typeof(AboutExceptions),
			typeof(AboutGenericContainers),
			typeof(AboutDelegates),
			typeof(AboutLambdas),
			typeof(AboutDirectory),
			typeof(AboutFile),
			typeof(AboutLinq),
			typeof(AboutBitwiseAndShiftOperator),
			typeof(AboutDestructuring),
			typeof(AboutPatternMatching),
			typeof(AboutTuples),
			typeof(AboutGlobalization),
			typeof(AboutDisposable),
			typeof(AboutThreads),
			typeof(AboutReflection)
		};
	}
}