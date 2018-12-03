namespace AdventOfCode2018
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day01
    {
        public static int GetFinalFrequency(string path) => File.ReadAllLines(path).Select(int.Parse).Sum();

        public static int GetFirstDuplicatedFrequency(string path)
        {
            var frequencies = new HashSet<int>();
            var isMoreNeeded = true;
            var firstDuplicateFrequency = 0;
            var runningTotal = 0;

            do
            {
                runningTotal = File.ReadAllLines(path)
                    .TakeWhile((_, b) => isMoreNeeded)
                    .Select(int.Parse)
                    .Aggregate(runningTotal, (x, y) =>
                    {
                        var v = x + y;

                        if (!frequencies.Add(v))
                        { 
                            isMoreNeeded = false;
                            firstDuplicateFrequency = v;
                        }

                        return v;
                    });

            } while (isMoreNeeded);

            return firstDuplicateFrequency;
        }
    }
}
