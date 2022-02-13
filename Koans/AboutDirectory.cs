using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using DotNetCoreKoans.Engine;
using System.IO;
using System.Text;
using IOPath = System.IO.Path;

namespace DotNetCoreKoans.Koans
{
    public class AboutDirectory : Koan
    {
        private static string directoryName = "temp directory";
        private static string fullPath = IOPath.Combine(IOPath.GetTempPath(), directoryName);

        [Step(1)]
        public void CreatingAndDeletingDirectory()
        {            
            Directory.CreateDirectory(fullPath);

            Assert.Equal(true, Directory.Exists(fullPath));

            Directory.Delete(fullPath);

            Assert.Equal(false, Directory.Exists(fullPath));
        }
        [Step(2)]
        public void GetDirectoryInfo()
        {
            var directoryInfo = new DirectoryInfo(fullPath);
            directoryInfo.Create();

            Assert.Equal(true, directoryInfo.Exists);
            Assert.Equal(directoryName, directoryInfo.Name);

            directoryInfo.Delete(false);
        }
        [Step(3)]
        public void CreateSubDirectory()
        {
            var directoryInfo = new DirectoryInfo(fullPath);
            directoryInfo.Create();
            directoryInfo.CreateSubdirectory("subdirectory1");
            directoryInfo.CreateSubdirectory("subdirectory2");

            Assert.Equal(2, directoryInfo.GetDirectories().Length);

            directoryInfo.Delete(true);

        }
        [Step(4)]
        public void GetFilesInDirectory()
        {


            var directoryInfo = new DirectoryInfo(fullPath);
            directoryInfo.Create();
            using (File.Create(IOPath.Combine(fullPath, "file1")));
            using(File.Create(IOPath.Combine(fullPath, "file2")));

            Assert.Equal(2, directoryInfo.GetFiles().Length);

            directoryInfo.Delete(true);

        }

    }
}