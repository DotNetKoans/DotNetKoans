using System;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutEnumerations : Koan
{
	/*
	An enumeration is a value type that represents a set of named constants
	whose underlying type is an integral numeric. You create an enumeration
    using the enum keyword and a title followed by the enum's members.

	Following are three definitions of enums that we will be using throughout
	the Koans. Review them first and notice how they're defined, what the
	structure and syntax looks like, how they are cased, how they are assigned
	values and then move on to the first step.
	*/
	enum MeditationForms
	{
		Mindfulness,
		SilentIllumination,
		Contemplation
	}

	enum LogLevel
	{
		Debug = 100,
		Warning = 200,
		Verbose = 300
	}

	[Flags]
	enum DayOfTheWeek
	{
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}

	[Step(1)]
	public void CreatingAnInstance()
	{
		/*
		Creating an instance of an enum is as easy as assigning a member
		of the enum to a new variable. For instance:
		*/
		var mindfulness = MeditationForms.Mindfulness;

		/*
		While the underlying type of the instance above will be an integer,
		enums are first class types in the C# language. The type of the
		variable 'mindfulness' will be the enum itself.
		*/
		Assert.Equal(typeof(FillMeIn), mindfulness.GetType());

		/*
		Adding new members to an enum is straight-forward and as you'd expect.
		Try adding a new member to the 'MeditationForms' enum.
		*/
		Assert.True(Enum.IsDefined(typeof(MeditationForms), "Observation"));
	}

	[Step(2)]
	public void CastingToAnEnum()
	{
		/*
		Because the underlying type of enum members are actually integers,
		you can create instances of an enum by casting an integer value to
		an enum. 

		Note that the associated constant value of members start with zero
		and increase by one.
		*/
		var quietForm = (MeditationForms)1;
		Assert.Equal(FILL_ME_IN, quietForm);

		/*
		Why would casting integers to enums be valuable? You may want to
		save values to a database perhaps. Those values would be stored as
		an integer and when querying for those values, you'd be handed an
		integer back. For instance:

		var usersPreferredForm = (MeditationForms)row['usersPreferredForm'];

		Handling integer values as enumerations improves readability.
		*/
	}

	[Step(3)]
	public void MemberValuesCanBeExplicit()
	{
		/*
		There may be cases where you don't want enum members to start at zero
		and incrementing by one. Perhaps you want them incrementing by 100.
		*/
		var logLevel = LogLevel.Verbose;
		Assert.Equal(FILL_ME_IN, (int)logLevel);
	}

	[Step(4)]
	public void EnumsCanBeFlags()
	{
		/*
		Enums can represent a combination of choices. When an enum is
		decorated with the '[Flag]' attribute, it changes the underlying
		type to a bit field. This allows for multiple members to be assigned
		to a single value.

		Notice we're using the OR operator to concatenate multiple days.

		We're missing Friday!
		*/

		var workWeek = DayOfTheWeek.Monday | DayOfTheWeek.Tuesday | DayOfTheWeek.Wednesday | DayOfTheWeek.Thursday | FILL_ME_IN;
		Assert.True(workWeek.HasFlag(DayOfTheWeek.Friday)); // Assuming you work Fridays :)
	}

	/*
	This was just an introduction to the many uses of enums. If you'd like
	to dig deeper, you can find more information at:

	https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
	https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/enum
	https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=netcore-3.1
	*/
}