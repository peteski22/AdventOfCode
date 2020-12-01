namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day01
    {
        private const string Day01InputPath = @"C:\src\AdventOfCode\AdventOfCode\input\day01.input";

        public void Run()
        {
            // Day 1
            var list = Convert(File.ReadAllLines(Day01InputPath).First());

            var part1 = Sum2(list);
            var part2 = Sum3(list);
        }

        private static int Sum(IReadOnlyCollection<int> list, int first = 0, int a = 0, int sum = 0)
        {
            var b = list.First();

            if (a == b)
                sum += a;

            if (first == 0)
                first = list.First();

            var tail = list.Skip(1).ToList();

            if (tail.Any())
            {
                return Sum(tail, first, b, sum);
            }

            if (first == b)
            {
                return sum += b;
            }

            return sum;
        }

        private int Sum2(IEnumerable<int> list)
        {
            var items = list.ToArray();

            return items.ToArray().Where((t, i) => t == (items.Length == i + 1 ? items[0] : items[i + 1])).Sum();
        }

        private int Sum3(IEnumerable<int> list)
        {
            var sum = 0;
            var items = list.ToArray();

            for (var i = 0; i < items.Length; i++)
            {
                var steppedIndex = (i + items.Length / 2) % items.Length;

                if (items[i] == items[steppedIndex])
                    sum += items[i];
            }

            return sum;
        }

        private static List<int> Convert(string list)
        {
            if (string.IsNullOrEmpty(list))
                return new List<int>();

            return (from c in list
                let n = int.Parse(c.ToString())
                select n).ToList();
        }
    }
}