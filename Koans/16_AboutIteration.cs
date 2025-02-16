using Xunit;
using System.Reflection;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutIteration : Koan
{
	// We can use several C# constructs to iterate over items in a collection

	[Step(1)]
	public void ForLoop()
	{
		// Let's make a list with some numbers
		var numbers = new List<int>()
		{
			42,
			68,
			12
		};

		int sum = 0;
		// A for loop has three parts: something to run before the loop starts for the first time,
		// a condition that will decide whether to keep iterating, and something to do after each iteration

		for (var i = 0; FILL_ME_IN; i++)
		{
			sum += numbers[i];
		}

		Assert.Equal(122, sum);
	}


	[Step(2)]
	public void ForBreak()
	{
		// We can interrupt a for loop with "break;"

		var animals = new string[] { "Cats", "Dogs", "Sharks" };
		string lastAnimal = "";

		for (var i = 0; i < animals.Length; i++)
		{
			lastAnimal = animals[i];
			if (animals[i] == "Dogs")
			{
				//FILL_ME_IN
			}
		}

		Assert.Equal("Dogs", lastAnimal);
	}

	[Step(3)]
	public void ForContinue()
	{
		// We can ignore the rest of the current iteration using "continue;"

		var colors = new List<string> { "Blue", "Red", "Pink", "Green" };

		var new_colors = new List<string>();
		var lastColor = "";
		for (var i = 0; i < colors.Count; i++)
		{
			if (colors[i] == "Blue")
			{
				//FILL_ME_IN
			}
			new_colors.Add(colors[i]);
		}

		Assert.Equal("Red", new_colors[0]);
	}


	[Step(4)]
	public void WhileLoop()
	{
		// This loop is sort of like the for loop, but only requires the middle part
		var numbers = new List<int>()
		{
			42,
			68,
			12
		};

		int sum = 0;

		// A while loop will keep repeating until the condition at the start is false
		// So we need to initialize any variables the loop needs before it, and to change those variables inside the loop itself
		// Let's do it backwards, just for fun

		int i = 2;
		while (FILL_ME_IN)
		{
			sum += numbers[i];
			i--;
		}

		Assert.Equal(122, sum);
	}


	[Step(5)]
	public void ForeachLoop()
	{
		// What if we had a way to iterate over any sort of collection that does not require us
		// to have to deal with an index and risk making a mistake that makes our program crash?

		// A foreach loop will iterate through a collection all by itself, assigning the current iteration's value to a variable
		// No more dealing with index variables

		var sharkSpecies = new List<string> {
			"Great white shark",
			"Tiger shark",
			"Whale shark",
			"Leopard shark"
		};

		string lastShark = "";

		foreach (var shark in FILL_ME_IN)
		{
			lastShark = shark;
		}

		// Best for last
		Assert.Equal("Leopard shark", lastShark);
	}
}