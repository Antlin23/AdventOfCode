using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day5 {
        public static void Start(string puzzleInput) 
        {
            //Part 1: 143
            //Part 2: 5169
            string puzzlePart1 = puzzleInput.Split("\r\n\r\n")[0];
            string puzzlePart2 = puzzleInput.Split("\r\n\r\n")[1];

            var part1Lines = puzzlePart1.Split("\r\n");
            var part2Lines = puzzlePart2.Split("\r\n");

            List<string> correctPart2LinesList = new List<string>();
            List<string> incorrectPart2LinesList = new List<string>();

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
                        else { part2LineIsNotCorrect = true; incorrectPart2LinesList.Add(part2Lines[i]); break; }
                    }
                }
                if (!part2LineIsNotCorrect) {
                    if (part2LineIsCorrect)
                    {
                        correctPart2LinesList.Add(part2Lines[i]);
                    }
                }
            }

            //Part 2 ------------
            List<string> recorrectPart2LinesList = new List<string>();
            while (incorrectPart2LinesList.Count > 0) {
                for (int i = 0; i < incorrectPart2LinesList.Count(); i++)
                {
                    bool part2LineIsCorrect = false;

                    //might wanna make dynamic
                    for (int k = 0; k < 3; k++)
                    {
                        for (int j = 0; j < part1Lines.Count(); j++)
                        {
                            var part1NumPairs = part1Lines[j].Split("|");

                            if (incorrectPart2LinesList[i].Contains(part1NumPairs[0]) && incorrectPart2LinesList[i].Contains(part1NumPairs[1]))
                            {
                                if (incorrectPart2LinesList[i].IndexOf(part1NumPairs[0]) < incorrectPart2LinesList[i].IndexOf(part1NumPairs[1]))
                                {
                                    part2LineIsCorrect = true;
                                }
                                else
                                {
                                    var firstNumInPart1List = part1NumPairs[0];
                                    var secondNumInPart1List = part1NumPairs[1];

                                    var num1Index = incorrectPart2LinesList[i].IndexOf(firstNumInPart1List);
                                    var num2Index = incorrectPart2LinesList[i].IndexOf(secondNumInPart1List);

                                    string result1 = incorrectPart2LinesList[i].Remove(num1Index, 2).Insert(num1Index, secondNumInPart1List);
                                    incorrectPart2LinesList[i] = result1;
                                    string result2 = incorrectPart2LinesList[i].Remove(num2Index, 2).Insert(num2Index, firstNumInPart1List);

                                    incorrectPart2LinesList[i] = result2;
                                }
                            }
                        }
                    }
                    if (part2LineIsCorrect)
                    {
                        recorrectPart2LinesList.Add(incorrectPart2LinesList[i]);
                        incorrectPart2LinesList.Remove(incorrectPart2LinesList[i]);
                    }
                }
            }

            CountFinalValue(recorrectPart2LinesList);
            
        }
        public static void CountFinalValue(List<string> correctPart2Lines)
        {
            var totalValue = 0;
            for (int i = 0; i < correctPart2Lines.Count; i++)
            {
                Console.WriteLine("Final: " + correctPart2Lines[i]);

                var correctPart2LineArrayed = correctPart2Lines[i].Split(",");

                var middleNumberIndex = correctPart2LineArrayed.Count() / 2;

                var correctPart2LineArrayedMiddleNumber = correctPart2LineArrayed[middleNumberIndex];

                totalValue += int.Parse(correctPart2LineArrayedMiddleNumber);
            }
            Console.WriteLine(totalValue);
        }
    }
}