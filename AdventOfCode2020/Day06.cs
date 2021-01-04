namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day06
    {
        private static readonly string inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day06.input";

        public static int GetPart1Result()
        {
            return (from @group in Regex.Split(File.ReadAllText(inputPath), "\r\n\r\n")
                    select new HashSet<char>(from person in Regex.Split(@group, "\r\n")
                                             from answer in person
                                             where (answer >= 'a' && answer <= 'z') || (answer >= 'A' && answer <= 'Z')
                                             select char.ToUpperInvariant(answer))).Sum(x => x.Count);
        }

        public static int GetPart2Result()
        {
            var answersForGroups = from @group in Regex.Split(File.ReadAllText(inputPath), "\r\n\r\n")
                                   select (
                                   from person in Regex.Split(@group, "\r\n")
                                   select new HashSet<char>(from answer in person
                                                            where (answer >= 'a' && answer <= 'z') || (answer >= 'A' && answer <= 'Z')
                                                            select char.ToUpperInvariant(answer)));

            return answersForGroups.Select(x => x.Skip(1).Aggregate(x.First(), (hashSet, nextHashSet) =>
            {
                hashSet.IntersectWith(nextHashSet);
                return hashSet;
            })).Sum(x => x.Count);
        }
    }
}
