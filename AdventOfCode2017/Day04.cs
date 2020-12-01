namespace AdventOfCode
{
    using System.IO;
    using System.Linq;

    public class Day04
    {
        private const string InputPath = @"C:\src\AdventOfCode\AdventOfCode\input\day04.input";

        private const string InputPathSamplePart1 = @"C:\src\AdventOfCode\AdventOfCode\input\day04part1-sample.input";

        private const string InputPathSamplePart2 = @"C:\src\AdventOfCode\AdventOfCode\input\day04part2-sample.input";

        public void Run()
        {
            var test1 = GetValidPassphrasesByWord(InputPathSamplePart1);
            var res = GetValidPassphrasesByWord(InputPath);

            var test2 = GetValidPassphrasesByCharacter(InputPathSamplePart2);
            var res2 = GetValidPassphrasesByCharacter(InputPath);
        }

        private static int GetValidPassphrasesByWord(string inputPath) =>  File.ReadAllLines(inputPath).Select(r => r.Split(' ')).Count(x => x.Distinct().Count() == x.Length);
        
        private static int GetValidPassphrasesByCharacter(string inputPath)
        {
            var result = from r in File.ReadAllLines(inputPath)
                          let words = r.Split(' ')
                          let ordered = from word in words select string.Concat(word.OrderBy(c => c))
                          select new
                          {
                              distinct = ordered.Distinct().Count(),
                              original = words.Length,
                          };

            return result.Count(x => x.distinct == x.original);           
        }
    }
}