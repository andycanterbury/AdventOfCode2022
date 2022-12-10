using NUnit.Framework;
using System;

namespace AdventOfCode2022
{
    public class Day10
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day10.txt");
        }

        [Test]
        public void TestCycles()
        {
            var clock = 10;
            var result = IsKeyCycle(clock);
            Assert.IsFalse(result);

            clock = 20;
            result = IsKeyCycle(clock);
            Assert.IsTrue(result);

            clock = 40;
            result = IsKeyCycle(clock);
            Assert.IsFalse(result);

            clock = 60;
            result = IsKeyCycle(clock);
            Assert.IsTrue(result);

            clock = 100;
            result = IsKeyCycle(clock);
            Assert.IsTrue(result);

            clock = 140;
            result = IsKeyCycle(clock);
            Assert.IsTrue(result);

            clock = 180;
            result = IsKeyCycle(clock);
            Assert.IsTrue(result);

            clock = 220;
            result = IsKeyCycle(clock);
            Assert.IsTrue(result);

        }

        [Test]
        public void Part1()
        {
            var xRegister = 1;
            var clock = 1;
            var signalStrength = 0;

            foreach(var instruction in fileData)
            {
                if (IsKeyCycle(clock))
                {
                    signalStrength += (clock * xRegister);
                }
                if (instruction == "noop")
                {
                    clock++;
                    continue;
                }
                var value = int.Parse(instruction.Split(' ')[1]);
                clock++;
                if (IsKeyCycle(clock))
                {
                    signalStrength += (clock * xRegister);
                }
                clock++;
                xRegister += value;
            }

            Console.WriteLine(signalStrength);
        }

        [Test]
        public void Part2()
        {
            var clock = 0;
            var xRegister = 1;
            foreach(var instruction in fileData)
            {
                DrawPixel(clock, xRegister);
                if (instruction.StartsWith("addx"))
                {
                    var value = int.Parse(instruction.Split(' ')[1]);
                    clock = IncrementClock(clock);
                    DrawPixel(clock, xRegister);
                    clock = IncrementClock(clock);
                    xRegister += value;
                } 
                else
                {
                    clock = IncrementClock(clock);
                }

            }
        }

        public bool IsKeyCycle(int clock)
        {
            if (clock == 20) return true;
            if (clock > 20 && (clock-20) % 40 == 0) return true;
            return false;
        }

        public void DrawPixel(int clock, int xRegister)
        {
            char pixel = '.';
            if (clock % 40 >= (xRegister - 1) && clock % 40 <= (xRegister + 1))
            {
                pixel = '#';
            }
            Console.Write(pixel);
        }

        public int IncrementClock(int clock)
        {
            clock++;
            if (clock % 40 == 0)
            {
                Console.WriteLine("");
            }
            return clock;
        }
    }
}
