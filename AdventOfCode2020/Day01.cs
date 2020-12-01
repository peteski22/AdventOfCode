namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day01
    {

        private static readonly string inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day01.input";

        private static readonly List<int> input = File.ReadAllLines(inputPath).Select(line => int.Parse(line)).ToList();

        public static int GetPart1Result()
        {
            return (from int i in input
                    from int j in input
                    where i + j == 2020
                    select i * j).Distinct().First();
        }

        public static int GetPart2Result()
        {
            return (from int i in input
                    from int j in input
                    from int k in input
                    where i + j + k == 2020
                    select i * j * k).Distinct().First();
        }

    }
}