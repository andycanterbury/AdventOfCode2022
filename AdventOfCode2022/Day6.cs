using NUnit.Framework;
using System;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day6
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day6.txt");
        }

        [Test]
        public void Part1Samples()
        {
            var sample1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
            var result = StartOfPacket(sample1);
            Assert.AreEqual(result, 7);

            var sample2 = "bvwbjplbgvbhsrlpgdmjqwftvncz";
            result = StartOfPacket(sample2);
            Assert.AreEqual(result, 5);

            var sample3 = "nppdvjthqldpwncqszvftbrmjlhg";
            result = StartOfPacket(sample3);
            Assert.AreEqual(result, 6);

            var sample4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
            result = StartOfPacket(sample4);
            Assert.AreEqual(result, 10);

            var sample5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";
            result = StartOfPacket(sample5);
            Assert.AreEqual(result, 11);
        }


        [Test]
        public void Part1()
        {
            var answer = StartOfPacket(fileData[0]);
            Console.WriteLine(answer);
        }

        [Test]
        public void Part2Samples()
        {
            var sample1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
            var result = StartOfMessage(sample1);
            Assert.AreEqual(result, 19);

            var sample2 = "bvwbjplbgvbhsrlpgdmjqwftvncz";
            result = StartOfMessage(sample2);
            Assert.AreEqual(result, 23);

            var sample3 = "nppdvjthqldpwncqszvftbrmjlhg";
            result = StartOfMessage(sample3);
            Assert.AreEqual(result, 23);

            var sample4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
            result = StartOfMessage(sample4);
            Assert.AreEqual(result, 29);

            var sample5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";
            result = StartOfMessage(sample5);
            Assert.AreEqual(result, 26);
        }

        [Test]
        public void Part2()
        {
            var answer = StartOfMessage(fileData[0]);
            Console.WriteLine(answer);
        }

        public int StartOfPacket(string signal)
        {
            for(int i = 0; i < signal.Length; i++)
            {
                if (signal.Substring(i, 4).Distinct().Count() == 4) return i + 4;
            }
            return 0;
        }

        public int StartOfMessage(string signal)
        {
            for (int i = 0; i < signal.Length; i++)
            {
                if (signal.Substring(i, 14).Distinct().Count() == 14) return i + 14;
            }
            return 0;
        }
    }
}
