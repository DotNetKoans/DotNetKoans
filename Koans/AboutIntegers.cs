using Xunit;
using DotNetCoreKoans.Engine;


namespace DotNetCoreKoans.Koans
{
    public class AboutIntegers : Koan
    {
        [Step(1)]
        public void UnQuotedNumbersWithoutDecimalPointsAreInts()
        {
            Assert.Equal(typeof(FillMeIn), 123.GetType());
            Assert.Equal(typeof(FillMeIn), (-123).GetType());
            Assert.Equal(typeof(FillMeIn), 0.GetType());
        }

        [Step(2)]
        public void IntHasLimitedMaximumAndMinimumValues()
        {
            Assert.Equal(FILL_ME_IN,2147483647);
            Assert.Equal(FILL_ME_IN,-2147483648);
        }

        [Step(3)]
        public void IntIgnoresDecimalPoints()
        {
            int val=12/5;
            Assert.Equal(FILL_ME_IN,val);
        }

        [Step(4)]
        public void UnsignedIntCanStoreNumberHigherThanSignedIntCan()
        {
            uint biggerUnsignedInt = (uint)2147483747+100;
            Assert.Equal(FILL_ME_IN,biggerUnsignedInt);            
        }

        [Step(5)]
        public void ValueLargetThanTheMaximumIntThrowsOverFlowException()
        {
            var biggerIntText = uint.MaxValue.ToString();
            Assert.Throws(typeof(System.OverflowException),()=> 
            {
                 int val=int.Parse(biggerIntText); 
            } );
        }
    }
}