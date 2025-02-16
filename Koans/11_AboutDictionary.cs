using System.Collections.Generic;
using System.Linq;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutDictionary : Koan
{
	// A dictionary is a C# class.
	[Step(1)]
	public void DictionaryIsACSharpClass()
	{
		var dict = new Dictionary<string, string>();
		dict.Add("Value", "Key");
		var firstElement = dict.First();

		Assert.Equal(FILL_ME_IN, firstElement.Key); // Key
		Assert.Equal(FILL_ME_IN, firstElement.Value); // Value
	}

	//Pass keys to get their values.
	[Step(2)]
	public void UsingDictionaryKeysToGetValues()
	{
		var dict = new Dictionary<string, string>();
		dict.Add("Bruce", "Wayne");
		dict.Add("United Kingdom", "London");
		dict.Add("Poland", "Warsaw");
		dict.Add("Japan", "Tokyo");

		var key = "Japan";
		Assert.Equal(FILL_ME_IN, dict[key]); // What is the value?            
	}

	//Check if a key exists in Dictionary.
	[Step(3)]
	public void CheckIfKeyExists()
	{
		var dict = new Dictionary<string, string>();
		dict.Add("Bruce", "Wayne");
		dict.Add("United Kingdom", "London");
		dict.Add("Poland", "Warsaw");
		dict.Add("Japan", "Tokyo");

		var key = "Jeff";
		Assert.True(true, dict.ContainsKey(key).ToString()); // How to make this statement true?          
	}

	//Check if a value exists in Dictionary.
	[Step(4)]
	public void CheckIfValueExists()
	{
		var dict = new Dictionary<string, string>();
		dict.Add("Bruce", "Wayne");
		dict.Add("United Kingdom", "London");
		dict.Add("Poland", "Warsaw");
		dict.Add("Japan", "Tokyo");

		var val = "Archer";
		Assert.True(true, dict.ContainsValue(val).ToString()); // How to make this statement true?          
	}

	//Update the value of a key in dictionary.
	[Step(5)]
	public void UpdateValueOfKey()
	{
		var dict = new Dictionary<string, string>();
		dict.Add("Bruce", "Wayne");
		dict.Add("United Kingdom", "London");
		dict.Add("Poland", "Warsaw");
		dict.Add("Japan", "Tokyo");
		dict.Add("India", "Mumbai");

		var key = "India";
		var expectedValue = "New Delhi";

		//May be you should update this
		//dict[key] = FILL_ME_IN;

		Assert.Equal(expectedValue, dict[key]); // How to make this statement true?          
	}

	//Remove a key from dictionary and check its value.
	[Step(6)]
	public void RemoveKeyAndCheckIfItExists()
	{
		var dict = new Dictionary<string, string>();
		dict.Add("Bruce", "Wayne");
		dict.Add("United Kingdom", "London");
		dict.Add("Poland", "Warsaw");
		dict.Add("Japan", "Tokyo");
		dict.Add("India", "Mumbai");

		var keyToRemove = "Bruce";

		if (dict.ContainsKey(keyToRemove))
			dict.Remove(keyToRemove);
            
		Assert.True(dict.ContainsKey(keyToRemove)); // How to make this statement true?          
	}

}