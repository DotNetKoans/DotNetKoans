using System;
using Xunit;

namespace DotNetCoreKoans.Engine.Tests.Fakes
{
    internal class TestKoan : Koan
    {

        public bool WasSetup { get; set; }
        public bool WasToreDown { get; set;}

        public override void Setup()
        {
            WasSetup = true;
        }

        public override void TearDown()
        {
            WasToreDown = true;
        }

        [Step(1)]
        public void PassingStep()
        {

        }

        [Step(2)]
        public void FailingAssertionStep()
        {
            Assert.True(false);
        }

        [Step(3)]
        public void FailingExceptionStep()
        {
            throw new NotImplementedException();
        }
    }
}