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
        //File is async c# class that provides static methods for creating, copying, deleting, moving, and opening files, and helps create a FileStream object.

        [Step(1)]
        public void CreatingAndDeletingFile()
        {
            string path = IOPath.GetTempFileName(); // GetTempFileName() Creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.
            
            Assert.Equal(FILL_ME_IN, File.Exists(path)); // How to make this statement true? 

            File.Delete(path);

            Assert.Equal(FILL_ME_IN, File.Exists(path)); // How to make this statement true? 
        }
        [Step(2)]
        public void CopyFile()
        {
            string path = IOPath.GetTempFileName();
            string newPath = IOPath.Combine(IOPath.GetTempPath(), "newFile.txt");

            File.Delete(newPath);
            File.Copy(path, newPath);

            Assert.Equal(FILL_ME_IN, File.Exists(newPath)); // How to make this statement true? 
            
        }
        [Step(3)]
        public void GetFileInfo()
        {
            string path = IOPath.GetTempFileName();
            FileInfo fileInfo = new FileInfo(path);

            Assert.Equal(FILL_ME_IN, fileInfo.Exists); // How to make this statement true? 
            Assert.Equal(FILL_ME_IN, fileInfo.FullName); // what is the file name?

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
            Assert.Equal(FILL_ME_IN, readMessage); // what is the message?
        }

        [Step(5)]
        public void ReadLines()
        {

            string data = "Line0\nLine1\nLine2";
            string path = createFileAndFillIN(data);

            var lines = File.ReadAllLines(path);
            
            Assert.Equal(FILL_ME_IN, lines.Length); // what is the number of lines?
            Assert.Equal(FILL_ME_IN, lines[1]); // what is written in the line No.2 ?
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