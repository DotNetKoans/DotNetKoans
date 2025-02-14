using System.Globalization;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutDecimals : Koan
{
	[Step(1)]
	public void UnquotedNumbersEndingInMAreDecimals()
	{
		var d = 1m;

		Assert.Equal(typeof(FillMeIn), d.GetType());
	}

	[Step(2)]
	public void DecimalsAndIntsCanPlayNice()
	{
		//Decimals have achieved zen when working with integers.
		//(Thanks to C#'s automatic conversion between
		//decimals and whole numbers)
		decimal d = 5.2m;
		int n = 7;

		var result = d + n;

		Assert.Equal(FILL_ME_IN, result);

		// Notice that the result is a decimal when you do this
	}

	[Step(3)]
	public void DecimalsAndOtherFloatingPointTypesDoNotPlayNice()
	{
		//Since C# will not automatically convert between these types,
		//decimals have not achieved zen when working with other
		//floating point types (you must manually cast others in
		//order to perform arithmetic and achieve zen)
		decimal d = 5.1m;
		float f = 4.2f;
		double db = 7.4d;

		var result = 0m;
		//result = d + (FillMeIn) f;

		Assert.Equal(9.3m, result);

		//result = d + (FillMeIn) db;

		Assert.Equal(12.5m, result);
	}

	[Step(4)]
	public void DecimalsHaveMaximumAndMinimumValues()
	{
		// Even the zen of the decimal has its limits...
		Assert.Throws(typeof(FillMeIn), () =>
		{
			var d = decimal.Parse("79,228,162,514,264,337,593,543,950,336",CultureInfo.InvariantCulture);
		});

		Assert.Throws(typeof(FillMeIn), () =>
		{
			var d = decimal.Parse("-79,228,162,514,264,337,593,543,950,336",CultureInfo.InvariantCulture);
		});
	}

	[Step(5)]
	public void DecimalsHaveLimitedPrecision()
	{
		var twentyEightDigits = 0.9999999999999999999999999999m;
		var twentyNineDigits = 0.99999999999999999999999999999m;

		Assert.Equal(FILL_ME_IN, twentyEightDigits);
		Assert.Equal(FILL_ME_IN, twentyNineDigits);

		//Decimals use 128 bits to store their data, therefore they can store
		//up to 28 significant digits
	}

	[Step(6)]
	public void DecimalMathBehavesWell()
	{
		var d = 0.1m;
		var result = d + d + d + d + d + d + d;

		Assert.False(result == 0.7m);

		//The zen of the decimal is quite exceptional indeed. Unlike
		//floats, they are able to handle math the way humans expect. 
	}
}