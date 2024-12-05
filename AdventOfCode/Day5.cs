using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day5 {
        public static void Start(string puzzleInput)
        {
            string puzzlePart1 = puzzleInput.Split("\r\n\r\n")[0];
            string puzzlePart2 = puzzleInput.Split("\r\n\r\n")[1];

            var part1Lines = puzzlePart1.Split("\r\n");
            var part2Lines = puzzlePart2.Split("\r\n");

            var correctPart2Lines = 0;

            List<string> correctPart2LinesList = new List<string>();

            for (int i = 0; i < part2Lines.Count(); i++)
            {
                bool part2LineIsCorrect = false;
                bool part2LineIsNotCorrect = false;
                for (int j = 0; j < part1Lines.Count(); j++)
                {
                    var part1NumPairs = part1Lines[j].Split("|");

                    if (part2Lines[i].Contains(part1NumPairs[0]) && part2Lines[i].Contains(part1NumPairs[1]))
                    {
                        if (part2Lines[i].IndexOf(part1NumPairs[0]) < part2Lines[i].IndexOf(part1NumPairs[1]))
                        {
                            part2LineIsCorrect = true;
                        }
                        else { part2LineIsNotCorrect = true; break; }
                    }
                }
                if (!part2LineIsNotCorrect) {
                    if (part2LineIsCorrect)
                    {
                        correctPart2Lines++;
                        correctPart2LinesList.Add(part2Lines[i]);
                    }
                }
            }
            Console.WriteLine(correctPart2Lines);

            foreach (string line in correctPart2LinesList) { Console.WriteLine(line); }

            var part1FinalSummary = 0;
            for (int i = 0; i < correctPart2LinesList.Count; i++) { 
                var correctPart2LineArrayed = correctPart2LinesList[i].Split(",");

                var middleNumberIndex = correctPart2LineArrayed.Count() / 2;

                var correctPart2LineMiddleNumber = correctPart2LineArrayed[middleNumberIndex];

                part1FinalSummary += int.Parse(correctPart2LineMiddleNumber);
            }
            Console.WriteLine(part1FinalSummary);
        }
    }
}
