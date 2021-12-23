using System;

namespace AdventOfCode2021
{
    class Day1
    {
        string[] textArray;

        public int NumberOfIncreases()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day1_1.txt";

            string text = System.IO.File.ReadAllText(PATH);

            textArray = text.Split("\r\n");

            int count = 0;
            // First element does not count
            for (int i = 1; i < textArray.Length; i++)
            {
                if (Int32.Parse(textArray[i]) > Int32.Parse(textArray[i - 1]))
                    count++;
            }

            return count;
        }

        public int BlocksOfThree()
        {
            int count = 0;

            for (int i = 0; i < textArray.Length-3; i++)
            {
                if ((Int32.Parse(textArray[i]) + Int32.Parse(textArray[i + 1]) + Int32.Parse(textArray[i + 2])) <
                    (Int32.Parse(textArray[i + 1]) + Int32.Parse(textArray[i + 2]) + Int32.Parse(textArray[i + 3])))
                    count++;
            }

            return count;
        }
    }
}
