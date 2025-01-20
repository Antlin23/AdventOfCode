using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode { //day 9 completed with example puzzle, not the real
    public class Day9 {
        public static void Start(string puzzle)
        {
            var puzzleInput = FirstStep(puzzle);

            puzzleInput = SecondStep(puzzleInput);

            puzzleInput = ThirdStep(puzzleInput);

            var checksum = CalculateChecksum(puzzleInput);

            Console.WriteLine("checksum: " + checksum);
        }
        //1859249580 too low

        //Calculates the sum from the final string
        public static int CalculateChecksum(string puzzle) {
            var sum = 0;
            Console.WriteLine("At checksum function " + puzzle);
            for (int i = 0; i < puzzle.Length; i++)
            {
                string c = puzzle[i].ToString();

                if(c != " ")
                    sum += int.Parse(c) * i;
            }
            return sum;
        }



        
        //Puts all the . on one side and the numbers on the other
        public static string ThirdStep(string puzzle)
        {
            char[] puzzleChars = puzzle.ToCharArray();

            List<char> charList = new List<char>(puzzleChars);

            Console.WriteLine("third: " + string.Join("", charList));
            //removes empty chars
            for (var j = 0; j < charList.Count; j++)
            {
                if (charList[j] == ' ')
                {
                    charList.RemoveAt(j);
                    j--;
                }
            }
            puzzleChars = charList.ToArray();

            Regex regex = new Regex(@"\.\d");


            for (var i = puzzleChars.Count() - 1; i > 0; i--)
            {
                var tempString = string.Join("", puzzleChars);

                if (!regex.IsMatch(tempString))
                    break;

                char c = puzzleChars[i];

                int index = Array.IndexOf(puzzleChars, '.');
                Console.WriteLine(index);

                puzzleChars[index] = c;
                puzzleChars[i] = '.';
            }



            charList = puzzleChars.ToList();
            //removes all .
            for (var j = 0; j < charList.Count; j++)
            {
                if (charList[j] == '.')
                {
                    charList.RemoveAt(j);
                    j--;
                }
            }
            return string.Join("", charList);
        }

        //check what to do if value is 0

        //Changes the numbers to right amount of IndexNumber 
        public static string SecondStep(string puzzle)
        {
            var input = puzzle;

            var indexPosition = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                var cStringed = c.ToString();
                if (c != '.' && c != ' ' && c != '0')
                {
                    for (int j = 0; j < int.Parse(cStringed); j++)
                    {
                        if (j == 0)
                            input = input.Remove(i, 1);

                        input = input.Insert(i, indexPosition.ToString() + " ");
                        //i++;

                        if (indexPosition < 10)
                        {
                            i += 1;
                        }
                        else if (indexPosition < 100)
                        {
                            i += 2;
                        }
                        else if (indexPosition < 1000)
                        {
                            i += 3;
                        }
                        else if (indexPosition < 10000)
                        {
                            i += 4;
                        }
                        else if (indexPosition < 100000)
                        {
                            i += 5;
                        }
                    }
                    indexPosition++;
                }
            }
            return input;
        }



        //Changes each other character to .
        public static string FirstStep(string puzzle) {
            var input = puzzle;
            for (int i = input.Length - 2; i > 0; i = i - 2) {
                char c = input[i];
                var cStringed = c.ToString();

                for (int j = 0; j < int.Parse(cStringed); j++)
                {
                    if(j == 0)
                        input = input.Remove(i + j, 1);
                    input = input.Insert(i + j, ".");
                }
                if(cStringed == "0")
                    input = input.Remove(i, 1);
            }
            return input;
        }
    }
}