using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day11
    {
        // const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\test.txt";  // for testing the example data
        const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day11.txt";
        string text = System.IO.File.ReadAllText(PATH);
        int flashes = 0;

        public int Part1()
        {
            var lineArray = text.Split("\r\n");
            int[,] octopi = new int[10, 10];
            for (int i = 0; i < lineArray.Length; i++)
            {
                for (int j = 0; j < lineArray[0].Length; j++)
                {
                    octopi[i, j] = Convert.ToInt32(new string(lineArray[i][j],1));
                }
            }

            for (int x = 0; x < 100; x++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        octopi[i, j] = AddOne(octopi[i, j]);
                    }
                }

                while (IsStill10s(octopi))
                {
                    octopi = UpdateGrid(octopi);
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (octopi[i, j] > 9)
                        {
                            octopi[i, j] = 0;
                            flashes++;
                        }
                    }
                }
            }

            return flashes;
        }

        public int Part2()
        {
            var lineArray = text.Split("\r\n");
            int[,] octopi = new int[10, 10];
            for (int i = 0; i < lineArray.Length; i++)
            {
                for (int j = 0; j < lineArray[0].Length; j++)
                {
                    octopi[i, j] = Convert.ToInt32(new string(lineArray[i][j], 1));
                }
            }

            for (int x = 0; x < 500; x++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        octopi[i, j] = AddOne(octopi[i, j]);
                    }
                }

                while (IsStill10s(octopi))
                {
                    octopi = UpdateGrid(octopi);
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (octopi[i, j] > 9)
                        {
                            octopi[i, j] = 0;
                        }
                    }
                }

                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (octopi[i, j] == 0)
                        {
                            count++;
                        }
                    }
                }
                if (count == 100) return x+1;
            }

            return 0;
        }

        private int[,] UpdateGrid(int[,] octopi)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (octopi[i,j] == 10)
                    {
                        octopi[i, j] = 11;
                        if (i != 0)
                        {
                            if (j != 0)
                            {
                                octopi[i - 1, j - 1] = AddOne(octopi[i - 1, j - 1]);
                            }
                            octopi[i - 1, j] = AddOne(octopi[i - 1, j]);
                            if (j != 9)
                            {
                                octopi[i - 1, j + 1] = AddOne(octopi[i - 1, j + 1]);
                            }
                        }
                        if (j != 0)
                        {
                            octopi[i, j - 1] = AddOne(octopi[i, j - 1]);
                        }
                        if (j != 9)
                        {
                            octopi[i, j + 1] = AddOne(octopi[i, j + 1]);
                        }
                        if (i != 9)
                        {
                            if (j != 0)
                            {
                                octopi[i + 1, j - 1] = AddOne(octopi[i + 1, j - 1]);
                            }
                            octopi[i + 1, j] = AddOne(octopi[i + 1, j]);
                            if (j != 9)
                            {
                                octopi[i + 1, j + 1] = AddOne(octopi[i + 1, j + 1]);
                            }
                        }
                    }
                }
            }

            return octopi;
        }

        private bool IsStill10s(int[,] octopi)
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (octopi[i, j] == 10) count++;
                }
            }
            if (count > 0) return true;
            return false;
        }

        public int AddOne(int x)
        {
            //if (x == 0) return 0;
            if (x == 10) return 10;
            return x + 1;
        }
    }
}
