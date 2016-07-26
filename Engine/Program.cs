using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Xunit.Sdk;
using DotNetCoreKoans.Koans;
using System.Text;
using NLog.Extensions.Logging;

namespace DotNetCoreKoans.Engine
{
    public class Program
    {
        static ILogger Logger = new LoggerFactory()
            .AddNLog()
            .CreateLogger<Program>();
        static int KOAN_FAILED = 0;


        public static int Main(string[] args)
        {            
            var path = new PathToEnlightenment();
            var progress = new StringBuilder();
            try
            {
                Console.Clear(); 
                Logger.LogInformation("*******************************************************************");
                Logger.LogInformation("*******************************************************************");

                foreach (var step in path)
                {
                    Logger.LogInformation($"Current Koan: {step.Name}");

                    progress.Append($"{Take(step)}");
                    if (KOAN_FAILED != 0) { break; }

                }
            }
            catch (Exception e)
            {
                Logger.LogInformation($"Karma has killed the runner. Exception was: {e.ToString()}");
				return -1;
            }
            Logger.LogInformation($"Koan Progress:{progress}");
			Logger.LogInformation("*******************************************************************");
			Logger.LogInformation("*******************************************************************");

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

            var highestKoanNumber = queue.Length;
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
                Logger.LogCritical($"!!!!WARNING - Some Koans appear disabled. The highest koan found was {highestKoanNumber} but we ran {numberOfTestsActuallyRun} koan(s)");
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
                Report(koan, e.InnerException);
                KOAN_FAILED = 1;
            }
        }

        private static void Report(MethodInfo koan, Exception e = null)
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
