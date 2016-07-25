using Xunit;

namespace UIMvc.Tests
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
            Assert.NotEqual(false, true);
        }
    }
}