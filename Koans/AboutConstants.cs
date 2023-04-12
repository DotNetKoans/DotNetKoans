using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutConstants : Koan
{
	[Step(1)]
	public void ConstantsMustBeInitalizedAsDeclared()
	{
		const int months = 12;
		Assert.Equal(FILL_ME_IN, 12);
	}

	[Step(2)]
	public void ConstantsCannotBeChanged()
	{
		//Since C# inserts literal values into compiled
		//code, you will not achieve zen when attempting
		//to change them after definition.
		const int days = 365;
		//days = days + 1; //
		Assert.Equal(FILL_ME_IN, 365);
	}

	[Step(3)]
	public void ConstantsOfTheSameTypeCanBeDeclaredAtTheSameTime()
	{
		//You can achieve zen (and save keystrokes) by defining
		//constants of the same type as one.
		const int months = 12, weeks = 52, days = 365;
		Assert.Equal(typeof(FillMeIn), months.GetType());
		Assert.Equal(typeof(FillMeIn), weeks.GetType());
		Assert.Equal(typeof(FillMeIn), days.GetType());
	}

	[Step(4)]
	public void ConstantsCanBeUsedInExpressionsToInitializeOtherConstants()
	{
		const int months = 12;
		const int weeks = 52;
		const int days = 365;

		const double daysPerWeek = (double)days / (double)weeks;
		const double daysPerMonth = (double)days / (double)months;
		Assert.Equal(FILL_ME_IN, daysPerWeek);
		Assert.Equal(FILL_ME_IN, daysPerMonth);

		//Constants can be used in arithmetic to set other constant values.
		//They can also initialize each other.
	}

	class Animal
	{
		public const int Legs = 4;

		public int LegsInAnimal()
		{
			return Legs;
		}

		public class NestedAnimal
		{
			public int LegsInNestedAnimal()
			{
				return Legs;
			}
		}
	}

	[Step(5)]
	public void NestedClassesInheritConstantsFromEnclosingClasses()
	{
		var nestedAnimal = new Animal.NestedAnimal();
		Assert.Equal(FILL_ME_IN, nestedAnimal.LegsInNestedAnimal());

		//QUESTION: Do nested classes inherit their parent's scope?
	}

	class Reptile : Animal
	{
		public int LegsInReptile()
		{
			return Legs;
		}
	}

	[Step(6)]
	public void SubclassesInheritConstantsFromParentClasses()
	{
		//If a Reptile is an Animal, zen is achieved
		//when you realize they too will have legs.
		var reptile = new Reptile();
		Assert.Equal(FILL_ME_IN, reptile.LegsInReptile());
	}

	class MyAnimals
	{
		public const int Legs = 2;

		public class Bird : Animal
		{
			public int LegsInBird()
			{
				return Legs;
			}
		}
	}

	[Step(7)]
	public void WhoWinsWithBothNestedAndInheritedConstants()
	{
		var bird = new MyAnimals.Bird();
		Assert.Equal(FILL_ME_IN, bird.LegsInBird());

		/* QUESTION: Which has precedence: The constant in the lexical scope,
		   or the constant from the inheritance hierarchy? */
	}
}