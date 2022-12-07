using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day7
    {
        public static List<string> fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day7.txt").ToList();
        }

        [Test]
        public void Part1()
        {
            var fileSystem = new Directory { Contents = { new Directory { Name = "/" } } };
            ParseFileSystemData(fileSystem);
            var answer = CalculateDirectoryTotals(fileSystem);
            Console.WriteLine(answer);
        }

        [Test]
        public void Part2()
        {
            var fileSystem = new Directory { Contents = { new Directory { Name = "/" } } };
            ParseFileSystemData(fileSystem);
            var root = (Directory)fileSystem.Contents[0];
            var currentFree = 70000000 - root.DirectorySize;
            var targetSize = 30000000 - currentFree;
            var answer = FindDirToDelete(targetSize, fileSystem);
            Console.WriteLine(answer);
        }

        public static Directory ParseFileSystemData(Directory fileSystem)
        {
            var currentLine = fileData[0];
            fileData.RemoveAt(0); //Pop this item off the list
            var line = currentLine.Split(' ');
            
            if (line[0] == "$") //It's a command
            {
                if (line[1] == "cd") 
                {

                    if (line[2] == "..") return fileSystem;
                    var children = ParseFileSystemData((Directory)fileSystem.Contents.First(d => d.Name == line[2] && d.GetType() == typeof(Directory)));
                    fileSystem.DirectorySize += children.DirectorySize;
                }

            } 
            else
            {
                if (line[0] == "dir") //It's a directory
                {
                    fileSystem.Contents.Add(new Directory { Name = line[1] });
                } else //It's a file
                {
                    var size = int.Parse(line[0]);
                    fileSystem.Contents.Add(new File { Name = line[1], Size = size });
                    fileSystem.DirectorySize += size;
                }
            }
            if (fileData.Count > 0)
            {
                ParseFileSystemData(fileSystem);
            }
            return fileSystem;
        }

        public static int CalculateDirectoryTotals(Directory fileSystem)
        {
            int total = 0;
            foreach(Directory dir in fileSystem.Contents.Where(d => d.GetType() == typeof(Directory)))
            {
                if (dir.DirectorySize <= 100000)
                {
                    total += dir.DirectorySize;
                }
                total += CalculateDirectoryTotals(dir);
            }
            return total;
        }

        public static int FindDirToDelete(int targetSize, Directory fileSystem)
        {
            var possibleDirs = DirOverTargetSize(targetSize, fileSystem);
            return possibleDirs.OrderBy(d => d.DirectorySize).First().DirectorySize;
        }

        public static List<Directory> DirOverTargetSize(int targetSize, Directory fileSystem)
        {
            var possibleDirs = new List<Directory>();
            foreach (Directory dir in fileSystem.Contents.Where(d => d.GetType() == typeof(Directory)))
            {
                if (dir.DirectorySize >= targetSize)
                {
                    possibleDirs.Add(dir);
                    possibleDirs.AddRange(DirOverTargetSize(targetSize, dir));
                }
            }
            return possibleDirs;
        }

        public class FileSystemItem 
        { 
            public string Name { get; set; }
        }

        public class Directory : FileSystemItem 
        { 
            public Directory()
            {
                Contents = new List<FileSystemItem>();
            }
            public List<FileSystemItem> Contents { get; set; }
            public int DirectorySize { get; set; } = 0;
        }

        public class File : FileSystemItem
        {
            public int Size { get; set; }
        }


    }
}
