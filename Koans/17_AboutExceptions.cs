using System;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutExceptions : Koan
{
	// Exceptions are 'thrown' when a program runs into something that it wasn't expecting. 
	// Most of the time, these exceptions will cause the programme to 'break' or stop executing.
	// We can use 'exception handling' to specify exactly what we want to happen when we run into an issue.
	// Exceptions are types which inherit from the base 'System.Exception' class

	[Step(1)]
	public void CatchingAnError()
	{
		// We can use a try catch block to 'catch' any errors that occur in the 'try' section
		// Errors that are not 'caught' or 'handled' will usually trigger an 'Unhandled Exception', 
		// this is when your console might display some nasty red text and a complicated wall of text known as the call stack.
		// Catching and handling errors gracefully allows more control over your program and provides 
		// much nicer information to fellow developers (Who will be super grateful!)

		var awareness = 0;

		try
		{
			throw new Exception("We tried something, but it did not work out");
		}
		// FYI: This will catch all exceptions but we can be more specific as you will see when you continue your journey
		catch (Exception)
		{
			awareness += 1;
		}

		Assert.Equal(FILL_ME_IN, awareness);
	}

	[Step(3)]
	public void ExceptionMessages()
	{
		// An exception usually contains a message which contains more information about what happened.
		// We can access the exception object by defining it in the catch block

		string status;

		try
		{
			throw new Exception("Ohm"); // A generic exception with the message "Ohm"
			status = "Everything is fine";
		}
		catch (Exception exceptionObject)
		{
			status = exceptionObject.Message;
		}

		Assert.Equal(FILL_ME_IN, status);

	}

	[Step(4)]
	public void SystemException()
	{
		// A system exception is thrown when the system ends up in a bad place.
		// For example if you try to save something but the system cannot do it.

		var KarmaIsSaved = false;

		try
		{
			SaveKarmaToDisk();
			KarmaIsSaved = true;
		}
		// FYI: This will now only catch exceptions that are of the type System.SystemException
		catch (SystemException)
		{
			// You can put any logic you want in here and it will only run if the exception is thrown.
			Console.WriteLine("Our program had an error, your karma was not saved. Sorry man");
		}

		Assert.Equal(FILL_ME_IN, KarmaIsSaved);
	}

	[Step(5)]
	public void IndexOutOfBoundsException()
	{
		// An Index out of bounds exception will be thrown if the application tries to access an index that is simply not there

		string[] states = { "Enlightened", "Distracted", "Gaining Awareness" };

		string myCurrentState;

		try
		{
			myCurrentState = states[3];
		}
		catch (IndexOutOfRangeException)
		{
			myCurrentState = states[2];
		}

		Assert.Equal(FILL_ME_IN, myCurrentState);
	}

	[Step(6)]
	public void OurVeryOwnException()
	{
		// We can create our own exceptions that will help other developers or users

		var IKnowNothingAboutExceptions = true;

		try
		{
			if (IKnowNothingAboutExceptions)
			{
				throw new ConfidenceException(
					@"Have faith in yourself, you can find out more about exceptions at
                         https://docs.microsoft.com/en-us/dotnet/standard/exceptions/?redirectedfrom=MSDN");
			}
		}
		catch (ConfidenceException)
		{
			IKnowNothingAboutExceptions = false;
		}

		Assert.Equal(FILL_ME_IN, IKnowNothingAboutExceptions);
	}

	// This is how we defined our own custom exception. 
	// It is just a class that inherits from the System.Exception class. 
	public class ConfidenceException : Exception
	{

		public ConfidenceException() { }

		public ConfidenceException(string message) : base(message) { }
	}

	// This is just a helper function, don't worry about it
	public void SaveKarmaToDisk() =>
		throw new System.IO.IOException();
}