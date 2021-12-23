using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Lanternfish
    {
        public int DaysToSpawn { get; set; }

        public Lanternfish(int daysToSpawn)
        {
            DaysToSpawn = daysToSpawn;
        }
    }

    class Day6
    {
        public long LanternfishAfter80Days(int days)
        {
            List<Lanternfish> lanternfishies = new List<Lanternfish>();

            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day6.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split(",");

            // Initial State:
            foreach (var lanternfishDaysBeforeSpawn in textArray)
            {
                lanternfishies.Add(new Lanternfish(Convert.ToInt32(lanternfishDaysBeforeSpawn)));
            }

            // Days 1-80:

            for (int i = 0; i < days; i++)
            {
                List<Lanternfish> tempList = new List<Lanternfish>();
                foreach (var lanternfish in lanternfishies)
                {
                    lanternfish.DaysToSpawn--;
                    if (lanternfish.DaysToSpawn == -1)
                    {
                        lanternfish.DaysToSpawn = 6;
                        tempList.Add(new Lanternfish(8));
                    }
                }

                foreach (var lanternfish in tempList)
                {
                    lanternfishies.Add(lanternfish);
                } 
            }


            return lanternfishies.Count;
        }

        // from https://github.com/encse/adventofcode/blob/master/2021/Day06/Solution.cs
        public long FishCountAfterNDays(int days)
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day6.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split(",");

            // group the fish by their timer, no need to deal with them one by one:
            var fishCountByInternalTimer = new long[9];
            foreach (var ch in textArray)
            {
                fishCountByInternalTimer[int.Parse(ch)]++;
            }

            // we will model a circular shift register, with an additional feedback:
            //       0123456           78 
            //   ┌──[.......]─<─(+)───[..]──┐
            //   └──────>────────┴─────>────┘
            //     reproduction     newborn

            for (var t = 0; t < days; t++)
            {
                fishCountByInternalTimer[(t + 7) % 9] += fishCountByInternalTimer[t % 9];
            }

            return fishCountByInternalTimer.Sum();
        }
    }
}
