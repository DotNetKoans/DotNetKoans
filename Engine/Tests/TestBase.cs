using System.Linq;
using System.Reflection;
using DotNetKoans.Engine.Tests.Fakes;

namespace DotNetKoans.Engine.Tests
{
    public class TestBase
    {
        internal Path GetTestPath()
        {
            return new TestPath();
        }

        internal TypeInfo GetTestTypeInfo()
        {
            return typeof(TestKoan).GetTypeInfo();
        }

        internal MethodInfo[] GetTestMethodInfos()
        {
            return GetTestTypeInfo().GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(StepAttribute), false).Any())
                .OrderBy(m => m.GetCustomAttributes(typeof(StepAttribute), false)
                                .Cast<StepAttribute>().Single().Position)
                .ToArray();
        }
    }
}