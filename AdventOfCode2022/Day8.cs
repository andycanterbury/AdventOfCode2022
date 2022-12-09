using NUnit.Framework;
using System;

namespace AdventOfCode2022
{
    public class Day8
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day8.txt");
        }

        [Test]
        public void Part1()
        {
            var answer = fileData[0].Length; //the whole top row is visible
            for (int i = 1; i < fileData.Length - 1; i++) // start at row 1, since 0 is already handled.
            {
                answer += 2; //edge trees are visible
                for (int j = 1; j < fileData[i].Length-1; j++)
                {
                    if (IsVisibleFromWest(fileData[i], j))
                    {
                        answer++;
                        continue;
                    }
                    if (IsVisibleFromEast(fileData[i], j))
                    {
                        answer++;
                        continue;
                    }
                    if (IsVisibleFromNorth(fileData, i, j))
                    {
                        answer++;
                        continue;
                    }
                    if (IsVisibleFromSouth(fileData, i, j))
                    {
                        answer++;
                        continue;
                    }

                }
            }
            answer += fileData[fileData.Length-1].Length; //the whole bottom row is visible
            Console.WriteLine(answer);
        }

        [Test]
        public void Part2()
        {
            var answer = 0;
            for (int i = 1; i < fileData.Length-1; i++)
            {
                for (int j = 1; j < fileData[i].Length-1; j++)
                {
                    var west = ViewToWest(fileData[i], j);
                    var east = ViewToEast(fileData[i], j);
                    var north = ViewToNorth(fileData, i, j);
                    var south = ViewToSouth(fileData, i, j);
                    var view = west * east * north * south;
                    if (view > answer)
                    {
                        answer = view;
                    }

                }
            }
            Console.WriteLine(answer);
        }

        public bool IsVisibleFromWest(string row, int treeIndex)
        {
            var targetTreeHeight = row[treeIndex];
            for (int i = 0; i < treeIndex; i++)
            {
                if (row[i] >= targetTreeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsVisibleFromEast(string row, int treeIndex)
        {
            var targetTreeHeight = row[treeIndex];
            for (int i = row.Length-1; i > treeIndex; i--)
            {
                if (row[i] >= targetTreeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsVisibleFromNorth(string[] grid, int treeRowIndex, int treeColIndex)
        {
            var targetTreeHeight = grid[treeRowIndex][treeColIndex];
            for (int i = 0; i < treeRowIndex; i++)
            {
                if (grid[i][treeColIndex] >= targetTreeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsVisibleFromSouth(string[] grid, int treeRowIndex, int treeColIndex)
        {
            var targetTreeHeight = grid[treeRowIndex][treeColIndex];
            for (int i = grid.Length-1; i > treeRowIndex; i--)
            {
                if (grid[i][treeColIndex] >= targetTreeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        public int ViewToNorth(string[] grid, int treeRowIndex, int treeColIndex)
        {
            int viewDistance = 0;
            int targetTreeHeight = grid[treeRowIndex][treeColIndex];
            for (int i = treeRowIndex-1; i >= 0; i--)
            {
                viewDistance++;
                if (grid[i][treeColIndex] >= targetTreeHeight)
                {
                    return viewDistance;
                }
            }
            return viewDistance;
        }

        public int ViewToSouth(string[] grid, int treeRowIndex, int treeColIndex)
        {
            int viewDistance = 0;
            int targetTreeHeight = grid[treeRowIndex][treeColIndex];
            for (int i = treeRowIndex+1; i < grid.Length; i++)
            {
                viewDistance++;
                if (grid[i][treeColIndex] >= targetTreeHeight)
                {
                    return viewDistance;
                }
            }
            return viewDistance;
        }

        public int ViewToEast(string row, int treeIndex)
        {
            var viewDistance = 0;
            var targetTreeHeight = row[treeIndex];
            for (int i = treeIndex + 1; i < row.Length; i++)
            {
                viewDistance++;
                if (row[i] >= targetTreeHeight)
                {
                    return viewDistance;
                }
            }
            return viewDistance;
        }

        public int ViewToWest(string row, int treeIndex)
        {
            var viewDistance = 0;
            var targetTreeHeight = row[treeIndex];
            for (int i = treeIndex - 1; i >= 0; i--)
            {
                viewDistance++;
                if (row[i] >= targetTreeHeight)
                {
                    return viewDistance;
                } 
            }
            return viewDistance;
        }
    }
}
