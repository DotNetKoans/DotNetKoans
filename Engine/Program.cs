using DotNetCoreKoans.Koans;
using Microsoft.DotNet.Cli.Utils;

namespace DotNetCoreKoans.Engine
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
