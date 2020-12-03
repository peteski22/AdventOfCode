namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day02
    {
        private static readonly string inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day02.input";

        private static readonly IEnumerable<Policy> policies = from line in File.ReadAllLines(inputPath)
                                                               let r = $"(?<{nameof(Policy.LowerBound)}>\\d+)-(?<{nameof(Policy.UpperBound)}>\\d+)\\s(?<{nameof(Policy.Letter)}>\\w{{1}}):\\s(?<{nameof(Policy.Password)}>\\w+)"
                                                               let m = Regex.Match(line, r)                                                               
                                                               let lowerBound = int.Parse(m.Groups[nameof(Policy.LowerBound)].Value)
                                                               let upperBound = int.Parse(m.Groups[nameof(Policy.UpperBound)].Value)
                                                               let letter = char.Parse(m.Groups[nameof(Policy.Letter)].Value)
                                                               let password = m.Groups[nameof(Policy.Password)].Value
                                                               select new Policy(lowerBound, upperBound, letter, password);
                
        public static int GetPart1Result => policies.Where(p => p.IsValidMinMax()).Count();

        public static int GetPart2Result => policies.Where(p => p.IsValidPositional()).Count();
    }

    class Policy
    {
        public int LowerBound { get; private set; }

        public int UpperBound { get; private set; }

        public char Letter { get; private set; }

        public string Password { get; private set; }        

        public bool IsValidMinMax()
        {
            var occurances = Password.Where(l => l == Letter).Count();
            return occurances >= LowerBound && occurances <= UpperBound;
        }

        public bool IsValidPositional()
        {
            return Password[LowerBound - 1] == Letter ^ Password[UpperBound - 1] == Letter;
        }

        public Policy(int min, int max, char letter, string password)
        {
            LowerBound = min;
            UpperBound = max;
            Letter = letter;
            Password = password;
        }
    }
}
