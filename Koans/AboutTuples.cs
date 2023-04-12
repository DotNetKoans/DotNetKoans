using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutTuples : Koan
{

	#region 1: Tuple can group multiple elements together


	// A tuple is a C# class
	[Step(1)]
	public void TupleIsACSharpClass()
	{
		var batman = new Tuple<string, string>("Bruce", "Wayne");

		Assert.Equal(FILL_ME_IN, batman.Item1); // FirstName
		Assert.Equal(FILL_ME_IN, batman.Item2); // LastName
	}

	// with some syntax sugar
	[Step(2)]
	public void WithSomeSyntaxSugar()
	{
		var batman = ("Bruce", "Wayne");

		Assert.Equal(FILL_ME_IN, batman.Item1); // FirstName
		Assert.Equal(FILL_ME_IN, batman.Item2); // LastName
	}

	// You can name values in the tuple
	[Step(3)]
	public void YouCanNameValuesInTuple()
	{
		var lastName = "Wayne";
		var batman = (firstName: "Bruce", lastName);

		Assert.Equal(FILL_ME_IN, batman.firstName);
		Assert.Equal(FILL_ME_IN, batman.lastName);
	}

	// A tuple can be used as a function parameter
	[Step(4)]
	public void TupleCanBeUsedInFunction()
	{
		var batman = (firstName: "Bruce", lastName: "Wayne");

		Assert.Equal(FILL_ME_IN, GetFullName(batman));
	}

	public string GetFullName((string firstName, string lastName) data)
	{
		return $"{data.firstName} {data.lastName}";
	}

	// A tuple can contain different types
	[Step(5)]
	public void TupleCanContainDifferentTypes()
	{
		var enemy = new List<string>() { "Joker", "Penguin", "Riddler", "Catwoman" };
		var batman1966 = (firstName: "Bruce", lastName: "Wayne", enemy);

		Assert.Equal(typeof(FillMeIn), batman1966.firstName.GetType());
		Assert.Equal(typeof(FillMeIn), batman1966.enemy.GetType());

	}



	#endregion


	#region 2: equality

	// Two tuples are equal when they have the same values
	[Step(6)]
	public void TwoTupleAreEquaWhenHaveSameValuesInSameOrder()
	{
		var batman = (firstName: "Bruce", lastName: "Wayne");

		var bruceWayne = ("Bruce", "Wayne");
		Assert.Equal(FILL_ME_IN, batman == bruceWayne);

		var wayneBruce = ("Wayne", "Bruce");
		Assert.Equal(FILL_ME_IN, batman == wayneBruce);

		var azrael = (firstName: "Jean-Paul", lastName: "Valley");
		Assert.Equal(FILL_ME_IN, batman == azrael);
	}

	// Two lists in a tuple are compared by reference
	[Step(7)]
	public void ButListStillUsedReferenceEquality()
	{
		var enemy1966 = new List<string>() { "Joker", "Penguin", "Riddler", "Catwoman" };
		var batman1966 = (firstName: "Bruce", lastName: "Wayne"
			, enemy: enemy1966);

		var aDud = (firstName: "Bruce", lastName: "Wayne"
			, enemy: enemy1966);
		Assert.Equal(FILL_ME_IN, batman1966 == aDud);

		var newBatman1966 = (firstName: "Bruce", lastName: "Wayne"
			, enemy: new List<string>() { "Joker", "Penguin", "Riddler", "Catwoman" });
		Assert.Equal(FILL_ME_IN, batman1966 == newBatman1966); //this one is tricky
	}

	#endregion

	#region 3: Usage

	// A Tuple can replace out parameter
	[Step(8)]
	public void TupleReplaceOutParameter()
	{
		/// When your function need to return more than one value, you have to use out parameter
		/// Now, we can use tuples
		var otherEnemies = new List<string>();
		var mainEnemy = extractMainEnemyWithOut("Joker,Penguin,Riddler,Catwoman", out otherEnemies);

		Assert.Equal(FILL_ME_IN, mainEnemy);
		Assert.Equal(FILL_ME_IN, string.Join(",", otherEnemies));

		var extract = extractMainEnemyWithTuple("Joker,Penguin,Riddler,Catwoman");

		Assert.Equal(FILL_ME_IN, extract.mainEnemy);
		Assert.Equal(FILL_ME_IN, string.Join(",", extract.othersEnemies));

		// What syntax do you prefer?
	}

	private string extractMainEnemyWithOut(string enemies, out List<string> othersEnemies)
	{
		var listEnemies = enemies.Split(",");
		var mainEnemy = listEnemies.First();
		othersEnemies = listEnemies.Skip(1).ToList();
		return mainEnemy;
	}

	private (string mainEnemy, List<string> othersEnemies) extractMainEnemyWithTuple(string enemies)
	{
		var listEnemies = enemies.Split(",");
		var mainEnemy = listEnemies.First();
		var othersEnemies = listEnemies.Skip(1).ToList();
		return (mainEnemy, othersEnemies);
	}

	// Tuple with extension can replace class 
	[Step(9)]
	public void TupleWithExtensionCanReplaceClass()
	{

		var batman1966Class = new Movie("Bruce", "Wayne");
		batman1966Class.AddMainEnemy("Joker");
		batman1966Class.AddAlso("Penguin");
		batman1966Class.AddAlso("Riddler");
		batman1966Class.AddAlso("Catwoman");
		string titleClass = batman1966Class.GetTitle();

		Assert.Equal(FILL_ME_IN, titleClass);

		// You can know more on extension with koan AboutMethods
		string titleTuple = ("Bruce", "Wayne")
			.WithMainEnemy("Joker")
			.AndAlso("Penguin")
			.AndAlso("Riddler")
			.AndAlso("Catwoman")
			.GetTitle();

		Assert.Equal(FILL_ME_IN, titleTuple);
		/* 
		 What's syntax do you prefer?
		If you want to know more on tuple + extension advantages, look at : https://github.com/MostlyAdequate/mostly-adequate-guide/blob/master/ch03.md
		*/
	}

	#endregion

}

