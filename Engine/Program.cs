using DotNetCoreKoans.Koans;
using Microsoft.DotNet.Cli.Utils;

namespace DotNetCoreKoans.Engine
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var path = new PathToEnlightenment();
            var sensei = new Sensei(Reporter.Output);

            return path.Walk(sensei, AnsiConsole.GetOutput());
        }
    }
}
