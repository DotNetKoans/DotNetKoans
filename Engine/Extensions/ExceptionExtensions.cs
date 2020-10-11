using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace System
{
    public static class ExceptionExtensions
    {
        private static readonly Regex exceptionPathRegex = new Regex(@"(\w*\.cs:line \d*)");

        public static IEnumerable<string> GetStackTracePaths(this Exception exception) =>

            exceptionPathRegex.Matches(exception.StackTrace).Select(x => x.Value);
    }
}