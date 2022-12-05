using NUnit.Framework;
using System;

namespace AdventOfCode2022
{
    public class Day4
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day4.txt");
        }

        [Test]
        public void Part1()
        {
            var contained = 0;
            foreach(var pair in fileData)
            {
                var ranges = pair.Split(',');
                var range1 = ranges[0].Split('-');
                var range2 = ranges[1].Split('-');

                var range1Start = int.Parse(range1[0]);
                var range1End = int.Parse(range1[1]);
                var range2Start = int.Parse(range2[0]);
                var range2End = int.Parse(range2[1]);

                if ((range1Start <= range2Start && range1End >= range2End) || (range1Start >= range2Start && range1End <= range2End))
                {
                    contained++;
                }
                
            }
            Console.WriteLine(contained);
        }

        [Test]
        public void Part2()
        {
            var contained = 0;
            foreach (var pair in fileData)
            {
                var ranges = pair.Split(',');
                var range1 = ranges[0].Split('-');
                var range2 = ranges[1].Split('-');

                var range1Start = int.Parse(range1[0]);
                var range1End = int.Parse(range1[1]);
                var range2Start = int.Parse(range2[0]);
                var range2End = int.Parse(range2[1]);

                if (
                    (range1Start >= range2Start && range1Start <= range2End) || 
                    (range1End >= range2Start && range1End <= range2End) ||
                    (range2Start >= range1Start && range2Start <= range1End) ||
                    (range2End >= range1Start && range2End <= range1End))
                {
                    contained++;
                }

            }
            Console.WriteLine(contained);
        }
    }
}
