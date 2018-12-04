namespace AdventOfCode2018
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class Day03
    {
        private const int One = 1;

        private const string Conflict = "x";

        public class Claim
        {
            public static Claim Create(string claimData)
            {
                const string claimRegex = @"#(?<id>\d+)[\t\s]+@[\t\s]+(?<widthOffset>\d+),(?<heightOffset>\d+):[\t\s]+(?<width>\d+)x(?<height>\d+)";
                var match = Regex.Match(claimData, claimRegex);

                if (!match.Success)
                    throw new ArgumentException($"Invalid claim data: {claimData}");

                var id = match.Groups["id"].Value;
                var widthOffset = int.Parse(match.Groups["widthOffset"].Value);
                var heightOffset = int.Parse(match.Groups["heightOffset"].Value);
                var width = int.Parse(match.Groups["width"].Value);
                var height = int.Parse(match.Groups["height"].Value);

                return new Claim(id, widthOffset, heightOffset, width, height);
            }

            private Claim(string id, int widthOffset, int heightOffset, int width, int height)
            {
                Id = id;
                WidthOffset = widthOffset;
                HeightOffset = heightOffset;
                Width = width;
                Height = height;
            }

            public string Id { get; }
            public int WidthOffset { get; }
            public int HeightOffset { get; }
            public int Width { get; }
            public int Height { get; }
        }

        /*public static string[,] ApplyClaimToFabric(string[,] map, Claim claim)
        {
            var finalWidth = claim.WidthOffset + claim.Width;
            var finalHeight = claim.HeightOffset + claim.Height;

            for (var i = claim.HeightOffset + One; i <= finalHeight; i++)
            for (var j = claim.WidthOffset + One; j <= finalWidth; j++)
            {
                map[i, j] = map[i, j] == null ? claim.Id : Conflict;
            }

            return map;
        }*/

        public static Tuple<string[,], HashSet<string>> ApplyClaimToFabric(string[,] map, Claim claim, HashSet<string> cleanClaims)
        {
            var finalWidth = claim.WidthOffset + claim.Width;
            var finalHeight = claim.HeightOffset + claim.Height;

            for (var i = claim.HeightOffset + One; i <= finalHeight; i++)
            for (var j = claim.WidthOffset + One; j <= finalWidth; j++)
            {
                if (map[i,j] == null)
                {
                    map[i, j] = claim.Id;
                }
                else
                {
                    var current = map[i, j];
                    map[i, j] = Conflict;

                    if (current != Conflict && cleanClaims.Contains(current))
                        cleanClaims.Remove(current);

                    if (cleanClaims.Contains(claim.Id))
                        cleanClaims.Remove(claim.Id);
                }
            }

            return Tuple.Create(map, cleanClaims);
        }

        public static Tuple<int, HashSet<string>> GetNumberOfConflictsAndRemainingCleanClaims(string path, int fabricSize)
        {
            var fabric = new string[fabricSize, fabricSize];
            var claims = File.ReadAllLines(path).Select(Claim.Create).ToList();
            var cleanClaims = claims.Select(c => c.Id).ToHashSet();

            foreach (var claim in claims)
            {
                var result = ApplyClaimToFabric(fabric, claim, cleanClaims);
                fabric = result.Item1;
                cleanClaims = result.Item2;
            }

            var count = fabric.Cast<string>().ToArray().Count(s => s == Conflict);

            return Tuple.Create(count, cleanClaims);
        }
    }
}
