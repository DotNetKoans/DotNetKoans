using System.IO;
using DotNetKoans.Engine;
using Xunit;
using IOPath = System.IO.Path;

namespace DotNetKoans.Koans;

public class AboutDirectory : Koan
{
	//Directory is a class that provides static methods for creating, moving, and enumerating through directories and subdirectories.

	private static string directoryName = "temp directory";       
	private static string fullPath = IOPath.Combine(IOPath.GetTempPath(), directoryName); // GetTempPath() Returns the path of the current user's temporary folder.

	[Step(1)]
	public void CreatingAndDeletingDirectory()
	{            
		Directory.CreateDirectory(fullPath);

		Assert.Equal(FILL_ME_IN, Directory.Exists(fullPath));

		Directory.Delete(fullPath);

		Assert.Equal(FILL_ME_IN, Directory.Exists(fullPath));
	}
        
	[Step(2)]
	public void GetDirectoryInfo()
	{
		var directoryInfo = new DirectoryInfo(fullPath);
		directoryInfo.Create();

		Assert.Equal(FILL_ME_IN, directoryInfo.Exists);
		Assert.Equal(FILL_ME_IN, directoryInfo.Name);

		directoryInfo.Delete(false);
	}
        
	[Step(3)]
	public void CreateSubDirectory()
	{
		var directoryInfo = new DirectoryInfo(fullPath);
		directoryInfo.Create();
		directoryInfo.CreateSubdirectory("subdirectory1");
		directoryInfo.CreateSubdirectory("subdirectory2");

		Assert.Equal(FILL_ME_IN, directoryInfo.GetDirectories().Length); // what is the number of subdirectories?

		directoryInfo.Delete(true);
	}
        
	[Step(4)]
	public void GetFilesInDirectory()
	{
		var directoryInfo = new DirectoryInfo(fullPath);
		directoryInfo.Create();
            
		using (File.Create(IOPath.Combine(fullPath, "file1")))
		using (File.Create(IOPath.Combine(fullPath, "file2")))
		{
		}

		Assert.Equal(FILL_ME_IN, directoryInfo.GetFiles().Length); // what is the number of files that exist in this directory?

		directoryInfo.Delete(true);

	}

}