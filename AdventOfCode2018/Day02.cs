namespace AdventOfCode2018
{
    using System.Collections.Concurrent;
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
    }
}