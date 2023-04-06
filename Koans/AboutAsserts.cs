using Xunit;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutAsserts : Koan
{
	//We shall contemplate truth by testing reality, via asserts.
	[Step(1)]
	public void AssertTruth()
	{
		Assert.True(false); //This should be true
	}

	//Enlightenment may be more easily achieved with appropriate messages
	[Step(2)]
	public void AssertTruthWithMessage()
	{
		Assert.True(false, "This should be true -- Please fix this");
	}

	//To understand reality, we must compare our expectations against reality
	[Step(3)]
	public void AssertEquality()
	{
		var expectedValue = 3;
		var actualValue = 1 + 1;
		Assert.True(expectedValue == actualValue);
	}

	//Some ways of asserting equality are better than others
	[Step(4)]
	public void ABetterWayOfAssertingEquality()
	{
		var expectedValue = 3;
		var actualValue = 1 + 1;
		Assert.Equal(expectedValue, actualValue);
	}

	//Sometimes we will ask you to fill in the values
	[Step(5)]
	public void FillInValues()
	{
		Assert.Equal(FILL_ME_IN, 1 + 1);
	}
}