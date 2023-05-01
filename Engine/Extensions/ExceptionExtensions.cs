using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace DotNetKoans.Engine.Extensions;

public static class ExceptionExtensions
{
    public record StackTracePaths(IEnumerable<string> KoanPaths, IEnumerable<string> OtherPaths);
        
    private static readonly Regex ExceptionPathRegex = new(@"\w*\.cs:line \d+", RegexOptions.Compiled);

    public static StackTracePaths GetStackTracePaths(this Exception exception)
    {
        var stackTracePaths = ExceptionPathRegex.Matches(exception.StackTrace ?? String.Empty)
            .Select(x => x.Value)
            .Aggregate(new StackTracePaths(Enumerable.Empty<string>(), Enumerable.Empty<string>()),
                (acc, path) =>
                {
                    if (path.StartsWith("About"))
                    {
                        return acc with { KoanPaths = acc.KoanPaths.Append(path) };
                    }

                    return acc with { OtherPaths = acc.OtherPaths.Append(path) };
                });

        return stackTracePaths;
    }

}