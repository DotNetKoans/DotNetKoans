using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotNetKoans.Engine.Extensions
{
    public static class ExceptionExtensions
    {
        private static readonly Regex KoanExceptionPathRegex = new(@"(About\w*\.cs:line \d*)");

        public static IEnumerable<string> GetStackTracePaths(this Exception exception) =>

            KoanExceptionPathRegex.Matches(exception.StackTrace).Select(x => x.Value);
    }
}