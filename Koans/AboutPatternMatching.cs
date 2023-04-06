using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Runtime.InteropServices;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

class AboutPatternMatching : Koan
{
	#region 1: Syntax

	#region 1.1: Test object type
	// Pattern matching can test an object's type
	[Step(1)]
	public void PatternMatchingTestObjectType()
	{
		Hero hero = new Superman();

		var message = GetHeroHelloMessageWithIf(hero);
		Assert.Equal(FILL_ME_IN, message);


		var message2 = GetHeroHelloMessageWithCase(hero);
		Assert.Equal(FILL_ME_IN, message2);
	}

	private string GetHeroHelloMessageWithIf(Hero hero)
	{
		if (hero is Superman)
		{
			return "I'm Superman";
		}
		else if (hero is Batman)
		{
			return "I'm the Dark Knight, you know me as Batman";
		}
		else
		{
			return "Nobody knows me :'(";
		}
	}

	private string GetHeroHelloMessageWithCase(Hero hero)
	{
		switch (hero)
		{
			case Batman batman:
				return "I'm the Dark Knight, you know me as Batman";
			case Superman superman:
				return "I'm Superman";
			default:
				return "Nobody knows me :'(";
		}
	}
	#endregion

	#region 1.2: Cast object
	// Pattern matching can cast object
	[Step(2)]
	public void PatternMatchingCastObject()
	{
		Hero hero = new Batman();

		var gadgets = GetGadgetsWithIf(hero);
		Assert.Equal(FILL_ME_IN, string.Join(",", gadgets));

		var gadgets2 = GetGadgetsWithCase(hero);
		Assert.Equal(FILL_ME_IN, string.Join(",", gadgets2));
	}

	private string[] GetGadgetsWithIf(Hero hero)
	{
		var batman = hero as Batman; // return null if hero is not a batman
		if (batman != null)
		{
			return batman.gadget; // gadget is not in hero class but in batman
		}

		return new string[0];
	}

	private string[] GetGadgetsWithCase(Hero hero)
	{
		switch (hero)
		{
			case Batman batman:
				return batman.gadget; // gadget is not in hero class but in batman

			default:
				return new string[0];
		}
	}
	#endregion

	// Pattern matching case with sugar syntax
	[Step(3)]
	public void PatternMatchingCaseSugarSyntax()
	{
		/// In the two previous examples, each switch case always returns a value.
		/// There is a sugar syntax for that
		/// Let's refactor the second one.
		Hero hero = new Batman();

		var gadgets = hero switch
		{
			Batman batman => batman.gadget,
			_ => new string[0] // default case
		};

		Assert.Equal(FILL_ME_IN, string.Join(",", gadgets));
	}


	#endregion

	#region 2: Special case

	/// Pattern Matching let you make choices based on object/tuple properties.
	/// It's called Special Case.

	// Special case with when
	[Step(4)]
	public void SpecialCaseWithWhenClause()
	{
		Hero hero = new Batman();
		hero.ReplaceBy("Jean-Paul", "Valley");

		var message = hero switch
		{
			Batman batman when batman.lastName == "Wayne" => "Sure, you are Batman", // Special case
			Batman batman => "You look like batman, but I don't think you are",
			_ => "I don't know you" // default case
		};

		Assert.Equal(FILL_ME_IN, message);
	}

	// Special case with destructuring on tuples
	[Step(5)]
	public void SpecialCaseWithDestructuringTuple()
	{
		/// 
		var hero = ("Batman", "Valley", "Jean-Paul");

		var message = hero switch
		{
			("Batman", "Wayne", _) => "Sure, you are Batman",
			("Batman", _, _) => "You look like Batman, but I don't think you are",
			_ => "I don't know you" // default case
		};

		Assert.Equal(FILL_ME_IN, message);
	}

	// Special case with destructuring on object
	[Step(6)]
	public void SpecialCaseWithDestructuringObject()
	{
		Hero hero = new Batman();

		var message = hero switch
		{
			{ lastName: "Wayne" } => "Sure, you are Batman",
			Batman batman => "You look like Batman, but I don't think you are",
			_ => "I don't know you" // default case
		};

		Assert.Equal(FILL_ME_IN, message);
	}

	#endregion

	#region 3: some warning

	// Evaluation order in pattern matching
	[Step(7)]
	public void PatternMatchingOrder()
	{
		/// Pattern matching is evaluated from top to bottom
		Hero hero = new Batman();

		var message = hero switch
		{
			Batman batman when batman.lastName != "Wayne" => "You look like Batman, but I don't think you are",
			{ lastName: "Wayne" } => "Sure, you are Batman",
			_ => "I don't know you" // default case
		};

		Assert.Equal(FILL_ME_IN, message);
	}


	// Pattern matching with null values
	[Step(8)]
	public void PatternMatchingWithNull()
	{
		// Pattern matching doesn't throw NullReferenceException
		Hero hero = null;

		var message = hero switch
		{
			Batman batman when batman.lastName != "Wayne" => "You look like Batman, but I don't think you are",
			Batman batman => "Sure, you are Batman",
			_ => "I don't know you" // default case
		};

		Assert.Equal(FILL_ME_IN, message);
	}

	#endregion



}

class Hero
{
	public string firstName { get; private set; }
	public string lastName { get; private set; }

	public Hero(string firstName, string lastName)
	{
		this.firstName = firstName;
		this.lastName = lastName;
	}

	public void ReplaceBy(string firstName, string lastName)
	{
		this.firstName = firstName;
		this.lastName = lastName;
	}

}

class Batman : Hero
{
	public string[] gadget = new string[]
	{
		"Batarang", "Batgyro", "Batsuit", "Batmobile", "Belt"
	};

	public Batman() : base("Bruce", "Wayne")
	{ }
}

class Superman : Hero
{
	public Superman() : base("Clark Joseph", "Kent")
	{ }
}