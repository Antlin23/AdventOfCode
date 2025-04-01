using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {
    internal class Day11 {
        public static void Start(string input)
        {
            Console.WriteLine(input);
            Console.WriteLine();

            //array with numbers
            string[] inputSplitted = input.Split(' ');
            //list with a list with numbers
            List<List<long>> line = new List<List<long>>();

            foreach (string inputSplit in inputSplitted) {
                List<long> number = new List<long>();
                for (var i = 0; i < inputSplit.Length; i++)
                {
                    number.Add(long.Parse(inputSplit[i].ToString()));
                }
                line.Add(number);
            }

            for (int k = 0; k < 75; k++)
            {
                for (var i = 0; i < line.Count; i++)
                {
                    //changes all 0 to 1
                    if (line[i].Count == 1 && line[i][0] == 0)
                    {
                        line[i][0] = 1;
                    }

                    //checks if its an even amount of numbers
                    else if (line[i].Count() % 2 == 0)
                    {
                        List<long> firstHalfOfList = new List<long>();

                        List<long> newList = new List<long>();

                        for (var j = 0; j < line[i].Count(); j++)
                        {
                            //takes the second half
                            if (j >= line[i].Count() / 2)
                            {
                                long firstNum = 0;
                                firstNum = line[i][j];

                                if(firstNum != 0 || (j + 1) == line[i].Count() || newList.Count > 0)
                                {
                                    //adds second half to a new list
                                    newList.Add(line[i][j]);
                                }
                            }
                            else
                            {
                                firstHalfOfList.Add(line[i][j]);
                            }
                        }

                        line[i] = firstHalfOfList;
                        line.Insert(i + 1, newList);

                        //increases index by 1 bec one is added
                        i++;
                    }

                    //multiply by 2024
                    else
                    {
                        long calcedNum = long.Parse(string.Join("", line[i])) * 2024;

                        List<long> newNum = new List<long>();

                        string stringed = calcedNum.ToString();

                        for (var j = 0; j < stringed.Length; j++)
                        {
                            newNum.Add(long.Parse(stringed[j].ToString()));
                        }
                        line[i] = newNum;
                    }
                }
                Console.WriteLine("k -----------" + k);
            }

            Console.WriteLine();
            // printLine(line);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Amount of stones: " + line.Count());
            Console.ResetColor();
            //Answer part 1: 203457
        }

        public static void printLine(List<List<long>> line)
        {
            //writes the list
            for (var i = 0; i < line.Count; i++)
            {
                for (var j = 0; j < line[i].Count; j++)
                {
                    Console.Write(line[i][j]);
                }
                Console.WriteLine();

            }
        }
    }
}
