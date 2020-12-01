namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day02
    {
        private const string Day02InputPath = @"C:\src\AdventOfCode\AdventOfCode\input\day02.input";

        public void Run()
        {
            // Day 2
            var part1 = GetMinMaxChecksums(Day02InputPath).Sum();
            var part2 = GetModuloChecksums(Day02InputPath).Sum();
        }

        private static IEnumerable<int[]> GetItemCollections(string inputFilePath) => File.ReadAllLines(inputFilePath).Select(r => Array.ConvertAll(r.Split('\t', ' '), int.Parse));

        private static IEnumerable<int> GetMinMaxChecksums(string inputFilePath) => GetItemCollections(inputFilePath).Select(i => i.Max() - i.Min());

        private static IEnumerable<int> GetModuloChecksums(string inputFilePath)
        {
            foreach (var items in GetItemCollections(inputFilePath))
            {
                for (var i = 0; i < items.Length; i++)
                {
                    var current = items[i];

                    for (var j = 0; j < items.Length; j++)
                    {
                        if (i == j)
                            continue;

                        var other = items[j];

                        if (current % other == 0)
                        {
                            yield return current / other;
                        }
                    }
                }
            }
        }
    }
}