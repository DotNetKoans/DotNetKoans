using Xunit;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutNull : Koan
{
	[Step(1)]
	public void NullIsNotAnObject()
	{
		Assert.True(null is object);

		// The `is` operator returns false if the object (first parameter)
		// is null, no matter what the type (second parameter) is.
	}

	[Step(2)]
	public void YouGetNullPointerErrorsWhenCallingMethodsOnNull()
	{
		//What is the Exception that is thrown when you call a method on a null object?
		//Don't be confused by the code below. It is using Anonymous Delegates which we will
		//cover later on. 
		object nothing = null;
		Assert.Throws(typeof(FillMeIn), delegate () { nothing.ToString(); });

		//What's the message of the exception? What substring or pattern could you test
		//against in order to have a good idea of what the string is?
		try
		{
			nothing.ToString();
		}
		catch (System.Exception ex)
		{
			Assert.Contains(FILL_ME_IN as string, ex.Message);
		}
	}

	[Step(3)]
	public void CheckingThatAnObjectIsNull()
	{
		object obj = null;
		Assert.True(obj == FILL_ME_IN);
	}

	[Step(4)]
	public void ABetterWayToCheckThatAnObjectIsNull()
	{
		object obj = null;
		Assert.Null(FILL_ME_IN);
	}

	[Step(5)]
	public void AWayNotToCheckThatAnObjectIsNull()
	{
		object obj = null;
		Assert.True(obj.Equals(null));
	}
}