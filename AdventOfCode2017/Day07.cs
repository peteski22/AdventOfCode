namespace AdventOfCode
{
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day07
    {
        private const string InputPath = @"C:\src\AdventOfCode\AdventOfCode\input\day07.input";

        private const string InputPathSamplePart1 = @"C:\src\AdventOfCode\AdventOfCode\input\day07part1-sample.input";

        public void Run()
        {
            //var test1 = RecFoo1(GetData(InputPathSamplePart1));
            //var test1 = GetBottomProgram(GetData(InputPathSamplePart1));

            //
            var x = GetNodes(InputPathSamplePart1).ToList();
            //var y = x.First(n => n.Parent == null);
            

            //var test2 = GetBottomProgram(GetData(InputPath)).First();
            //var res = GetBottomProgramRec(GetData(InputPath));
        }

        private static IEnumerable<ProgramyThing> GetData(string inputPath)
        {
            return from row in File.ReadAllLines(inputPath)
                       //let match = Regex.Match(row, @"(?<prog>[A-Za-z]+)\s\((?<weight>[\d]+)\)(\s->\s(?<subs>.*))?")
                       let match = Regex.Match(row, @"(?<prog>[A-Za-z]+)\s\((?<weight>[\d]+)\)\s->\s(?<subs>.*)")
                       where match.Success
                       select new ProgramyThing
                       {
                           Name = match.Groups["prog"].Value,
                           Weight = int.Parse(match.Groups["weight"].Value),
                           Subs = match.Groups["subs"].Value.Split(',').Select(s => s.Trim())
                       };
        }

        private static IEnumerable<IGrouping<Node,Node>> GetNodes(string inputPath)
        {
            var data = (from row in File.ReadAllLines(inputPath)
                       //let match = Regex.Match(row, @"(?<prog>[A-Za-z]+)\s\((?<weight>[\d]+)\)\s->\s(?<subs>.*)")
                       let match = Regex.Match(row, @"(?<prog>[A-Za-z]+)\s\((?<weight>[\d]+)\)(\s->\s(?<subs>.*))?")
                       where match.Success
                       select new Node
                       {
                           Name = match.Groups["prog"].Value,
                           Weight = int.Parse(match.Groups["weight"].Value),
                           /*
                           Children = from child in match.Groups["subs"]?.Value.Split(',')
                                      where !string.IsNullOrWhiteSpace(child)
                                      select new Node { Name = child.Trim() }
                            */
                       }).ToList();

            var nodesToLink = from row in File.ReadAllLines(inputPath)
                              let match = Regex.Match(row, @"(?<prog>[A-Za-z]+)\s\((?<weight>[\d]+)\)\s->\s(?<subs>.*)")
                              where match.Success
                              select new KeyValuePair<string, IEnumerable<string>>(match.Groups["prog"].Value, match.Groups["subs"].Value.Split(',').Select(s => s.Trim()));

            foreach (var kvp in nodesToLink)
            {
                var parentKey = kvp.Key;
                var parentIndex = data.FindIndex(n => n.Name == parentKey);
                var parent = data[parentIndex];

                foreach (var childKey in kvp.Value)
                {
                    var childIndex = data.FindIndex(n => n.Name == childKey);
                    var child = data[childIndex];
                    child.Parent = parent;
                }
            }

            return from d in data group d by d.Parent into fam select fam;
        }

        private class Node
        {
            public string Name { get; set; }

            public int Weight { get; set; }

            public Node Parent { get; set; }
        }

        private static IEnumerable<string> GetBottomProgram(IEnumerable<ProgramyThing> data)
        {
            var programs = data.ToList();

            var a = programs.Select(x => x.Name);
            var b = programs.SelectMany(y => y.Subs);

            return a.Except(b);
        }

        private static string GetBottomProgramRec(IEnumerable<ProgramyThing> data, string programToLookup = null)
        {
            var progs = data.ToList();

            if (string.IsNullOrEmpty(programToLookup))
                programToLookup = progs.Where(x => x.Subs.Any()).Select(y => y.Name).First();

            var thisProg = progs.FirstOrDefault(p => p.Subs.Contains(programToLookup));

            return thisProg != null ? GetBottomProgramRec(progs, thisProg.Name) : programToLookup;
        }

        private class ProgramyThing
        {
            public string Name { get; set; }

            public int Weight { get; set; }

            public IEnumerable<string> Subs { get; set; }

            public ProgramyThing()
            {
                Subs = new List<string>();
            }
        }

        private void Foo()
        {

        }
    }
}