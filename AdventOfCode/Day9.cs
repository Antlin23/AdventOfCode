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
        //419901479 too low
        public static int CalculateChecksum(string puzzle) {
            var sum = 0;
            for (int i = 0; i < puzzle.Length; i++)
            {
                string c = puzzle[i].ToString();

                sum += int.Parse(c) * i;
            }
            return sum;
        }

        public static string ThirdStep(string puzzle)
        {
            var input = puzzle;
            Console.WriteLine(input);
            Regex regex = new Regex(@"\.\d");

            var i = 0;

            var inputBuilder = new StringBuilder(input);

            for (i = inputBuilder.Length - 1; i > 0; i--)
            {
                if (!regex.IsMatch(inputBuilder.ToString()))
                    break;

                char c = inputBuilder[i];

                var index = inputBuilder.ToString().IndexOf(".");

                inputBuilder[index] = c;
                inputBuilder[i] = '.';

                ////replace . with char
                //input = input.Remove(index, 1);
                //input = input.Insert(index, c);
                ////replace char with .
                //input = input.Remove(i, 1);
                //input = input.Insert(i, ".");
            }
            input = inputBuilder.ToString();

            Console.WriteLine();
            //length 221659
            Console.WriteLine("length: " + i);
            Console.WriteLine();
            Console.WriteLine(input);
            string firstPartOfInput = input.Split(".", 2)[0];

            return firstPartOfInput;
        }

        public static string SecondStep(string puzzle)
        {
            var input = puzzle;
            var indexPosition = 0;

            //input = input.Replace("0", "");
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
                        i++;

                        if (indexPosition < 10)
                        {
                            i++;
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