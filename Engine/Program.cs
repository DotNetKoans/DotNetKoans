using DotNetKoans.Koans;
using Microsoft.DotNet.Cli.Utils;

namespace DotNetKoans.Engine
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var reporter = Reporter.Output;
            var sensei = new Sensei(reporter);
            var path = new PathToEnlightenment();

            return path.Walk(sensei);
        }
    }
}
