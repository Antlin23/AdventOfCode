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

            //Finds the trailheads
            for (int i = 0; i < map.Count(); i++) { 

                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '0') {

                        Mark mark = new Mark
                        {
                            value = 0,
                            yPos = i,
                            xPos = j,
                        };

                        var nextSteps = NextTrailSteps(mark, map);

                        foreach (var step in nextSteps) {
                            Console.WriteLine(step.yPos + " " + step.xPos);
                        }
                    }
                }
            }
        }
        public static List<Mark> NextTrailSteps(Mark mark, string[] map)
        {
            List<Mark> newMarks = new();

            if (map[0].Length - 1 > mark.xPos)
            {
                Console.WriteLine("oof");
                if (map[mark.yPos][mark.xPos + 1].ToString() == (mark.value + 1).ToString())
                {
                    Mark newMark = new Mark
                    {
                        value = mark.value + 1,
                        yPos = mark.yPos,
                        xPos = mark.xPos + 1,
                    };
                    Console.WriteLine("add");
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
