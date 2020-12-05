namespace AdventOfCode2020
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day04
    {
        private static readonly string inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day04.input";

        private static readonly List<RequiredProperty> requiredProperties = new List<RequiredProperty>
        {
            new RequiredProperty("byr", new Regex(@"^(19[2-8][0-9]|199[0-9]|200[0-2])$")),
            new RequiredProperty("iyr", new Regex(@"^(201[0-9]|2020)$")),
            new RequiredProperty("eyr", new Regex(@"^(202[0-9]|2030)$")),
            new RequiredProperty("hgt", new Regex(@"^((1[5-8][0-9]|19[0-3])cm|(59|6[0-9]|7[0-6])in)$")),
            new RequiredProperty("hcl", new Regex(@"^#[0-9a-fA-F]{6}$")),
            new RequiredProperty("ecl", new Regex(@"^(amb|blu|brn|gry|grn|hzl|oth)$")),
            new RequiredProperty("pid", new Regex(@"^\d{9}$")),
        };

        public static int GetPart1Result()
        {
            return GetEntries(inputPath)
                    .Count(d => requiredProperties.Select(x => x.Name)
                    .All(p => d.ContainsKey(p)));
        }

        public static int GetPart2Result()
        {
            var present = GetEntries(inputPath)
                            .Where(d => requiredProperties.Select(x => x.Name).All(p => d.ContainsKey(p)));

            var valid = present.Where(d => d.Select(kvp => new { kvp.Value, requiredProperties.Where(prop => prop.Name == kvp.Key).FirstOrDefault()?.Rule }).All(validation => validation.Rule != null && validation.Rule.IsMatch(validation.Value)));
            
            return valid.Count();
        }

        private static IEnumerable<Dictionary<string, string>> GetEntries(string path)
        {
            return from block in Regex.Split(File.ReadAllText(path), "\r\n\r\n")
                   select new Dictionary<string, string>(from line in block.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                                                         from kvp in line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                         let bits = kvp.Split(":")
                                                         let key = bits[0]
                                                         let value = bits[1]
                                                         select new KeyValuePair<string, string>(key, value), StringComparer.OrdinalIgnoreCase);
        }

        private class RequiredProperty
        {
            public RequiredProperty(string name, Regex rule)
            {
                Name = name;
                Rule = rule;
            }

            public string Name { get; private set; }

            public Regex Rule { get; private set; }
        }
    }
}