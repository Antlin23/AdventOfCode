using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<List<int>> line = new List<List<int>>();

            foreach (string inputSplit in inputSplitted) {
                List<int> number = new List<int>();
                for (var i = 0; i < inputSplit.Length; i++)
                {
                    number.Add(int.Parse(inputSplit[i].ToString()));
                }
                line.Add(number);
            }

            for(var i = 0; i < line.Count; i++)
            {
                //changes all 0 to 1
                if (line[i].Count == 1 && line[i][0] == 0)
                {
                    line[i][0] = 1;
                }

                //checks if its an even amount of numbers
                else if (line[i].Count() % 2 == 0)
                {
                   // Console.WriteLine(line[i][0]);
                }

                //multiply by 2024
                else
                {
                    int calcedNum = int.Parse(string.Join("", line[i])) * 2024;

                    List<int> newNum = new List<int>();

                    string stringed = calcedNum.ToString();

                    for (var j = 0; j < stringed.Length; j++)
                    {
                        newNum.Add(int.Parse(stringed[j].ToString()));
                    }

                    line[i] = newNum;
                }
            }





            Console.WriteLine();
            Console.WriteLine();
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
