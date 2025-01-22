using BenchmarkDotNet.Disassemblers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    internal class Day10 {
        public static void Start(string input)
        {
            //Make the map rows
            string[] map = input.Split("\r\n");

            var trailHeadAmount = 0;

            List<Mark> scorePositions = new List<Mark>();

            List<int> trailHeads = new List<int>();

            var trailHeadIndex = 0;

            for (int i = 0; i < map.Count(); i++) { 

                for (int j = 0; j < map[i].Length; j++)
                {
                    //Finds the trailheads
                    if (map[i][j] == '0') {

                        trailHeadIndex++;

                        Mark mark = new Mark
                        {
                            value = 0,
                            yPos = i,
                            xPos = j,
                        };

                        var trailHead = 0;

                        var nextSteps = NextTrailSteps(mark, map);

                        for (int k = 0;k < nextSteps.Count(); k++)
                        {
                            var nextSteps2 = NextTrailSteps(nextSteps[k], map);

                            for (int ns2 = 0; ns2 < nextSteps2.Count(); ns2++)
                            {
                                var nextSteps3 = NextTrailSteps(nextSteps2[ns2], map);

                                for (int ns3 = 0; ns3 < nextSteps3.Count(); ns3++)
                                {
                                    var nextSteps4 = NextTrailSteps(nextSteps3[ns3], map);

                                    for (int ns4 = 0; ns4 < nextSteps4.Count(); ns4++)
                                    {
                                        var nextSteps5 = NextTrailSteps(nextSteps4[ns4], map);

                                        for (int ns5 = 0; ns5 < nextSteps5.Count(); ns5++)
                                        {
                                            var nextSteps6 = NextTrailSteps(nextSteps5[ns5], map);

                                            for (int ns6 = 0; ns6 < nextSteps6.Count(); ns6++)
                                            {
                                                var nextSteps7 = NextTrailSteps(nextSteps6[ns6], map);

                                                for (int ns7 = 0; ns7 < nextSteps7.Count(); ns7++)
                                                {
                                                    var nextSteps8 = NextTrailSteps(nextSteps7[ns7], map);

                                                    for (int ns8 = 0; ns8 < nextSteps8.Count(); ns8++)
                                                    {
                                                        var nextSteps9 = NextTrailSteps(nextSteps8[ns8], map);

                                                        for (int ns9 = 0; ns9 < nextSteps9.Count(); ns9++)
                                                        {
                                                            if (!scorePositions.Any(x => x.yPos == nextSteps9[ns9].yPos && x.xPos == nextSteps9[ns9].xPos && x.value == trailHeadIndex))
                                                            {
                                                                trailHead++;

                                                                nextSteps9[ns9].value = trailHeadIndex;
                                                                scorePositions.Add(nextSteps9[ns9]);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        trailHeads.Add(trailHead);
                    }
                }
            }

            foreach (var trailHead in trailHeads)
            {
                trailHeadAmount += trailHead;
            }

            Console.WriteLine(trailHeadAmount);
            //answer part 1: 786
        }
        public static List<Mark> NextTrailSteps(Mark mark, string[] map)
        {
            List<Mark> newMarks = new();

            if (map[0].Length - 1 > mark.xPos)
            {
                if (map[mark.yPos][mark.xPos + 1].ToString() == (mark.value + 1).ToString())
                {
                    Mark newMark = new Mark
                    {
                        value = mark.value + 1,
                        yPos = mark.yPos,
                        xPos = mark.xPos + 1,
                    };
                    newMarks.Add(newMark);
                }
            }

            if (map.Count() - 1 > mark.yPos)
            {
                if (map[mark.yPos + 1][mark.xPos].ToString() == (mark.value + 1).ToString())
                {
                    Mark newMark = new Mark
                    {
                        value = mark.value + 1,
                        yPos = mark.yPos + 1,
                        xPos = mark.xPos,
                    };
                    newMarks.Add(newMark);
                }
            }

            if (mark.xPos > 0)
            {
                if (map[mark.yPos][mark.xPos - 1].ToString() == (mark.value + 1).ToString())
                {
                    Mark newMark = new Mark
                    {
                        value = mark.value + 1,
                        yPos = mark.yPos,
                        xPos = mark.xPos - 1,
                    };
                    newMarks.Add(newMark);
                }
            }

            if (mark.yPos > 0)
            {
                if (map[mark.yPos - 1][mark.xPos].ToString() == (mark.value + 1).ToString())
                {
                    Mark newMark = new Mark
                    {
                        value = mark.value + 1,
                        yPos = mark.yPos - 1,
                        xPos = mark.xPos,
                    };
                    newMarks.Add(newMark);
                }
            }

            return newMarks;
        }
    }
    internal class Mark
    {
        public int value;
        public int yPos;
        public int xPos;
    }
}
