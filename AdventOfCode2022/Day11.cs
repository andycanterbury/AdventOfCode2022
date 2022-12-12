using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2022
{
    public class Day11
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day11.txt");
        }

        [Test]
        public void Part1()
        {
            var monkeys = ParseMonkeys();
            //Do 20 Rounds
            for(int i = 0; i < 20; i++)
            {
                foreach(var monkey in monkeys)
                {
                    foreach(var item in monkey.Items)
                    {
                        var worry = CalculateWorry(item, monkey.OperationA, monkey.OperationB, monkey.OperationType);
                        worry /= 3;
                        if (worry % monkey.TestDivisor == 0)
                        {
                            monkeys[monkey.TrueTarget].Items.Add(worry);
                        } else
                        {
                            monkeys[monkey.FalseTarget].Items.Add(worry);
                        }
                        monkey.InspectionCount++;
                    }
                    monkey.Items.Clear();
                }
            }
            monkeys = monkeys.OrderByDescending(m => m.InspectionCount).ToList();
            var monkeyBusiness = monkeys[0].InspectionCount * monkeys[1].InspectionCount;
            Console.WriteLine(monkeyBusiness);
        }

        private BigInteger CalculateWorry(BigInteger item, string operationA, string operationB, char operationType)
        {
            BigInteger worry = 0;
            var a = (operationA == "old") ? item : int.Parse(operationA);
            var b = (operationB == "old") ? item : int.Parse(operationB);

            switch (operationType)
            {
                case '+':
                    worry = a + b;
                    break;
                case '-':
                    worry = a - b;
                    break;
                case '*':
                    worry = a * b;
                    break;
                case '/':
                    worry = a / b;
                    break;
            }

            return worry;
        }

        [Test]
        public void Part2()
        {
            var monkeys = ParseMonkeys();
            var lcd = CalculateLCD(monkeys.Select(m => m.TestDivisor).ToList());
            //Do 10000 Rounds
            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var item in monkey.Items)
                    {
                        var worry = CalculateWorry(item, monkey.OperationA, monkey.OperationB, monkey.OperationType);
                        worry %= lcd;
                        if (worry % monkey.TestDivisor == 0)
                        {
                            monkeys[monkey.TrueTarget].Items.Add(worry);
                        }
                        else
                        {
                            monkeys[monkey.FalseTarget].Items.Add(worry);
                        }
                        monkey.InspectionCount++;
                    }
                    monkey.Items.Clear();
                }
            }
            monkeys = monkeys.OrderByDescending(m => m.InspectionCount).ToList();
            var monkeyBusiness = monkeys[0].InspectionCount * monkeys[1].InspectionCount;
            Console.WriteLine(monkeyBusiness);
        }

        public class Monkey
        {
            public List<BigInteger> Items { get; set; } = new List<BigInteger>();
            public char OperationType { get; set; }
            public string OperationA { get; set; }
            public string OperationB { get; set; }
            public int TestDivisor { get; set; } = 0;
            public int TrueTarget { get; set; } = 0;
            public int FalseTarget { get; set; } = 0;
            public long InspectionCount { get; set; } = 0;

        }

        public List<Monkey> ParseMonkeys()
        {
            var monkeys = new List<Monkey>();
            var newMonkey = new Monkey();
            foreach(var line in fileData)
            {
                if(line.Trim().StartsWith("Starting items:"))
                {
                    var items = line.Substring(line.IndexOf(':') + 1).Split(',');
                    newMonkey.Items.AddRange(items.Select(i => BigInteger.Parse(i)));
                }
                if (line.Trim().StartsWith("Operation:"))
                {
                    var ops = line.Substring(line.IndexOf('=') + 2).Split(' ');
                    newMonkey.OperationA = ops[0];
                    newMonkey.OperationType = ops[1][0];
                    newMonkey.OperationB = ops[2];
                }
                if (line.Trim().StartsWith("Test:"))
                {
                    newMonkey.TestDivisor = int.Parse(line.Substring(line.IndexOf('y') + 1).Trim());
                }
                if (line.Trim().StartsWith("If true:"))
                {
                    newMonkey.TrueTarget = int.Parse(line.Substring(line.IndexOf('y') + 1).Trim());
                }
                if (line.Trim().StartsWith("If false:"))
                {
                    newMonkey.FalseTarget = int.Parse(line.Substring(line.IndexOf('y') + 1).Trim());
                }
                if (line.Trim() == "")
                {
                    monkeys.Add(newMonkey);
                    newMonkey = new Monkey();
                }

            }
            monkeys.Add(newMonkey);
            return monkeys;
        }

        public int CalculateLCD(List<int> divisors)
        {
            var workingList = new List<int> (divisors);
            while (workingList.Distinct().Count() > 1)
            {
                var smallest = workingList.IndexOf(workingList.Min());
                workingList[smallest] += divisors[smallest];
            }
            return workingList[0];

        }

        [Test]
        public void TestLCD()
        {
            var list = new List<int> { 3, 4, 6 };
            var result = CalculateLCD(list);
            Assert.AreEqual(12, result);
        }

    }
}
