using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day12
    {
        const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day12.txt";
        string text = System.IO.File.ReadAllText(PATH);
        List<Cave> caves = new List<Cave>();
        List<string> paths = new List<string>();

        public int Part1()
        {
            var lineArray = text.Split("\r\n");
            List<string> lineList = new List<string>();

            foreach (var line in lineArray)
            {
                var splitMe = line.Split("-");
                lineList.Add(splitMe[0]);
                lineList.Add(splitMe[1]);
            }

            foreach (var cave in lineList)
            {
                if (caves.FirstOrDefault(c => c.Name == cave) == null)
                {
                    if (cave.Any(char.IsUpper))
                    {
                        BigCave bigCave = new BigCave(cave);
                        caves.Add(bigCave);
                    }
                    else
                    {
                        SmallCave smallCave = new SmallCave(cave);
                        caves.Add(smallCave);
                    }
                }
            }

            for (int i = 0; i < lineList.Count; i++)
            {
                var cave = caves.FirstOrDefault(c => c.Name == lineList[i]);
                if (i % 2 == 0) cave.Connections.Add(lineList[i + 1]);
                else cave.Connections.Add(lineList[i - 1]);
            }

            var start = caves.FirstOrDefault(c => c.Name == "start");
            string path = "start";
            foreach (var connection in start.Connections)
            {
                var nextCave = caves.First(c => c.Name == connection);
                GoNextStep(nextCave, path);
            }

            return paths.Count;
        }

        public int Part2()
        {
            paths.Clear();
            var start = caves.FirstOrDefault(c => c.Name == "start");
            string path = "start";
            bool isRepeatUsedUp = false;
            foreach (var connection in start.Connections)
            {
                var nextCave = caves.First(c => c.Name == connection);
                GoNextStep(nextCave, path, isRepeatUsedUp);
            }

            return paths.Count;
        }

        private string GoNextStep(Cave cave, string path, bool isRepeatUsedUp)
        {
            if (cave is SmallCave)
            {
                if (cave.Name == "end")
                {
                    path += "->" + cave.Name;
                    paths.Add(path);
                    return path;
                }
                if ((path.Contains(cave.Name) && isRepeatUsedUp) || cave.Name == "start")
                {
                    return null;
                }
                if ((path.Contains(cave.Name) && !isRepeatUsedUp) && cave.Name != "start" && cave.Name != "end")
                {
                    isRepeatUsedUp = true;
                }
            }
            path += "->" + cave.Name;
            foreach (var connection in cave.Connections)
            {
                var nextCave = caves.FirstOrDefault(c => c.Name == connection);
                GoNextStep(nextCave, path, isRepeatUsedUp);
            }
            return path;
        }

        private string GoNextStep(Cave cave, string path)
        {
            if (cave is SmallCave)
            {
                if (path.Contains(cave.Name)) return null;
            }
            path += "->" + cave.Name;
            if (cave.Name == "end")
            {
                paths.Add(path);
                return path;
            }
            foreach (var connection in cave.Connections)
            {
                var nextCave = caves.FirstOrDefault(c => c.Name == connection);
                GoNextStep(nextCave, path);
            }
            return path;
        }

        public class Cave
        {
            public string Name { get; set; }
            public List<string> Connections { get; set; }

            public Cave(string name)
            {
                Name = name;
                Connections = new List<string>();
            }
        }

        public class BigCave : Cave
        {
            public BigCave(string name) : base(name)
            {

            }
        }

        public class SmallCave : Cave
        {
            public SmallCave(string name) : base(name)
            {

            }
        }

    }
}
