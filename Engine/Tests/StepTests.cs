using System;
using System.Linq;
using DotNetCoreKoans.Engine.Tests.Fakes;
using Xunit;
using Xunit.Sdk;

namespace DotNetCoreKoans.Engine.Tests
{
    public class StepTests : TestBase
    {
        [Fact]
        public void KoanBuilderShouldBuildCorrectType()
        {
            var step = new Step (GetTestTypeInfo(), GetTestMethodInfos().First());

            var koan = step.GetKoan();

            Assert.IsType<TestKoan>(koan);
            Assert.Same(koan, step.Instance);
            Assert.False(step.Instance?.Cast<TestKoan>().WasSetup);
            Assert.False(step.Instance?.Cast<TestKoan>().WasToreDown);

        }

        [Fact]
        public void StepNameShouldBeBasedOnTypeAndMethod()
        {
            var step = new Step (GetTestTypeInfo(), GetTestMethodInfos().First());

            Assert.Contains(GetTestTypeInfo().Name, step.Name);
            Assert.Contains(GetTestMethodInfos().First().Name, step.Name);
            Assert.True(step.Name.IndexOf(GetTestTypeInfo().Name) < step.Name.IndexOf(GetTestMethodInfos().First().Name));
        }

        [Fact]
        public void PassingStepShouldBeSuccessful()
        {
            var step = new Step (GetTestTypeInfo(), GetTestMethodInfos().First());

            var result = step.Meditate();

            Assert.IsType<SuccessStepResult>(result);
            Assert.Same(step, result.Step);
            Assert.True(step.Instance.Cast<TestKoan>().WasSetup, "Koan was unexpectantly setup");
            Assert.True(step.Instance.Cast<TestKoan>().WasToreDown, "Koan was unexpectantly tore down");
        }

        [Fact]
        public void FailingAssertionStepShouldFail()
        {
            var step = new Step (GetTestTypeInfo(), GetTestMethodInfos()[1]);

            var result = step.Meditate();

            Assert.IsType<AssertionFailedStepResult>(result);
            Assert.IsAssignableFrom<XunitException>(result.Cast<AssertionFailedStepResult>().Exception);
            Assert.Same(step, result.Step);
            Assert.True(step.Instance.Cast<TestKoan>().WasSetup, "Koan was not properly setup");
            Assert.True(step.Instance.Cast<TestKoan>().WasToreDown, "Koan was not properly tore down");
        }

        [Fact]
        public void RandomExceptionStepShouldFail()
        {
            var step = new Step (GetTestTypeInfo(), GetTestMethodInfos().Last());

            var result = step.Meditate();

            Assert.IsType<FailedStepResult>(result);
            Assert.IsAssignableFrom<NotImplementedException>(result.Cast<FailedStepResult>().Exception);
            Assert.Same(step, result.Step);
            Assert.True(step.Instance.Cast<TestKoan>().WasSetup, "Koan was not properly setup");
            Assert.True(step.Instance.Cast<TestKoan>().WasToreDown, "Koan was not properly tore down");
        }
    }
}