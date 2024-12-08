using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day7 { //Day7 is not complete
        public static void Start(string puzzle)
        {
            var puzzleLines = linefyPuzzle(puzzle);

            for (int i = 0; i < puzzleLines.Length; i++)
            {
                var puzzleLineSum = puzzleLines[i].Split(": ")[0];
                var puzzlePartWithNumbers = puzzleLines[i].Split(": ")[1];

                var puzzleLineNums = puzzlePartWithNumbers.Split(" ");

                foreach (var number in puzzleLineNums) {
                    Console.WriteLine(number);
                }
                Console.WriteLine();

            }
        }
        public static string[] linefyPuzzle(string puzzle) {
            return puzzle.Split("\r\n");
        }
    }
}
