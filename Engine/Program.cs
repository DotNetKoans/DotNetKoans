using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Xunit.Sdk;
using DotNetCoreKoans.Koans;
using System.Text;

namespace DotNetCoreKoans.Engine
{
    public class Program
    {
        static ILogger Logger = new LoggerFactory()
            .AddConsole()
            .CreateLogger<Program>();
        static int KOAN_FAILED = 0;


        public static int Main(string[] args)
        {            
            var path = new PathToEnlightenment();
            var progress = new StringBuilder();
            try
            {
                Logger.LogInformation("");
                Logger.LogInformation("");
                Logger.LogInformation("*******************************************************************");
                Logger.LogInformation("*******************************************************************");

                foreach (var step in path)
                {
                    progress.Append($"{Take(step)}");
                }
            }
            catch (Exception e)
            {
                Logger.LogInformation($"Karma has killed the runner. Exception was: {e.ToString()}");
				return -1;
            }
            Logger.LogInformation($"Koan progress:{progress}");
			Logger.LogInformation("*******************************************************************");
			Logger.LogInformation("*******************************************************************");
			Logger.LogInformation("");
			Logger.LogInformation("");
			return KOAN_FAILED;
        }

        static string Take(Type step)
        {
            if (step == null) { return "0/0"; }

            var instance = Activator.CreateInstance(step);
            var queue = step.GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(KoanAttribute), false).Any())
                .OrderBy(m => m.GetCustomAttributes(typeof(KoanAttribute), false)
                                .Cast<KoanAttribute>().Single().Position)
                .ToArray();

            var highestKoanNumber = queue.Length + 1;
            var numberOfTestsActuallyRun = 0;
			var numberOfTestsPassed = 0;
                        
            foreach (var koan in queue)
            {
                numberOfTestsActuallyRun++;

                if (KOAN_FAILED != 0) { continue; }
				                
                Run(instance, koan);
                
                if (KOAN_FAILED == 0) { numberOfTestsPassed++; }
            }

            if (numberOfTestsActuallyRun != highestKoanNumber)
            {
                Logger.LogCritical("!!!!WARNING - Some Koans appear disabled. The highest koan found was {highestKoanNumber} but we ran {numberOfTestsActuallyRun} koan(s)");
            }
            
             return $"{numberOfTestsPassed}/{numberOfTestsActuallyRun}";          
        }

        static void Run(Object instance, MethodInfo koan) 
        {            
            try
            {
                koan.Invoke(instance, Array.Empty<object>());
                Report(koan);
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is XunitException)
                {
                    Report(koan, e.InnerException as XunitException);
                    //KOAN_FAILED = 1;
                }
            }
        }

        private static void Report(MethodInfo koan, XunitException e = null)
        {
            if (e != null)
            {
                Logger.LogError($"The test {koan.Name} has damaged your karma. The following stack trace has been declared to be at fault");
                Logger.LogError(e.Message);
                Logger.LogError(e.StackTrace);
            }
            else
            {
                Logger.LogInformation($"{koan.Name} has expanded your awareness");
            }
        }
    }
}
