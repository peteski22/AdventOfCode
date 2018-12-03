namespace AdventOfCode2018
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day02
    {
        private const int Zero = 0;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;

        public static ConcurrentDictionary<char, int> GetCharAndSum(string chars)
        {
            var charsAndCount = new ConcurrentDictionary<char, int>();

            chars.ToList().ForEach(c => { charsAndCount.AddOrUpdate(c, One, (id, count) => count + One); });

            return charsAndCount;
        }

        public static int GetIncrementAmount(bool value) => value ? One : Zero;

        public static int GetChecksum(string path)
        {
            var checksum = File.ReadAllLines(path)
                .Aggregate(new { Twos = Zero, Threes = Zero },
                    (twosAndThrees, row) =>
                    {
                        var charsAndCount = GetCharAndSum(row);
                        
                        return new
                        {
                            Twos = twosAndThrees.Twos + GetIncrementAmount(charsAndCount.Any(kvp => kvp.Value == Two)),
                            Threes = twosAndThrees.Threes + GetIncrementAmount(charsAndCount.Any(kvp => kvp.Value == Three))
                        };
                    });

            return checksum.Twos * checksum.Threes;
        }

        public static string GetCharactersWhereOnlySingleCharDifference(string path)
        {
            var source = File.ReadAllLines(path);

            var chars = (from first in source
                         from second in source
                         where first != second
                         let res = GetCharsAndIsOneApart(first, second)
                         where res.Item2
                         select res.Item1)
                        .First()
                        .ToArray();

            var result = new string(chars);

            return result;
        }

        public static Tuple<HashSet<char>, bool> GetCharsAndIsOneApart(string first, string second)
        {
            var matchingChars = first
                .Select((c, idx) => new { @Char = c, Index = idx })
                .Where(c => first[c.Index] == second[c.Index])
                .Select(o => o.Char).ToArray();

            var originalSize = first.ToCharArray().Count();
            var calculatedSize = matchingChars.Count();
            var isOneApart = originalSize - calculatedSize == One;

            return Tuple.Create(matchingChars.ToHashSet(), isOneApart);
        }
    }
}