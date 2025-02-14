using System;
using System.IO;
using System.Text;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutDisposable : Koan
{
	/*
	IDisposable is an interface that contains only 1 method, Dispose().
        It should be implemented by types that use unmanaged resources
	e.g. streams, files, etc. so that memory can be reclaimed by the
	runtime's garbage collector.

	We should call Dispose() of an object when we are done using it.
	This can be done with the using statement or calling Dispose()
	explicitly in a finally block.
	*/

	const string FILE = "The quick brown fox jumped...";

	[Step(1)]
	public void DisposingAStreamReaderWithUsing()
	{
		// mimic a file stream
		// notice the using keyword
		using var stream = new MemoryStream(Encoding.ASCII.GetBytes(FILE));

		// read the file stream
		// notice the using keyword
		using var reader = new StreamReader(stream);

		// get file contents in readable format
		var result = reader.ReadToEnd();

		Assert.Equal(result, FILL_ME_IN);
	}

	[Step(2)]
	public void DisposingAStreamReaderWithFinally()
	{
		// get a handle outside the try scope
		// so that we can reference the objects in finally block
		MemoryStream stream = null;
		StreamReader reader = null;
		string result;

		try
		{
			// mimic a file stream
			// notice there are no using keyword like previous
			stream = new MemoryStream(Encoding.ASCII.GetBytes(FILE));

			// read the file stream
			// notice there are no using keyword like previous
			reader = new StreamReader(stream);

			// get file contents in readable format
			result = reader.ReadToEnd();
		}
		finally
		{
			stream.Dispose();
			reader.Dispose();
		}

		Assert.Equal(result, FILL_ME_IN);
	}
}