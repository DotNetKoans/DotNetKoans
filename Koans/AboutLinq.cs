using System.Linq;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutLinq : Koan
{
	/*
	 *LINQ (Language Integrated Query).
	 * LINQ provides language-level querying capabilities and a higher-order function API to C# and VB as a way to write expressive, declarative code.
	 * All LINQ query operations consist of three distinct actions:

	    1. Obtain the data source.

	    2. Create the query.

	    3. Execute the query.
	 */

	[Step(1)]
	public void FilterArrayData()
	{
		//This sample uses "where" to find all elements of an array less than 5.

		// The Three Parts of a LINQ Query:

		//  1. Data source.
		int[] numbers = { 5, 1, 9, 8, 6, 7 };

		// 2. Query creation.
		var lowNums =
			from n in numbers
			where n < 5
			select n;

		// 3. Query execution.
		Assert.Equal(FILL_ME_IN, lowNums.Count());
	}

	[Step(2)]
	public void PutYourDataInOrderUsingOrderBy()
	{
		string[] customers = { "John", "Bill", "Maria", "George", "Anna" };

		var orderedCustomers =
			from cust in customers
			orderby cust ascending //You can also use descending here for reverse order.
			select cust;

		Assert.Equal(FILL_ME_IN, orderedCustomers.First());
		Assert.Equal(FILL_ME_IN, orderedCustomers.Last());
	}

	[Step(3)]
	public void GetJustTheDataYouWantUsingTake()
	{
		int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

		//Get just the 3 first numbers.
		var first3Numbers = numbers.Take(3);

		Assert.Equal(FILL_ME_IN, first3Numbers.Count());
	}

	[Step(4)]
	public void UseAnyToDoSmartChecksOnYourData()
	{
		string[] words = { "believe", "relief", "receipt", "field" };

		bool iAfterE = words.Any(w => w.Contains("ei")); //Check if any of your words contain 'ei'
		Assert.Equal(FILL_ME_IN, iAfterE);
	}

        
	[Step(5)]
	public void HowToUseWhereToFilterData()
	{
		var numbers = new[] {1, 2, 3, 4};
		var result = numbers.Where(x => x > 2).ToArray();
			
		//What values should be in array?
		Assert.Equal(FILL_ME_IN, result);
	}
		
	[Step(6)]
	public void HowToGetInfoIfValueIsGreaterThanUsingSelect()
	{
		var numbers = new[] {1, 2, 3, 4};
		var result = numbers.Select(x => x > 2).ToArray();
			
		//What values should be in array?
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(7)]
	public void GetSumOfTheData()
	{
		int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

		//Get sum of the array.
		var sum = numbers.Sum();

		Assert.Equal(FILL_ME_IN, sum);
	}

	[Step(8)]
	public void GetMinimumOfTheData()
	{
		int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

		//Get minimum of the array.
		var min = numbers.Min();

		Assert.Equal(FILL_ME_IN, min);
	}

	[Step(9)]
	public void GetMaximumOfTheData()
	{
		int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

		//Get maximum of the array.
		var max = numbers.Max();

		Assert.Equal(FILL_ME_IN, max);
	}


	[Step(10)]
	public void GetAverageOfTheData()
	{
		int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

		//Get average of the array.
		var average = numbers.Average();

		Assert.Equal(FILL_ME_IN, average);
	}
}