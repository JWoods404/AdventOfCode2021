using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day4
    {
        public long Bingo()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day4.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            var numberList = textArray[0].Split(',');

            var BingoBoards = CreateBingoBoards(textArray);

            foreach (var number in numberList)
            {
                foreach (var bingoBoard in BingoBoards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoBoard[i, j] == number)
                            {
                                bingoBoard[i, j] = "b";
                                var tupleReturn = CheckForBingo(bingoBoard);
                                if (tupleReturn.Item1)
                                {
                                    return tupleReturn.Item2 * Convert.ToInt32(number);
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        public long LastBingo()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day4.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            var numberList = textArray[0].Split(',');

            var BingoBoards = CreateBingoBoards(textArray);
            string[,] lastBingoWinner = new string[5,5];
            int lastBingoWinnerNumber = 0;

            foreach (var number in numberList)
            {
                List<string[,]> tempList = new List<string[,]>();
                foreach (var bingoBoard in BingoBoards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoBoard[i, j] == number)
                            {
                                bingoBoard[i, j] = "b";
                                var tupleReturn = CheckForBingo(bingoBoard);
                                if (tupleReturn.Item1)
                                {
                                    for (int k = 0; k < 5; k++)
                                    {
                                        for (int l = 0; l < 5; l++)
                                        {
                                            lastBingoWinner[k, l] = bingoBoard[k, l];
                                        }
                                    }
                                    lastBingoWinnerNumber = Convert.ToInt32(number);
                                    tempList.Add(bingoBoard);
                                }
                            }
                        }
                    }
                }
                foreach (var item in tempList)
                {
                    BingoBoards.Remove(item);
                }
            }

            return(CheckForBingo(lastBingoWinner).Item2 * lastBingoWinnerNumber);
        }

        private List<string[,]> CreateBingoBoards(string[] array)
        {
            List<string[,]> bingoBoards = new List<string[,]>();

            for (int i = 2; i < array.Length; i += 6)
            {
                if (array[i] != "")
                {
                    string[,] bingoBoard = new string[5, 5];

                    for (int j = 0; j < 5; j++)
                    {
                        var rowWithEmptyStrings = array[i + j].Split(" ");
                        string[] row = new string[5];
                        int count = 0;
                        for (int k = 0; k < rowWithEmptyStrings.Length; k++)
                        {
                            if (rowWithEmptyStrings[k] == "")
                            {
                                continue;
                            }
                            else
                                row[count] = rowWithEmptyStrings[k];
                            count++;
                        }
                        for (int k = 0; k < 5; k++)
                        {
                            bingoBoard[j, k] = row[k];
                        }
                    }
                    bingoBoards.Add(bingoBoard);
                }
            }

            return bingoBoards;
        }

        private Tuple<bool, int> CheckForBingo(string[,] bingoBoard)
        {
            if ((bingoBoard[0, 0] == "b" && bingoBoard[0, 1] == "b" && bingoBoard[0, 2] == "b" && bingoBoard[0, 3] == "b" && bingoBoard[0, 4] == "b")
                || (bingoBoard[1, 0] == "b" && bingoBoard[1, 1] == "b" && bingoBoard[1, 2] == "b" && bingoBoard[1, 3] == "b" && bingoBoard[1, 4] == "b")
                || (bingoBoard[2, 0] == "b" && bingoBoard[2, 1] == "b" && bingoBoard[2, 2] == "b" && bingoBoard[2, 3] == "b" && bingoBoard[2, 4] == "b")
                || (bingoBoard[3, 0] == "b" && bingoBoard[3, 1] == "b" && bingoBoard[3, 2] == "b" && bingoBoard[3, 3] == "b" && bingoBoard[3, 4] == "b")
                || (bingoBoard[4, 0] == "b" && bingoBoard[4, 1] == "b" && bingoBoard[4, 2] == "b" && bingoBoard[4, 3] == "b" && bingoBoard[4, 4] == "b")
                || (bingoBoard[0, 0] == "b" && bingoBoard[1, 0] == "b" && bingoBoard[2, 0] == "b" && bingoBoard[3, 0] == "b" && bingoBoard[4, 0] == "b")
                || (bingoBoard[0, 1] == "b" && bingoBoard[1, 1] == "b" && bingoBoard[2, 1] == "b" && bingoBoard[3, 1] == "b" && bingoBoard[4, 1] == "b")
                || (bingoBoard[0, 2] == "b" && bingoBoard[1, 2] == "b" && bingoBoard[2, 2] == "b" && bingoBoard[3, 2] == "b" && bingoBoard[4, 2] == "b")
                || (bingoBoard[0, 3] == "b" && bingoBoard[1, 3] == "b" && bingoBoard[2, 3] == "b" && bingoBoard[3, 3] == "b" && bingoBoard[4, 3] == "b")
                || (bingoBoard[0, 4] == "b" && bingoBoard[1, 4] == "b" && bingoBoard[2, 4] == "b" && bingoBoard[3, 4] == "b" && bingoBoard[4, 4] == "b"))
            {
                var count = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (bingoBoard[i,j] != "b")
                        {
                            count += int.Parse(bingoBoard[i, j]);
                        }
                    }
                }
                return Tuple.Create(true, count);
            }
            return Tuple.Create(false, 0);
        }
    }
}
