using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day3
    {
        public long PowerConsumption()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day3_1.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n");

            int gammaRate = 0, epsilonRate = 0;
            string gammaBits = "", epsilonBits = "";
            for (int i = 0; i < 12; i++)
            {
                int zeroBit = 0, oneBit = 0;
                for (int j = 0; j < textArray.Length; j++)
                {
                    if (textArray[j][i].ToString() == "0")
                        zeroBit++;
                    else
                        oneBit++;
                }
                if (zeroBit > oneBit)
                {
                    gammaBits += "0";
                    epsilonBits += "1";
                }
                else
                {
                    gammaBits += "1";
                    epsilonBits += "0";
                }
            }

            gammaRate = Convert.ToInt32(gammaBits, 2);
            epsilonRate = Convert.ToInt32(epsilonBits, 2);

            return gammaRate * epsilonRate;
        }

        public long LifeSupportRating()
        {
            const string PATH = "C:\\Users\\User\\OneDrive\\Documents\\AdventOfCode2021_Day3_1.txt";

            string text = System.IO.File.ReadAllText(PATH);

            var textArray = text.Split("\r\n").ToList();

            List<string> textArray2 = new List<string>();

            foreach (var item in textArray)
            {
                textArray2.Add(item);
            }

            string oxygenGeneratorRatingString = "", co2ScrubberRatingString = "";
            long oxygenGeneratorRating = 0, co2ScrubberRating = 0;

            while (textArray.Count != 1)
            {
                for (int i = 0; i < 12; i++)
                {
                    int zeroBit = 0, oneBit = 0;
                    for (int j = 0; j < textArray.Count; j++)
                    {
                        if (textArray[j][i].ToString() == "0")
                            zeroBit++;
                        else
                            oneBit++;
                    }
                    List<string> temp = new List<string>();
                    foreach (var item in textArray)
                    {
                        temp.Add(item);
                    }
                    if (zeroBit > oneBit)
                    {
                        foreach (var number in temp)
                        {
                            if (number[i] == '1')
                                textArray.Remove(number);
                        }
                    }
                    else
                    {
                        foreach (var number in temp)
                        {
                            if (number[i] == '0')
                                textArray.Remove(number);
                        }
                    }
                }
            }

            while (textArray2.Count != 1)
            {
                for (int i = 0; i < 12; i++)
                {
                    int zeroBit = 0, oneBit = 0;
                    for (int j = 0; j < textArray2.Count; j++)
                    {
                        if (textArray2[j][i].ToString() == "0")
                            zeroBit++;
                        else
                            oneBit++;
                    }
                    List<string> temp = new List<string>();
                    foreach (var item in textArray2)
                    {
                        temp.Add(item);
                    }
                    if (zeroBit <= oneBit)
                    {
                        foreach (var number in temp)
                        {
                            if (number[i] == '1')
                                textArray2.Remove(number);
                        }
                    }
                    else
                    {
                        foreach (var number in temp)
                        {
                            if (number[i] == '0')
                                textArray2.Remove(number);
                        }
                    }
                    if (textArray2.Count == 1)
                        break;
                }
            }

            oxygenGeneratorRating = Convert.ToInt32(textArray[0].ToString(), 2);
            co2ScrubberRating = Convert.ToInt32(textArray2[0].ToString(), 2);


            return oxygenGeneratorRating * co2ScrubberRating;
        }
    }
}
