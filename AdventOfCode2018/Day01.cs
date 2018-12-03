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
            var frequenciesEncountered = new HashSet<int>();
            var isMoreNeeded = true;
            var firstDuplicateFrequency = 0;
            var multiIterationRunningTotal = 0;

            do
            {
                multiIterationRunningTotal = File.ReadAllLines(path)
                    .TakeWhile((_, b) => isMoreNeeded)
                    .Select(int.Parse)
                    .Aggregate(multiIterationRunningTotal, (currentFrequency, frequencyAdjustment) =>
                    {
                        var resultingFrequency = currentFrequency + frequencyAdjustment;

                        if (frequenciesEncountered.Add(resultingFrequency))
                            return resultingFrequency;

                        isMoreNeeded = false;
                        firstDuplicateFrequency = resultingFrequency;

                        return resultingFrequency;
                    });

            } while (isMoreNeeded);

            return firstDuplicateFrequency;
        }
    }
}
