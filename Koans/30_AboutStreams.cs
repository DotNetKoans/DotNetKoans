using Xunit;
using System.IO;
using System.Text;
using DotNetKoans.Engine;
using IOPath = System.IO.Path;
using System.Collections.Generic;
using System;

namespace DotNetKoans.Koans;

public class AboutStreams : Koan
{
	// FileStreams are used to read from and write to files

	[Step(1)]
	public void WriteReadStream()
	{
		string path = IOPath.GetTempFileName();

		List<string> valuesToWrite = new List<string>()
		{
			"Line 1",
			"Line 2",
			"Line 3",
			"Line 4"
		};

		//Create file using file stream
		using (FileStream fileStream = File.Create(path))
		{
			foreach (string writeValue in valuesToWrite)
			{
				//Write using a buffer
				byte[] info = new UTF8Encoding(true).GetBytes(writeValue);
				fileStream.Write(info, 0, info.Length);
			}
		}

		string readString = string.Empty;

		//Read the file using a file stream
		using (FileStream fs = File.OpenRead(path))
		{
			//Read using a buffer
			byte[] buffer = new byte[1024];
			UTF8Encoding temp = new UTF8Encoding(true);
			int readLen;
			while ((readLen = fs.Read(buffer, 0, buffer.Length)) > 0)
			{
				readString += temp.GetString(buffer, 0, readLen);
			}
		}

		//What is the string that is read from the file?
		Assert.Equal(FILL_ME_IN, readString);
	}


	[Step(2)]
	public void ReadStreamWithDisposal()
	{
		string path = IOPath.GetTempFileName();

		List<string> fileLines = new List<string>()
		{
			"1","2","3","4","5"
		};

        //Create the file.
		FileStream fileStream = null;

        try
		{
			fileStream = File.Create(path);

            foreach (string line in fileLines)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(line);
                fileStream.Write(info, 0, info.Length);
            }
		}
		finally
		{
			//Dispose of the file stream after writing is complete
			fileStream.Dispose();
		}

		fileStream = null;
		string fileContents = string.Empty;

		try
		{
			fileStream = File.OpenRead(path);
			fileContents = ReadAllFromFileStream(fileStream);
		}
		finally
		{
			//Dispose of the file stream after reading is complete
			fileStream.Dispose();
		}

		//What are the file contents that are read?
		Assert.Equal(FILL_ME_IN, fileContents);
	}

	[Step(3)]
	public void WriteWithDisposedStream()
	{
		string path = IOPath.GetTempFileName();

		//What kind of exception arises when writing to a disposed stream?
		FileStream fileStream = null;
		try
		{
			try
			{
				fileStream = File.Create(path);
			}
			finally
			{
				fileStream.Dispose();
			}

			byte[] info = new UTF8Encoding(true).GetBytes("12345");
			fileStream.Write(info, 0, info.Length);
		}
		catch (Exception ex)
		{
			//What type of exception is this?
			Assert.Equal(typeof(FillMeIn), ex.GetType());
		}

		//Is the file created?
		Assert.Equal(FILL_ME_IN, File.Exists(path));

		string fileContents = null;

		using (fileStream = File.OpenRead(path))
		{
			fileContents = ReadAllFromFileStream(fileStream);
		}

		//What are the contents of the file?
		Assert.Equal(FILL_ME_IN, fileContents);
	}

	[Step(4)]
	public void ReadFromDisposedStream()
	{
		string path = IOPath.GetTempFileName();
		List<string> lines = new List<string>()
		{
			"10", "9", "8", "7", "6"
		};

		CreateFileWithStream(path, lines);

		FileStream fileStream = null;
		string readWithSubroutineResult = string.Empty;

		//What kind of exception arises when reading from a disposed stream?
		try
		{
			try
			{
				fileStream = File.OpenRead(path);
			}
			finally
			{
				fileStream.Dispose();
			}

			readWithSubroutineResult = ReadAllFromFileStream(fileStream);
		}
		catch (Exception ex)
		{
			//What type of exception is this?
			Assert.Equal(typeof(FillMeIn), ex.GetType());
		}

		//What is read from the stream?
		Assert.Equal(FILL_ME_IN, readWithSubroutineResult);
	}

	[Step(5)]
	public void Seeking()
	{
		//Read file using seeking instead of reading all bytes at once
		string path = IOPath.GetTempFileName();

		string writeValue = "Hello World";

		//Create file with writeValue as contents
		using (FileStream createFileStream = File.Create(path))
		{
			byte[] info = new UTF8Encoding(true).GetBytes(writeValue);
			createFileStream.Write(info, 0, info.Length);
		}

		string seekReadValue = string.Empty;

		//Read the file using file stream Seek
		using (FileStream readFileStream = File.OpenRead(path))
		{
			//Iterate on i from 0 to the length of file contents minus 1
			for (int i = 0; i < writeValue.Length; i++)
			{
				readFileStream.Seek(i, SeekOrigin.Begin); //Set the read position of the stream to i, offset from the first beginning
				seekReadValue += (char)readFileStream.ReadByte(); //Read a byte from the stream, convert it a character and append it to the read value
			}
		}

		//What is the read value
		Assert.Equal(FILL_ME_IN, seekReadValue);

		seekReadValue = string.Empty;

		//What happens when the seek offset starts at 4?
		using (FileStream readFileStream = File.OpenRead(path))
		{
			for (int i = 4; i < writeValue.Length; i++)
			{
				readFileStream.Seek(i, SeekOrigin.Begin);
				seekReadValue += (char)readFileStream.ReadByte();
			}
		}

		//What is the string that is read from the file?
		Assert.Equal(FILL_ME_IN, seekReadValue);
	}

	[Step(6)]
	public void SeekingReverseRead()
	{
		string path = IOPath.GetTempFileName();

		string writeValue = "Reverse";

		//Create file with writeValue as contents
		using (FileStream createFileStream = File.Create(path))
		{
			byte[] info = new UTF8Encoding(true).GetBytes(writeValue);
			createFileStream.Write(info, 0, info.Length);
		}

		string seekReadValue = string.Empty;

		//Read the file using file stream Seek
		using (FileStream readFileStream = File.OpenRead(path))
		{
			for (int i = -1; i >= -writeValue.Length; i--)
			{
				//Use SeekOrigin.End instead of SeekOrigin.Begin
				//Use a negative offset to work backwards from the end of the file contents
				readFileStream.Seek(i, SeekOrigin.End);
				seekReadValue += (char)readFileStream.ReadByte();
			}
		}

		//What is the read value
		Assert.Equal(FILL_ME_IN, seekReadValue);
	}

	private void CreateFileWithStream(string path, List<string> fileLines)
	{
		//Create the file.
		using (FileStream fs = File.Create(path))
		{
			foreach (string line in fileLines)
			{
				byte[] info = new UTF8Encoding(true).GetBytes(line);
				fs.Write(info, 0, info.Length);
			}
		}
	}

	private string ReadAllFromFileStream(FileStream fs)
	{
		string readString = string.Empty;

		byte[] b = new byte[1024];
		UTF8Encoding temp = new UTF8Encoding(true);
		int readLen;
		while ((readLen = fs.Read(b, 0, b.Length)) > 0)
		{
			readString += temp.GetString(b, 0, readLen);
		}

		return readString;
	}
}