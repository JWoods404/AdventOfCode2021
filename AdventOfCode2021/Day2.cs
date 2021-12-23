using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day2
    {
        public Tuple<int,int,int> Position()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day2_1.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            int horizontalPosition = 0, depth = 0;
            for (int i = 0; i < textArray.Length; i++)
            {
                var splitTextArray = textArray[i].Split(' ');
                if (splitTextArray[0] == "forward")
                    horizontalPosition += Int32.Parse(splitTextArray[1]);
                else if (splitTextArray[0] == "up")
                    depth -= Int32.Parse(splitTextArray[1]);
                else if (splitTextArray[0] == "down")
                    depth += Int32.Parse(splitTextArray[1]);
            }

            return Tuple.Create(horizontalPosition, depth, horizontalPosition * depth);
        }

        public Tuple<long, long, long> PositionWithAim()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day2_1.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            long horizontalPosition = 0, depth = 0, aim = 0;
            for (int i = 0; i < textArray.Length; i++)
            {
                var splitTextArray = textArray[i].Split(' ');
                if (splitTextArray[0] == "forward")
                {
                    horizontalPosition += Int32.Parse(splitTextArray[1]);
                    depth += (aim * Int32.Parse(splitTextArray[1]));
                }
                else if (splitTextArray[0] == "up")
                    aim -= Int32.Parse(splitTextArray[1]);
                else if (splitTextArray[0] == "down")
                    aim += Int32.Parse(splitTextArray[1]);
            }

            return Tuple.Create(horizontalPosition, depth, horizontalPosition * depth);
        }
    }
}
