namespace AdventOfCode
{
    using System.IO;
    using System;
    using System.Linq;

    public class Day05
    {
        private const string InputPath = @"C:\src\AdventOfCode\AdventOfCode\input\day05.input";

        private const string InputPathSamplePart1 = @"C:\src\AdventOfCode\AdventOfCode\input\day05part1-sample.input";

        public void Run()
        {
            var test1 = GetNumberOfSteps(InputPathSamplePart1);
            var res = GetNumberOfSteps(InputPath);

            var test2 = GetNumberOfStepsStrange(InputPathSamplePart1);
            var res2 = GetNumberOfStepsStrange(InputPath);
        }

        private static int GetNumberOfSteps(string inputPath)
        {
            var instructions = File.ReadAllLines(inputPath).Select(int.Parse).ToArray();
            var steps = 0;
            var currentIndex = 0;

            while (true)
            {
                try
                {
                    var delta = instructions[currentIndex];
                    instructions[currentIndex] += 1;
                    steps += 1;
                    currentIndex += delta;
                }
                catch (IndexOutOfRangeException)
                {
                    return steps;
                }
            }
        }

        private static int GetNumberOfStepsStrange(string inputPath)
        {
            var instructions = File.ReadAllLines(inputPath).Select(int.Parse).ToArray();
            var steps = 0;
            var currentIndex = 0;

            while (true)
            {
                try
                {
                    var delta = instructions[currentIndex];
                    instructions[currentIndex] = delta >= 3 ? instructions[currentIndex] - 1 : instructions[currentIndex] + 1;
                    steps += 1;
                    currentIndex += delta;
                }
                catch (IndexOutOfRangeException)
                {
                    return steps;
                }
            }
        }
    }
}