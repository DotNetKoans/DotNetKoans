using System;

namespace DotNetKoans.Engine.Tests.Fakes
{
    public class TestPath : Path
    {
        public TestPath()
        {
            Types = new Type[] {
                typeof(TestKoan)
                };
        }
    }
}