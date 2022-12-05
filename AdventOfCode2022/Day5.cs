using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    public class Day5
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day5.txt");
        }

        [Test]
        public void Part1()
        {
            var tempStacks = new List<Stack<char>>();
            var stacks = new List<Stack<char>>();
            var moves = new List<string>();

            var stackData = true;
            foreach(var line in fileData)
            {
                if (line.Trim() == "")
                {
                    stackData = false;
                    continue;
                }

                if (stackData)
                {
                    var stackId = 0;
                    if (!line.Contains('[')) continue;
                    for (int i = 0; i < line.Length; i += 4)
                    {
                        if (tempStacks.Count <= stackId) tempStacks.Add(new Stack<char>());
                        var item = line.Substring(i, 3).Trim();
                        if (item != "")
                        {
                            tempStacks[stackId].Push(item[1]);
                        }
                        stackId++;
                    }
                } 
                else
                {
                    moves.Add(line);
                }

            }

            //reverse the stacks, because stupid data
            foreach(var stack in tempStacks)
            {
                var newStack = new Stack<char>();
                while(stack.Count != 0)
                {
                    newStack.Push(stack.Pop());
                }
                stacks.Add(newStack);
            }

            foreach(var move in moves)
            {
                var movement = ParseMove(move);

                for (int i = 0; i < movement.Count; i++)
                {
                    var item = stacks[movement.StartColIdx].Pop();
                    stacks[movement.DestColIdx].Push(item);
                }
            }

            var answer = "";
            foreach(var stack in stacks)
            {
                answer += stack.Peek();
            }
            Console.WriteLine(answer);
        }

        [Test]
        public void Part2()
        {
            var tempStacks = new List<Stack<char>>();
            var stacks = new List<Stack<char>>();
            var moves = new List<string>();

            var stackData = true;
            foreach (var line in fileData)
            {
                if (line.Trim() == "")
                {
                    stackData = false;
                    continue;
                }

                if (stackData)
                {
                    var stackId = 0;
                    if (!line.Contains('[')) continue;
                    for (int i = 0; i < line.Length; i += 4)
                    {
                        if (tempStacks.Count <= stackId) tempStacks.Add(new Stack<char>());
                        var item = line.Substring(i, 3).Trim();
                        if (item != "")
                        {
                            tempStacks[stackId].Push(item[1]);
                        }
                        stackId++;
                    }
                }
                else
                {
                    moves.Add(line);
                }

            }

            //reverse the stacks, because stupid data
            foreach (var stack in tempStacks)
            {
                var newStack = new Stack<char>();
                while (stack.Count != 0)
                {
                    newStack.Push(stack.Pop());
                }
                stacks.Add(newStack);
            }

            foreach (var move in moves)
            {
                var movement = ParseMove(move);
                var movingStack = new Stack<char>();

                for (int i = 0; i < movement.Count; i++)
                {
                    var item = stacks[movement.StartColIdx].Pop();
                    movingStack.Push(item);
                }
                while (movingStack.Count != 0)
                {
                    stacks[movement.DestColIdx].Push(movingStack.Pop());
                }
            }

            var answer = "";
            foreach (var stack in stacks)
            {
                answer += stack.Peek();
            }
            Console.WriteLine(answer);
        }

        [Test]
        public void TestMoveParser()
        {
            var move = "move 1 from 2 to 1";
            var result = ParseMove(move);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.StartColIdx, 1);
            Assert.AreEqual(result.DestColIdx, 0);
        }

        public class Movement 
        {
            public int Count { get; set; }
            public int StartColIdx { get; set; }
            public int DestColIdx { get; set; }
        }


        public static Movement ParseMove(string move)
        {
            var parts = move.Split(' ');
            return new Movement { Count = int.Parse(parts[1]), StartColIdx = int.Parse(parts[3])-1, DestColIdx = int.Parse(parts[5])-1 };
        }
    }
}
