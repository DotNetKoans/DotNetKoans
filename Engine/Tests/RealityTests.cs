using Xunit;

namespace DotNetCoreKoans.Engine.Tests
{
    public class RealityTests
    {
        [Fact]
        public void TrueShouldBeTrue()
        {
            Assert.True(true);
        }
        
        [Fact]
        public void TrueShouldNotBeFalse()
        {
            Assert.False(true);
        }
    }
}