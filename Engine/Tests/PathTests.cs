using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotNetCoreKoans.Engine.Tests
{
    public class PathTests : TestBase
    {

        [Fact]
        public void ForEachKoanShouldCallTheActionForEachType()
        {
            var count = 0;
            var path = GetTestPath();

            path.ForEachKoan(t => {
                count++;
                Assert.Equal(GetTestTypeInfo(), t);
            });

            Assert.Equal(path.Count(), count);
        }

        [Fact]
        public void ForEachStepShouldCallTheActionForEachMethodOfEachType()
        {
            var count = 0;
            var path = GetTestPath();

            path.ForEachStep(s => {
                count++;
                
            });

            Assert.Equal(GetTestMethodInfos().Count(), count);
        }

        [Fact]
        public void ForEachStepShouldCreateASingleStepPerMethodOfEachType()
        {
            var steps = new HashSet<Step>();
            var path = GetTestPath();

            path.ForEachStep(step => {
                Assert.DoesNotContain(step, steps);
                steps.Add(step);
               
            });

            Assert.Equal(GetTestMethodInfos().Count(), steps.Count());
        }
    }
}