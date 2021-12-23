using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Day5
    {
        public long IntersectingPoints()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day5.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            var lines = GetVerticalAndHorizontalLines(textArray);

            List<Position> allPositions = new List<Position>();
            for (int i = 0; i < lines.Count; i += 2)
            {
                if (lines[i].X == lines[i + 1].X)
                {
                    if (lines[i].Y > lines[i + 1].Y)
                    {
                        int temp = lines[i + 1].Y;
                        while (temp <= lines[i].Y)
                        {
                            Position position = new Position(lines[i].X, temp);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                    else
                    {
                        int temp = lines[i].Y;
                        while (temp <= lines[i + 1].Y)
                        {
                            Position position = new Position(lines[i].X, temp);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                }
                if (lines[i].Y == lines[i + 1].Y)
                {
                    if (lines[i].X > lines[i + 1].X)
                    {
                        int temp = lines[i + 1].X;
                        while (temp <= lines[i].X)
                        {
                            Position position = new Position(temp, lines[i].Y);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                    if (lines[i].X < lines[i + 1].X)
                    {
                        int temp = lines[i].X;
                        while (temp <= lines[i + 1].X)
                        {
                            Position position = new Position(temp, lines[i].Y);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                }
            }

            List<Position> allMatches = new List<Position>();
            for (int i = 0; i < allPositions.Count - 1; i++)
            {
                for (int j = i + 1; j < allPositions.Count - 2; j++)
                {
                    if (allPositions[i].X == allPositions[j].X && allPositions[i].Y == allPositions[j].Y)
                    {
                        if (!allMatches.Contains(allPositions[i]))
                        {
                            allMatches.Add(allPositions[i]);
                        }
                        continue;
                    }
                }
            }

            return allMatches.Count;
        }

        public long IntersectingPointsWithDiagonals()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day5.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            var lines = GetVerticalAndHorizontalAndDiagonalLines(textArray);

            List<Position> allPositions = new List<Position>();
            for (int i = 0; i < lines.Count; i += 2)
            {
                if (lines[i].X == lines[i + 1].X)
                {
                    if (lines[i].Y > lines[i + 1].Y)
                    {
                        int temp = lines[i + 1].Y;
                        while (temp <= lines[i].Y)
                        {
                            Position position = new Position(lines[i].X, temp);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                    else
                    {
                        int temp = lines[i].Y;
                        while (temp <= lines[i + 1].Y)
                        {
                            Position position = new Position(lines[i].X, temp);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                }
                else if (lines[i].Y == lines[i + 1].Y)
                {
                    if (lines[i].X > lines[i + 1].X)
                    {
                        int temp = lines[i + 1].X;
                        while (temp <= lines[i].X)
                        {
                            Position position = new Position(temp, lines[i].Y);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                    if (lines[i].X < lines[i + 1].X)
                    {
                        int temp = lines[i].X;
                        while (temp <= lines[i + 1].X)
                        {
                            Position position = new Position(temp, lines[i].Y);
                            allPositions.Add(position);
                            temp++;
                        }
                    }
                }
                else
                {
                    int numberOfPositionsToAdd = Math.Abs(lines[i].X - lines[i + 1].X) + 1;
                    int temp = 0;
                    if (lines[i].X > lines[i + 1].X)
                    {
                        if (lines[i].Y > lines[i + 1].Y)
                        {
                            while (temp < numberOfPositionsToAdd)
                            {
                                Position position = new Position(lines[i].X - temp, lines[i].Y - temp);
                                allPositions.Add(position);
                                temp++;
                            }
                        }
                        if (lines[i].Y < lines[i + 1].Y)
                        {
                            while (temp < numberOfPositionsToAdd)
                            {
                                Position position = new Position(lines[i].X - temp, lines[i].Y + temp);
                                allPositions.Add(position);
                                temp++;
                            }
                        }
                    }
                    if (lines[i].X < lines[i + 1].X)
                    {
                        if (lines[i].Y > lines[i + 1].Y)
                        {
                            while (temp < numberOfPositionsToAdd)
                            {
                                Position position = new Position(lines[i].X + temp, lines[i].Y - temp);
                                allPositions.Add(position);
                                temp++;
                            }
                        }
                        if (lines[i].Y < lines[i + 1].Y)
                        {
                            while (temp < numberOfPositionsToAdd)
                            {
                                Position position = new Position(lines[i].X + temp, lines[i].Y + temp);
                                allPositions.Add(position);
                                temp++;
                            }
                        }
                    }
                }
            }

            List<Position> allMatches = new List<Position>();
            for (int i = 0; i < allPositions.Count - 1; i++)
            {
                for (int j = i + 1; j < allPositions.Count - 1; j++)
                {
                    if (allPositions[i].X == allPositions[j].X && allPositions[i].Y == allPositions[j].Y)
                    {
                        if (!allMatches.Contains(allPositions[i]))
                        {
                            allMatches.Add(allPositions[i]);
                        }
                        continue;
                    }
                }
            }

            return allMatches.Count;
        }

        private List<Position> GetVerticalAndHorizontalLines(string[] array)
        {
            List<Position> positionList = new List<Position>();
            foreach (var line in array)
            {
                var removeArrowAndSpace = line.Split(" -> ");
                foreach (var item in removeArrowAndSpace)
                {
                    var positionArray = item.Split(",");
                    Position position = new Position(Convert.ToInt32(positionArray[0]), Convert.ToInt32(positionArray[1]));
                    positionList.Add(position);
                }
            }

            List<Position> horizontalAndVerticalPositions = new List<Position>();
            for (int i = 0; i < positionList.Count - 1; i += 2)
            {
                if (positionList[i].X == positionList[i + 1].X || positionList[i].Y == positionList[i + 1].Y)
                {
                    horizontalAndVerticalPositions.Add(positionList[i]);
                    horizontalAndVerticalPositions.Add(positionList[i + 1]);
                }
            }

            return horizontalAndVerticalPositions;
        }

        private List<Position> GetVerticalAndHorizontalAndDiagonalLines(string[] array)
        {
            List<Position> positionList = new List<Position>();
            foreach (var line in array)
            {
                var removeArrowAndSpace = line.Split(" -> ");
                foreach (var item in removeArrowAndSpace)
                {
                    var positionArray = item.Split(",");
                    Position position = new Position(Convert.ToInt32(positionArray[0]), Convert.ToInt32(positionArray[1]));
                    positionList.Add(position);
                }
            }

            List<Position> horizontalAndVerticalAndDiagonalPositions = new List<Position>();
            for (int i = 0; i < positionList.Count - 1; i += 2)
            {
                if (positionList[i].X == positionList[i + 1].X || positionList[i].Y == positionList[i + 1].Y)
                {
                    horizontalAndVerticalAndDiagonalPositions.Add(positionList[i]);
                    horizontalAndVerticalAndDiagonalPositions.Add(positionList[i + 1]);
                }
                if (Math.Abs(positionList[i].X - positionList[i +1].X) == Math.Abs(positionList[i].Y - positionList[i + 1].Y))
                {
                    horizontalAndVerticalAndDiagonalPositions.Add(positionList[i]);
                    horizontalAndVerticalAndDiagonalPositions.Add(positionList[i + 1]);
                }
            }

            return horizontalAndVerticalAndDiagonalPositions;
        }
    }
}
