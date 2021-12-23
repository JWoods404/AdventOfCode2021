using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day8
    {
        public int NumberOfRecognizableNumbers()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day8.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var arrayText = text.Split("\r\n");

            var list = arrayText.ToList();

            List<string> test = new List<string>();
            foreach (var item in list)
            {
                test.Add(item.Split(" | ")[1]);
            }

            List<string[]> listForCount = new List<string[]>();
            foreach (var item in test)
            {
                listForCount.Add(item.Split(" "));
            }

            int count = 0;

            foreach (var item in listForCount)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (item[i].Length == 2 || item[i].Length == 3 || item[i].Length == 4 || item[i].Length == 7) count++;
                }
            }

            return count;
        }

        public int AllNumbers()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day8.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var arrayText = text.Split("\r\n");

            var list = arrayText.ToList();

            List<string> forBeforeDelimiter = new List<string>();
            List<string> forAfterDelimiter = new List<string>();
            foreach (var item in list)
            {
                forBeforeDelimiter.Add(item.Split(" | ")[0]);
                forAfterDelimiter.Add(item.Split(" | ")[1]);
            }

            List<string[]> listBeforeDelimiter = new List<string[]>();
            foreach (var item in forBeforeDelimiter)
            {
                listBeforeDelimiter.Add(item.Split(" "));
            }

            List<string[]> listAfterDelimiter = new List<string[]>();
            foreach (var item in forAfterDelimiter)
            {
                listAfterDelimiter.Add(item.Split(" "));
            }

            List<int> numbers = new List<int>();

            for (int i = 0; i < listBeforeDelimiter.Count; i++)
            {
                var one = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 2).ToArray();
                Array.Sort(one);
                var seven = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 3).ToArray();
                Array.Sort(seven);
                var four = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 4).ToArray();
                Array.Sort(four);
                var eight = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 7).ToArray();
                Array.Sort(eight);
                var nine = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 6 && x.Contains(four[0]) && x.Contains(four[1])
                    && x.Contains(four[2]) && x.Contains(four[3])).ToArray();
                Array.Sort(nine);
                var zero = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 6 && !CheckEquality(x.ToArray(), nine) && x.Contains(seven[0])
                    && x.Contains(seven[1]) && x.Contains(seven[2])).ToArray();
                Array.Sort(zero);
                var six = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 6 && !CheckEquality(x.ToArray(), nine) && !CheckEquality(x.ToArray(), zero)).ToArray();
                Array.Sort(six);
                var three = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 5 && x.Contains(seven[0])
                    && x.Contains(seven[1]) && x.Contains(seven[2])).ToArray();
                Array.Sort(three);
                var five = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 5 && CheckCount(x.ToArray(), six) == 5).ToArray();
                Array.Sort(five);
                var two = listBeforeDelimiter[i].FirstOrDefault(x => x.Length == 5 && CheckCount(x.ToArray(), nine) == 4).ToArray();
                Array.Sort(two);

                var digitString = "";

                foreach (var digit in listAfterDelimiter[i])
                {
                    var number = digit.ToArray();
                    Array.Sort(number);
                    if (CheckEquality(number, zero)) digitString += "0";
                    else if (CheckEquality(number, one)) digitString += "1";
                    else if (CheckEquality(number, two)) digitString += "2";
                    else if (CheckEquality(number, three)) digitString += "3";
                    else if (CheckEquality(number, four)) digitString += "4";
                    else if (CheckEquality(number, five)) digitString += "5";
                    else if (CheckEquality(number, six)) digitString += "6";
                    else if (CheckEquality(number, seven)) digitString += "7";
                    else if (CheckEquality(number, eight)) digitString += "8";
                    else if (CheckEquality(number, nine)) digitString += "9";
                }

                numbers.Add(Convert.ToInt32(digitString));
            }

            return numbers.Sum();
        }

        private bool CheckEquality(char[] a, char[] b)
        {
            Array.Sort(a);
            if (a.SequenceEqual(b)) return true;
            return false;
        }

        private int CheckCount(char[] a, char[] b)
        {
            int count = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (a.Contains(b[i])) count++;
            }
            return count;
        }
    }
}
