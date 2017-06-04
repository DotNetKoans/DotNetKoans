using Xunit;
using DotNetCoreKoans.Engine;
using System;
using System.Globalization;

namespace DotNetCoreKoans.Koans
{
    public class AboutVariableScope : Koan
    {

        public int myValue = 10;

        [Step(1)]
        public void GlobalVariableScope()
        {
            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(2)]
        public void LocalVariableScope()
        {
            int myValue = 5;
			Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(3)]
        public void CombinationVariableScope()
        {
            int localValue = 10 + myValue;
            Assert.Equal(localValue, FILL_ME_IN);
        }

        [Step(4)]
        public void ConditionValueScope()
        {
            if(true)
            {
                int myValue = 8;
                Assert.Equal(myValue, FILL_ME_IN);
            }           
        }

        [Step(5)]
        public void ConditionValueScope2()
        {
            if(false)
            {
                int myValue = 8;
            }           
            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(6)]
        public void ConditionValueScope3()
        {
            if(true)
            {
                int myValue = 8;
            }    
            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(7)]
        public void ConditionValueScope4()
        {
            int myValue;
            if(true)
            {
                myValue = 8;
            }    
            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(8)]
        public void ConditionValueScope5()
        {
            int myValue = 50;
            for(int i = 0; i < 10; i++)
            {
                myValue = myValue + i;
            }

            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(9)]
        public void ConditionValueScope6()
        {
             
            for(int i = 0; i < 10; i++)
            {
                int myValue = 50;
                myValue = myValue + i;
            }

            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(10)]
        public void ReAssignGlobalScopeValue()
        {
            myValue = 15;

            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(11)]
        public void GlobalScopeValueAfterReassign()
        {
            Assert.Equal(myValue, FILL_ME_IN);
        }

        [Step(12)]
        public void NewLocalValuePlusGlobalValue()
        {
            //hint this means the class itself
            int myValue = 10 + this.myValue;
            Assert.Equal(myValue, FILL_ME_IN);
        }

		[Step(13)]
		public void UseGlobalAndLocalValue()
		{
            var myValue = 10;
            this.myValue = 50;
			for(int i =0; i < 10; i++)
            {
                myValue = myValue + 1;
            }
			Assert.Equal(myValue, FILL_ME_IN);
		}
    }
}