class Movie
{
	private readonly string firstName;
	private readonly string lastName;
	private string mainEnemy;

	private List<string> enemies = new List<string>();

	public Movie(string firstName, string lastName)
	{
		this.firstName = firstName;
		this.lastName = lastName;
	}

	public void AddMainEnemy(string name)
	{
		mainEnemy = name;
	}

	public void AddAlso(string name)
	{
		enemies.Add(name);
	}

	public string toStringEnemies()
	{
		var result = mainEnemy;
		if (enemies.Any())
		{
			result += ", " + string.Join(", ", enemies);
		}

		return result == "" ? "himself" : result; // If you don't understand, please look in AboutControlStatements.cs > TernaryOperators
	}

	public string GetTitle()
	{
		return $"A move with {firstName} {lastName} against {toStringEnemies()}";
	}
}


public static class MovieExtension
{
	public static string GetTitle(this (string firstName, string lastName, List<string> enemies) movie)
	{
		string strEnemies = movie.enemies.Any()
			? string.Join(", ", movie.enemies)
			: "himself"; // If you don't understand, please look in AboutControlStatements.cs > TernaryOperators

		return $"A move with {movie.firstName} {movie.lastName} against {strEnemies}";
	}

	public static (string firstName, string lastName, List<string> enemies) WithMainEnemy(this (string firstName, string lastName) movie, string enemyName)
	{
		return (movie.firstName, movie.lastName, new List<string>() { enemyName });
	}

	public static (string firstName, string lastName, List<string> enemies) AndAlso(this (string firstName, string lastName, List<string> enemies) movie, string enemyName)
	{
		var enemies = movie.enemies.Append(enemyName).ToList();
		return (movie.firstName, movie.lastName, enemies);
	}
}