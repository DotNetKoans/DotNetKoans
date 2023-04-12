using Xunit;
using System.Collections.Generic;
using System;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutControlStatements : Koan
{
	[Step(1)]
	public void IfThenElseStatementsWithBrackets()
	{
		bool b;
		if (true)
		{
			b = true;
		}
		else
		{
			b = false;
		}

		Assert.Equal(FILL_ME_IN, b);
	}

	[Step(2)]
	public void IfThenElseStatementsWithoutBrackets()
	{
		bool b;
		if (true)
			b = true;
		else
			b = false;

		Assert.Equal(FILL_ME_IN, b);

	}

	[Step(3)]
	public void IfThenStatementsWithBrackets()
	{
		bool b = false;
		if (true)
		{
			b = true;
		}

		Assert.Equal(FILL_ME_IN, b);
	}

	[Step(4)]
	public void IfThenStatementsWithoutBrackets()
	{
		bool b = false;
		if (true)
			b = true;

		Assert.Equal(FILL_ME_IN, b);
	}

	[Step(5)]
	public void WhyItsWiseToAlwaysUseBrackets()
	{
		bool b1 = false;
		bool b2 = false;

		int counter = 1;

		if (counter == 0)
			b1 = true;
		b2 = true;

		Assert.Equal(FILL_ME_IN, b1);
		Assert.Equal(FILL_ME_IN, b2);
	}

	[Step(6)]
	public void TernaryOperators()
	{
		Assert.Equal(FILL_ME_IN, (true ? 1 : 0));
		Assert.Equal(FILL_ME_IN, (false ? 1 : 0));
	}

	//This is out of place for control statements, but necessary for Koan 8
	[Step(7)]
	public void NullableTypes()
	{
		int i = 0;
		//i = null; //You can't do this

		int? nullableInt = null; //but you can do this
		Assert.NotNull(FILL_ME_IN);
		Assert.Null(FILL_ME_IN);
	}

	[Step(8)]
	public void AssignIfNullOperator()
	{
		int? nullableInt = null;

		int x = nullableInt ?? 42;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(9)]
	public void IsOperators()
	{
		bool isKoan = false;
		bool isAboutControlStatements = false;
		bool isAboutMethods = false;

		var myType = this;

		if (myType is Koan)
			isKoan = true;

		if (myType is AboutControlStatements)
			isAboutControlStatements = true;

		if (myType is AboutMethods)
			isAboutMethods = true;

		Assert.Equal(FILL_ME_IN, isKoan);
		Assert.Equal(FILL_ME_IN, isAboutControlStatements);
		Assert.Equal(FILL_ME_IN, isAboutMethods);

	}

	[Step(10)]
	public void WhileStatement()
	{
		int i = 1;
		int result = 1;
		while (i <= 3)
		{
			result = result + i;
			i += 1;
		}
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(11)]
	public void BreakStatement()
	{
		int i = 1;
		int result = 1;
		while (true)
		{
			if (i > 3) { break; }
			result = result + i;
			i += 1;
		}
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(12)]
	public void ContinueStatement()
	{
		int i = 0;
		var result = new List<int>();
		while (i < 10)
		{
			i += 1;
			if ((i % 2) == 0) { continue; }
			result.Add(i);
		}
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(13)]
	public void ForStatement()
	{
		var list = new List<string> { "fish", "and", "chips" };
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = (list[i].ToUpper());
		}
		Assert.Equal(FILL_ME_IN, list);
	}

	[Step(14)]
	public void ForEachStatement()
	{
		var list = new List<string> { "fish", "and", "chips" };
		var finalList = new List<string>();
		foreach (string item in list)
		{
			finalList.Add(item.ToUpper());
		}
		Assert.Equal(FILL_ME_IN, list);
		Assert.Equal(FILL_ME_IN, finalList);
	}

	[Step(15)]
	public void ModifyingACollectionDuringForEach()
	{
		var list = new List<string> { "fish", "and", "chips" };
		try
		{
			foreach (string item in list)
			{
				list.Add(item.ToUpper());
			}
		}
		catch (Exception ex)
		{
			Assert.Equal(typeof(FillMeIn), ex.GetType());
		}
	}

	[Step(16)]
	public void CatchingModificationExceptions()
	{
		string whoCaughtTheException = "No one";

		var list = new List<string> { "fish", "and", "chips" };
		try
		{
			foreach (string item in list)
			{
				try
				{
					list.Add(item.ToUpper());
				}
				catch
				{
					whoCaughtTheException = "When we tried to Add it";
				}
			}
		}
		catch
		{
			whoCaughtTheException = "When we tried to move to the next item in the list";
		}

		Assert.Equal(FILL_ME_IN, whoCaughtTheException);
	}
}