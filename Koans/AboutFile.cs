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
    public class AboutFile : Koan
    {
        [Step(1)]
        public void CreatingAndDeletingFile()
        {
            string path = IOPath.GetTempFileName();
            
            Assert.Equal(true, File.Exists(path));

            File.Delete(path);

            Assert.Equal(false, File.Exists(path));
        }
        [Step(2)]
        public void CopyFile()
        {
            string path = IOPath.GetTempFileName();
            string result = IOPath.Combine(IOPath.GetTempPath(), "newFile.txt");

            File.Delete(result);
            File.Copy(path, result);

            Assert.Equal(true, File.Exists(result));
            
        }
        [Step(3)]
        public void GetFileInfo()
        {
            string path = IOPath.GetTempFileName();
            FileInfo fileInfo = new FileInfo(path);

            Assert.Equal(true, fileInfo.Exists);
            Assert.Equal(path, fileInfo.FullName);

        }
        [Step(4)]
        public void ReadFile()
        {

            string data = "Hello World!";
            string path = createFileAndFillIN(data);

            byte[] bytes = new byte[data.Length];
            UTF8Encoding temp = new UTF8Encoding(true);
            string readMessage = "";
            using (FileStream fs = File.OpenRead(path))
            {
                while (fs.Read(bytes, 0, bytes.Length) > 0)
                {
                    readMessage = temp.GetString(bytes);
                }
            }
            Assert.Equal(data, readMessage);
        }

        [Step(5)]
        public void ReadLines()
        {

            string data = "Line0\nLine1\nLine2";
            string path = createFileAndFillIN(data);

            var lines = File.ReadAllLines(path);
            
            Assert.Equal(3, lines.Length);
            Assert.Equal("Line1", lines[1]);
        }

        private string createFileAndFillIN(string data)
        {
            string path = IOPath.GetTempFileName();
            byte[] info = new UTF8Encoding(true).GetBytes(data);
            using (FileStream fs = File.OpenWrite(path))
            {
                fs.Write(info, 0, info.Length);
            }
            return path;
        }


    }
}