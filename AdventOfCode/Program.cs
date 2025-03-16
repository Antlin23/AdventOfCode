namespace AdventOfCode;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Program {
    public static void Main(string[] args)        //The problem descriptions is found at adventofcode.com
    {
     //   BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        Program program = new Program();

        program.Start();
    }

    [Benchmark]
    public void Start()
    {
        //string exPuzzle = "89010123\r\n78121874\r\n87430965\r\n96549874\r\n45678903\r\n32019012\r\n01329801\r\n10456732";
        string puzzleInput = "1 24596 0 740994 60 803 8918 9405859";
        Day11.Start(puzzleInput);
    }
}