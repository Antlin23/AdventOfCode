using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode {
    public class Day6 {
        public static void Start(string puzzleInput)
        {
            var lines = puzzleInput.Split("\r\n");

            while (true)
            { //before each move we get guards position
                var guardsLine = FindGuardsPosition(lines)[0];
                var guardsXPosition = FindGuardsPosition(lines)[1];

                //move guard up
                if(IsGuardInsideMap(lines))
                    lines = MoveGuardUp(lines, guardsLine, guardsXPosition);
                else break;

                guardsLine = FindGuardsPosition(lines)[0];
                guardsXPosition = FindGuardsPosition(lines)[1];

                //move guard to the right
                if (IsGuardInsideMap(lines))
                    lines = MoveGuardToTheRight(lines, guardsLine, guardsXPosition);
                else break;

                guardsLine = FindGuardsPosition(lines)[0];
                guardsXPosition = FindGuardsPosition(lines)[1];

                //move guard down
                if (IsGuardInsideMap(lines))
                    lines = MoveGuardDown(lines, guardsLine, guardsXPosition);
                else break;

                guardsLine = FindGuardsPosition(lines)[0];
                guardsXPosition = FindGuardsPosition(lines)[1];

                //move guard to the left
                if (IsGuardInsideMap(lines))
                    lines = MoveGuardToTheLeft(lines, guardsLine, guardsXPosition);
                else break;
            }
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine(CountGuardPositions(lines));
            //anwser part 1: 4454
        }
        public static int CountGuardPositions(string[] lines)
        {
            var linesMadeTogether = "";
            int total = 0;
            foreach (var line in lines)
            {
                linesMadeTogether += line;
            }
            var matches = Regex.Matches(linesMadeTogether, "X");

            foreach (var match in matches)
            {
                total++;
            }
            return total;
        }

        public static bool IsGuardInsideMap(string[] map)
        {
            foreach (var line in map)
            {
                if (line.IndexOf('^') != -1)
                {
                    return true;
                }
            }
            return false;
        }
        public static List<int> FindGuardsPosition(string[] map)
        {
            var guardsLine = 0;
            var guardsXPosition = 0;
            for (int i = 0; i < map.Count(); i++)
            {
                if (map[i].Contains("^"))
                {
                    guardsLine = i;
                    guardsXPosition = map[i].IndexOf("^");
                }
            }
            List<int> guardsPosition = new List<int>();
            guardsPosition.Add(guardsLine);
            guardsPosition.Add(guardsXPosition);
            return guardsPosition;
        }
        public static string[] MoveGuardUp(string[] map, int guardsLine, int guardsXPosition)
        {
            while (true) {
                if (((guardsLine + 1) < map.Count()) && guardsLine > 0)
                {

                    if (map[guardsLine - 1][guardsXPosition].ToString() == "#")
                    {
                        break;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = 'X';
                        map[guardsLine] = sb.ToString();
                        guardsLine--;

                        sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = '^';
                        map[guardsLine] = sb.ToString();
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder(map[guardsLine]);
                    sb[guardsXPosition] = 'X';
                    map[guardsLine] = sb.ToString();
                    break;
                }
            }
            return map;
        }
        public static string[] MoveGuardToTheRight(string[] map, int guardsLine, int guardsXPosition)
        {
            while (true)
            {
                if ((guardsXPosition + 1) < map.Count())
                {
                    if (map[guardsLine][guardsXPosition + 1].ToString() == "#")
                    {
                        break;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = 'X';
                        map[guardsLine] = sb.ToString();
                        guardsXPosition++;

                        sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = '^';
                        map[guardsLine] = sb.ToString();
                    }
                }
                else {
                    StringBuilder sb = new StringBuilder(map[guardsLine]);
                    sb[guardsXPosition] = 'X';
                    map[guardsLine] = sb.ToString();
                    break;
                }
            }
            return map;
        }
        public static string[] MoveGuardDown(string[] map, int guardsLine, int guardsXPosition)
        {
            while (true)
            {
                if ((guardsLine + 1) < map.Count())
                {
                    if (map[guardsLine + 1][guardsXPosition].ToString() == "#")
                    {
                        break;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = 'X';
                        map[guardsLine] = sb.ToString();
                        guardsLine++;

                        sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = '^';
                        map[guardsLine] = sb.ToString();
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder(map[guardsLine]);
                    sb[guardsXPosition] = 'X';
                    map[guardsLine] = sb.ToString();
                    break;
                }
            }
            return map;
        }
        public static string[] MoveGuardToTheLeft(string[] map, int guardsLine, int guardsXPosition)
        {
            while (true)
            {
                if ((guardsXPosition + 1) < map.Count())
                {

                    if (map[guardsLine][guardsXPosition - 1].ToString() == "#")
                    {
                        break;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = 'X';
                        map[guardsLine] = sb.ToString();
                        guardsXPosition--;

                        sb = new StringBuilder(map[guardsLine]);
                        sb[guardsXPosition] = '^';
                        map[guardsLine] = sb.ToString();
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder(map[guardsLine]);
                    sb[guardsXPosition] = 'X';
                    map[guardsLine] = sb.ToString();
                    break;
                }
            }
            return map;
        }
    }
}
