using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day9
    {
        const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day9.txt";
        string text = System.IO.File.ReadAllText(PATH);
        int[,] dataArray = new int[100, 100];

        public int Part1()
        {
            var stringLine = text.Split("\r\n");

            int k = 0;
            foreach (var line in stringLine)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    dataArray[k, i] = Convert.ToInt32(new string(line[i], 1));
                }
                k++;
            }

            List<int> lowPoints = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    bool rightGreater = true, leftGreater = true, upGreater = true, downGreater = true;
                    if (i != 0)
                    {
                        upGreater = IsItGreater(dataArray[i, j], dataArray[i - 1, j]);
                    }
                    if (i != 99)
                    {
                        downGreater = IsItGreater(dataArray[i, j], dataArray[i + 1, j]);
                    }
                    if (j != 0)
                    {
                        leftGreater = IsItGreater(dataArray[i, j], dataArray[i, j - 1]);
                    }
                    if (j != 99)
                    {
                        rightGreater = IsItGreater(dataArray[i, j], dataArray[i, j + 1]);
                    }
                    if (upGreater && downGreater && rightGreater && leftGreater)
                    {
                        lowPoints.Add(dataArray[i, j] + 1);
                    }
                }
            }

            return lowPoints.Sum();
        }

        private bool IsItGreater(int value, int comparedValue)
        {
            if (value < comparedValue) return true;
            return false;
        }

        public int Part2()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Basin workingBasin = null;
                    foreach (var basin in basins)
                    {
                        if (basin.Positions.Contains(new Position(i,j)))
                        {
                            workingBasin = basin;
                        }
                    }
                    if (dataArray[i,j] != 9)
                    {
                        foreach (var basin in basins)
                        {
                            if (basin.Positions.Contains(new Position(i, j + 1)))
                            {
                                workingBasin = basin;
                                workingBasin.AddPosition(new Position(i, j));
                            }
                        }
                        foreach (var basin in basins)
                        {
                            if (basin.Positions.Contains(new Position(i -1, j)))
                            {
                                workingBasin = basin;
                                workingBasin.AddPosition(new Position(i, j));
                            }
                        }
                        if (workingBasin == null)
                        {
                            workingBasin = new Basin();
                            workingBasin.Positions.Add(new Position(i, j));
                            basins.Add(workingBasin);
                        }
                        GoUp(i, j, workingBasin);
                        GoDown(i, j, workingBasin);
                        GoLeft(i, j, workingBasin);
                        GoRight(i, j, workingBasin);
                    }
                }
            }

            List<int> basinSizes = new List<int>();
            foreach (var basin in basins)
            {
                basinSizes.Add(basin.Positions.Count);
            }

            var basinsizesArray = basinSizes.ToArray();

            Array.Sort(basinsizesArray);
            Array.Reverse(basinsizesArray);

            return basinsizesArray[0] * basinsizesArray[1] * basinsizesArray[2];
        }

        List<Basin> basins = new List<Basin>();

        class Basin
        {
            public List<Position> Positions { get; set; } = new List<Position>();

            public void AddPosition(Position position)
            {
                if (!Positions.Contains(position)) Positions.Add(position);
            }
        }

        struct Position
        {
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

        private void GoUp(int i, int j, Basin basin)
        {
            if (i == 0) return;
            if (dataArray[i - 1, j] == 9) return;
            basin.AddPosition(new Position(i - 1, j));
            GoUp(i - 1, j, basin);
        }

        private void GoDown(int i, int j, Basin basin)
        {
            if (i == 99) return;
            if (dataArray[i + 1, j] == 9) return;
            basin.AddPosition(new Position(i + 1, j));
            GoDown(i + 1, j, basin);
        }

        private void GoLeft(int i, int j, Basin basin)
        {
            if (j == 0) return;
            if (dataArray[i, j - 1] == 9) return;
            basin.AddPosition(new Position(i, j - 1));
            GoLeft(i, j - 1, basin);
        }

        private void GoRight(int i, int j, Basin basin)
        {
            if (j == 99) return;
            if (dataArray[i, j + 1] == 9) return;
            basin.AddPosition(new Position(i, j + 1));
            GoRight(i, j + 1, basin);
        }
    }
}
