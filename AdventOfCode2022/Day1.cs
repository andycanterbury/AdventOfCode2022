using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day1
    {
        public static string[] fileData;

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/day1.txt");
        }

        [Test]
        public void Part1()
        {
            var elfTotal = 0;
            int calories = 0;
            var maxElfCalories = 0;
            foreach (var foodItem in fileData)
            {
                if (int.TryParse(foodItem, out calories))
                {
                    elfTotal += calories;
                }
                else
                {
                    if (elfTotal >= maxElfCalories)
                    {
                        maxElfCalories = elfTotal;
                    }
                    elfTotal = 0;
                }
            }

            Console.WriteLine(maxElfCalories);
        }

        [Test]
        public void Part2()
        {
            var elfTotal = 0;
            var calories = 0;
            var elfCaloriesList = new List<int>();
            foreach (var foodItem in fileData)
            {
                if (int.TryParse(foodItem, out calories))
                {
                    elfTotal += calories;
                }
                else
                {
                    elfCaloriesList.Add(elfTotal);
                    elfTotal = 0;
                }
            }
            elfCaloriesList.Add(elfTotal);
            var sorted = elfCaloriesList.OrderByDescending(x => x).ToList();
            var maxElfCalories = sorted[0] + sorted[1] + sorted[2];
            Console.WriteLine(maxElfCalories);
        }
    }
}