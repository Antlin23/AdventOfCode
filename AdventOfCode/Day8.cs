using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day8 {
        public static void Start(string puzzle)
        {
            //p2 in progress
            var puzzleInput = puzzle;

            HashSet<(int, int)> antinodes = new HashSet<(int, int)>();
            string[] inputLines = puzzleInput.Split("\r\n");

            var characters = GetCharactersGrouped(puzzleInput);

            for (int i = 0; i < characters.Count(); i++) {
                Console.WriteLine(characters[i][0].Character + ":");
                for (int j = 0; j < (characters[i].Count() - 1); j++)
                {
                    if (!antinodes.Contains((characters[i][j].XPosition, characters[i][j].YPosition)))
                        antinodes.Add((characters[i][j].XPosition, characters[i][j].YPosition));

                    for (int k = j + 1; k < characters[i].Count(); k++)
                    {
                        //node 1
                        var xdiffNode1 = characters[i][j].XPosition - characters[i][k].XPosition;
                        var ydiffNode1 = characters[i][k].YPosition - characters[i][j].YPosition;

                        var antinode1x = 0;

                        if (characters[i][j].XPosition < characters[i][k].XPosition)
                            antinode1x = characters[i][j].XPosition - Math.Abs(xdiffNode1);
                        else
                            antinode1x = characters[i][j].XPosition + Math.Abs(xdiffNode1);

                        var antinode1y = characters[i][j].YPosition - ydiffNode1;

                        //node 2
                        var xdiffNode2 = characters[i][j].XPosition - characters[i][k].XPosition;
                        var ydiffNode2 = characters[i][k].YPosition - characters[i][j].YPosition;

                        var antinode2x = 0;

                        if (characters[i][j].XPosition < characters[i][k].XPosition)
                            antinode2x = characters[i][k].XPosition + Math.Abs(xdiffNode2);
                        else
                            antinode2x = characters[i][k].XPosition - Math.Abs(xdiffNode2);

                        var antinode2y = characters[i][k].YPosition + ydiffNode2;

                        //if first node is on map
                        if ((antinode1x >= 0) && (antinode1x < (inputLines[0].Length)) && antinode1y >= 0 && (antinode1y < inputLines.Count()))
                        {
                            //add antinode
                            Console.WriteLine(antinode1x + "x pos - y pos innan räkning, " + antinode1y);

                            if (!antinodes.Contains((antinode1x, antinode1y)))
                                antinodes.Add((antinode1x, antinode1y));
                            else
                            {
                                while (true)
                                {
                                    //new x pos
                                    if (characters[i][j].XPosition < characters[i][k].XPosition)
                                        antinode1x = antinode1x - Math.Abs(xdiffNode1);
                                    else
                                        antinode1x = antinode1x + Math.Abs(xdiffNode1);

                                    //new y pos
                                    antinode1y = antinode1y - ydiffNode1;


                                    Console.WriteLine(antinode1x + ", " + antinode1y + ", j: " + j + ", k: " + k);
                                    //cheks if on map
                                    if ((antinode1x >= 0) && (antinode1x < (inputLines[0].Length)) && antinode1y >= 0 && (antinode1y < inputLines.Count()))
                                    {
                                        //add antinode

                                        if (!antinodes.Contains((antinode1x, antinode1y)))
                                            antinodes.Add((antinode1x, antinode1y)); Console.WriteLine("adds");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                           
                        }
                        //if second node is on map
                        if ((antinode2x >= 0) && (antinode2x < (inputLines[0].Length)) && (antinode2y >= 0) && (antinode2y < inputLines.Count()))
                        {
                            //add antinode

                            if (!antinodes.Contains((antinode2x, antinode2y)))
                                antinodes.Add((antinode2x, antinode2y));
                            else
                            {
                                while (true)
                                {
                                    //new x pos
                                    if (characters[i][j].XPosition < characters[i][k].XPosition)
                                        antinode2x = antinode2x + Math.Abs(xdiffNode2);
                                    else
                                        antinode2x = antinode2x - Math.Abs(xdiffNode2);

                                    //new y pos
                                    antinode2y = antinode2y - ydiffNode2;
                                    //try add again
                                    if ((antinode2x >= 0) && (antinode2x < (inputLines[0].Length)) && (antinode2y >= 0) && (antinode2y < inputLines.Count()))
                                    {
                                        //add antinode
                                        if (!antinodes.Contains((antinode2x, antinode2y)))
                                            antinodes.Add((antinode2x, antinode2y));
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(antinodes.Count());
            //Part 1: 261

            //1235
        }

        public static void AddNodeToAntiNodes()
        {
            
        }

        //puzzleInput = AddAntenna(puzzleInput, characters[i][0].Character, antinode1x, antinode1y);

        //public static string AddAntenna(string puzzleInput,char character ,int xPos, int yPos)
        //{
        //    string[] inputLines = puzzleInput.Split("\r\n");

        //    if (yPos >= 0 && yPos < inputLines.Count())
        //    {
        //        StringBuilder sb = new StringBuilder(inputLines[yPos]);
        //        if (xPos >= 0 && xPos < inputLines[0].Length)
        //        {
        //            if (sb[xPos] == '.')
        //            {
        //                sb[xPos] = character;
        //                inputLines[yPos] = sb.ToString();
        //            }
        //        }
        //    }
        //    return inputLines.ToString();
        //}

        public class MyChar {
            public char Character;
            public int XPosition;
            public int YPosition;
        }

        public static List<List<MyChar>> GetCharactersGrouped(string puzzleInput)
        {
            string[] inputLines = puzzleInput.Split("\r\n");

            List<char> uniqueCharactersInPuzzle = GetUniqueCharacters(puzzleInput);

            List<List<MyChar>> charactersInPuzzle = new List<List<MyChar>>();

            for (int i = 0; i < inputLines.Count(); i++)
            {
                for (int j = 0; j < inputLines[i].Count(); j++)
                {
                    for (int k = 0; k < uniqueCharactersInPuzzle.Count(); k++)
                    {
                        List<MyChar> chars = new List<MyChar>();
                        if (inputLines[i][j] == uniqueCharactersInPuzzle[k])
                        {
                            MyChar newChar = new MyChar();
                            newChar.Character = uniqueCharactersInPuzzle[k];
                            newChar.XPosition = j;
                            newChar.YPosition = i;
                            chars.Add(newChar);
                        }
                        if (chars.Count > 0)
                        {
                            charactersInPuzzle.Add(chars);
                        }
                    }
                }
            }

            List<List<MyChar>> charactersInPuzzleMerged = new List<List<MyChar>>();


            for (int i = 0; i < uniqueCharactersInPuzzle.Count(); i++)
            {
                List<MyChar> newUniqueCharList = new List<MyChar>();

                for (int j = 0; j < charactersInPuzzle.Count(); j++)
                {
                    for (int k = 0;k < charactersInPuzzle[j].Count(); k++)
                    {
                        if (charactersInPuzzle[j][k].Character == uniqueCharactersInPuzzle[i])
                        {
                            newUniqueCharList.Add(charactersInPuzzle[j][k]);
                        }
                    }

                }
                charactersInPuzzleMerged.Add(newUniqueCharList);
            }

            //writes all characters grouped
            //for (int i = 0; i < charactersInPuzzleMerged.Count(); i++)
            //{
            //    for (int j = 0; j < charactersInPuzzleMerged[i].Count(); j++)
            //    {
            //        Console.WriteLine("Char: " + charactersInPuzzleMerged[i][j].Character);
            //        Console.WriteLine(charactersInPuzzleMerged[i][j].XPosition);
            //        Console.WriteLine(charactersInPuzzleMerged[i][j].YPosition);
            //    }
            //    Console.WriteLine();
            //}

            return charactersInPuzzleMerged;
        }

        public static List<char> GetUniqueCharacters(string puzzleInput)
        {
            List<char> result = new List<char>();

            foreach(char s in puzzleInput)
            {
                if(!result.Contains(s))
                    result.Add(s);
            }
            result.Remove('.');
            result.Remove('\n');
            result.Remove('\r');
            return result;
        }
    }
}