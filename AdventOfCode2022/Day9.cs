using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    public class Day9
    {
        public static string[] fileData;
        public class Location : IEquatable<Location>
        {
            public int X { get; set; } = 0;
            public int Y { get; set; } = 0;

            public bool Equals(Location? other)
            {
                return this.X == other.X && this.Y == other.Y;
            }
        }

        [SetUp]
        public void Setup()
        {
            fileData = Utilities.InputLoader.LoadFile("Data/Day9.txt");
        }

        [Test]
        public void Part1()
        {
            var head = new Location();
            var tail = new Location();
            var tailLocations = new List<Location>();
            tailLocations.Add(new Location { X = tail.X, Y = tail.Y });
            foreach (var motion in fileData)
            {
                var move = motion.Split(' ');
                var direction = move[0];
                var steps = int.Parse(move[1]);
                for (int i = 0; i < steps; i++)
                {
                    PerformMove(head, tail, direction[0]);
                    if (!tailLocations.Contains(tail))
                    {
                        tailLocations.Add(new Location { X = tail.X, Y = tail.Y });
                    }
                }
            }
            Console.WriteLine(tailLocations.Count);
        }

        [Test]
        public void Part2()
        {
            var head = new Location();
            var knots = new List<Location>();
            for(int i = 0; i < 9; i++)
            {
                knots.Add(new Location());
            }
            var tailLocations = new List<Location>();
            tailLocations.Add(new Location { X = knots[8].X, Y = knots[8].Y });
            foreach (var motion in fileData)
            {
                var move = motion.Split(' ');
                var direction = move[0];
                var steps = int.Parse(move[1]);
                for (int i = 0; i < steps; i++)
                {
                    PerformMoveLong(head, knots, direction[0]);
                    if (!tailLocations.Contains(knots[8]))
                    {
                        tailLocations.Add(new Location { X = knots[8].X, Y = knots[8].Y });
                    }
                }
            }
            Console.WriteLine(tailLocations.Count);
        }

        public void PerformMove(Location head, Location tail, char direction)
        {
            //Move head
            switch (direction)
            {
                case 'U':
                    head.Y++;
                    break;
                case 'D':
                    head.Y--;
                    break;
                case 'R':
                    head.X++;
                    break;
                case 'L':
                    head.X--;
                    break;
            }
            //move tail
            var xDiff = head.X - tail.X;
            var yDiff = head.Y - tail.Y;
            var distance = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
            if (Math.Abs(xDiff) == Math.Abs(yDiff)) return;
            if (distance > 1)
            {
                if (xDiff != 0)
                {
                    tail.X += (xDiff > 0) ? 1 : -1;
                }
                if (yDiff != 0)
                {
                    tail.Y += (yDiff > 0) ? 1 : -1;
                }
            }
        }
        public void PerformMoveLong(Location head, List<Location> knots, char direction)
        {
            //Move head
            switch (direction)
            {
                case 'U':
                    head.Y++;
                    break;
                case 'D':
                    head.Y--;
                    break;
                case 'R':
                    head.X++;
                    break;
                case 'L':
                    head.X--;
                    break;
            }
            //move tail
            var previousKnot = head;

            foreach(var knot in knots)
            {
                var xDiff = previousKnot.X - knot.X;
                var yDiff = previousKnot.Y - knot.Y;

                var distance = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
                if (Math.Abs(xDiff) == 1 && Math.Abs(yDiff) == 1)
                {
                    previousKnot = knot;
                    continue;
                }
                if (distance > 1)
                {
                    if (xDiff != 0)
                    {
                        knot.X += (xDiff > 0) ? 1 : -1;
                    }
                    if (yDiff != 0)
                    {
                        knot.Y += (yDiff > 0) ? 1 : -1;
                    }
                }

                previousKnot = knot;
            }
        }
    }
}
