namespace AdventOfCode
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    public class Day06
    {
        private const string InputPath = @"C:\src\AdventOfCode\AdventOfCode\input\day06.input";

        private const string InputPathSamplePart1 = @"C:\src\AdventOfCode\AdventOfCode\input\day06part1-sample.input";

        public void Run()
        {
            var test1 = GetResdistBeforeDupe(InputPathSamplePart1);
            var res = GetResdistBeforeDupe(InputPath);

            var test2 = GetLoopsBeforeDupe(InputPathSamplePart1);
            var res2 = GetLoopsBeforeDupe(InputPath);
        }

        private static int GetNextIndex(IReadOnlyCollection<int> array, int currentIndex) => (currentIndex + 1) % array.Count;

        private static int[] GetMemoryBanks(string inputPath) => File.ReadAllLines(inputPath).Select(r => Array.ConvertAll(r.Split('\t', ' '), int.Parse)).First();

        private static int GetResdistBeforeDupe(string inputPath)
        {
            var seenStates = new List<string>();

            var redistributions = 0;
            var memoryBanks = GetMemoryBanks(inputPath);

            while (true)
            {
                var highestIndex = memoryBanks.ToList().IndexOf(memoryBanks.Max());
                var highestValue = memoryBanks[highestIndex];

                memoryBanks[highestIndex] = 0;

                var remainingBlocks = highestValue;
                var startIndex = GetNextIndex(memoryBanks, highestIndex);

                for (var i = startIndex; remainingBlocks > 0; i = GetNextIndex(memoryBanks, i))
                {
                    memoryBanks[i] = memoryBanks[i] + 1;
                    remainingBlocks--;
                }

                redistributions++;
                var currentState = string.Concat(memoryBanks.Select(b => b.ToString()));

                if (seenStates.Contains(currentState))
                    return redistributions;

                seenStates.Add(currentState);
            }
        }

        private static int GetLoopsBeforeDupe(string inputPath)
        {
            var seenStates = new List<Tuple<string, int>>();

            var redistributions = 0;
            var memoryBanks = GetMemoryBanks(inputPath);

            while (true)
            {
                var highestIndex = memoryBanks.ToList().IndexOf(memoryBanks.Max());
                var highestValue = memoryBanks[highestIndex];

                memoryBanks[highestIndex] = 0;

                var remainingBlocks = highestValue;
                var startIndex = GetNextIndex(memoryBanks, highestIndex);

                for (var i = startIndex; remainingBlocks > 0; i = GetNextIndex(memoryBanks, i))
                {
                    memoryBanks[i] = memoryBanks[i] + 1;
                    remainingBlocks--;
                }

                redistributions++;
                var currentState = string.Concat(memoryBanks.Select(b => b.ToString()));

                if (seenStates.Any(s => s.Item1 == currentState))
                    return redistributions - seenStates.Where(s => s.Item1 == currentState).Select(s => s.Item2).First();

                seenStates.Add(Tuple.Create(currentState, redistributions));
            }
        }
    }
}
