using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day10
    {
        const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day10.txt";
        string text = System.IO.File.ReadAllText(PATH);

        public int Part1()
        {
            var textArray = text.Split("\r\n");
            var score = 0;

            foreach (var line in textArray)
            {
                List<char> expectedList = new List<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(') expectedList.Add(')');
                    else if (line[i] == '[') expectedList.Add(']');
                    else if (line[i] == '{') expectedList.Add('}');
                    else if (line[i] == '<') expectedList.Add('>');
                    else
                    {
                        if (line[i] != expectedList[expectedList.Count -1])
                        {
                            switch (line[i])
                            {
                                case ')':
                                    score += 3;
                                    break;
                                case ']':
                                    score += 57;
                                    break;
                                case '}':
                                    score += 1197;
                                    break;
                                case '>':
                                    score += 25137;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                        expectedList.RemoveAt(expectedList.Count - 1);
                    }
                }
            }

            return score;
        }

        public ulong Part2()
        {
            var textArray = text.Split("\r\n");
            List<ulong> scores = new List<ulong>();

            foreach (var line in textArray)
            {
                List<char> expectedList = new List<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(')
                    {
                        expectedList.Add(')');
                    }
                    else if (line[i] == '[')
                    {
                        expectedList.Add(']');
                    }
                    else if (line[i] == '{')
                    {
                        expectedList.Add('}');
                    }
                    else if (line[i] == '<')
                    {
                        expectedList.Add('>');
                    }
                    else
                    {
                        if (line[i] != expectedList[expectedList.Count - 1])
                        {
                            break;
                        }
                        expectedList.RemoveAt(expectedList.Count - 1);
                    }
                    if (i == line.Length - 1)
                    {
                        expectedList.Reverse();
                        scores.Add(CalculateScore(expectedList));
                    }
                }
            }

            var scoreArray = scores.ToArray();
            Array.Sort(scoreArray);
            return scoreArray[scoreArray.Length/2];
        }

        private ulong CalculateScore(List<char> charList)
        {
            ulong score = 0;
            for (int i = 0; i < charList.Count; i++)
            {
                score *= 5;
                switch (charList[i])
                {
                    case ')':
                        score += 1;
                        break;
                    case ']':
                        score += 2;
                        break;
                    case '}':
                        score += 3;
                        break;
                    case '>':
                        score += 4;
                        break;
                    default:
                        break;
                }
            }
            return score;
        }
    }
}
