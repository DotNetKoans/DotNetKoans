using System;
using DotNetCoreKoans.Engine;

namespace DotNetCoreKoans.Koans
{
    public class PathToEnlightenment : Path
    {
        public PathToEnlightenment()
        {
            Types = new Type[] {
		typeof(AboutAsserts),
		typeof(AboutNull),
		typeof(AboutArrays),
		typeof(AboutArrayAssignment),
		typeof(AboutStrings),
                typeof(AboutFloats),
	    	typeof(AboutDecimals),
		typeof(AboutInheritance),
                typeof(AboutMethods),
                typeof(AboutControlStatements),
                typeof(AboutGenericContainers),
                typeof(AboutDelegates),
		typeof(AboutLambdas),
                typeof(AboutLinq),
                typeof(AboutBitwiseAndShiftOperator),
                typeof(AboutGlobalization)
                };
        } 
    }
}
