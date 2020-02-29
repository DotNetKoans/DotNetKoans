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
                typeof(AboutLambdas),
                typeof(AboutLinq),
                typeof(AboutBitwiseAndShiftOperator)
                //TODO: disabled due to missing functionality in netcoreapp1.0
                // it will be available in 1.1 see:
                // https://github.com/dotnet/coreclr/blob/master/src/mscorlib/src/System/Array.cs#L1005
                //typeof(AboutDelegates)
                };
        } 
    }
}