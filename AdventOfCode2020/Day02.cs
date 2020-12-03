namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    public class Day02
    {
        private static readonly string inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day02.input";

        private static readonly IEnumerable<Policy> policies = from line in File.ReadAllLines(inputPath)
                                                               let policyPass = line.Split(':', System.StringSplitOptions.RemoveEmptyEntries)
                                                               let pass = policyPass.Last().Trim()
                                                               let policy = policyPass.First().Split(' ')
                                                               let letter = char.Parse(policy.Last())
                                                               let min = int.Parse(policy.First().Split('-').First())
                                                               let max = int.Parse(policy.First().Split('-').Last())
                                                               select new Policy(min, max, letter, pass);
        public static int GetPart1Result => policies.Where(p => p.IsValidMinMax()).Count();

        public static int GetPart2Result => policies.Where(p => p.IsValidPositional()).Count();
    }

    class Policy
    {
        public int Minimum { get; private set; }

        public int Maximum { get; private set; }

        public char Letter { get; private set; }

        public string Password { get; private set; }

        public bool IsValidMinMax()
        {
            var occurances = Password.Where(l => l == Letter).Count();
            return occurances >= Minimum && occurances <= Maximum;
        }

        public bool IsValidPositional()
        {
            return Password[Minimum - 1] == Letter ^ Password[Maximum - 1] == Letter;
        }

        public Policy(int min, int max, char letter, string password)
        {
            Minimum = min;
            Maximum = max;
            Letter = letter;
            Password = password;
        }
    }
}
