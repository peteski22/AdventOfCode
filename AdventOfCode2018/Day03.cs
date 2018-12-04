namespace AdventOfCode2018
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class Day03
    {
        private const int One = 1;

        public class Claim
        {
            public static Claim Create(string claimData)
            {
                const string claimRegex = @"#(?<id>\d+)[\t\s]@[\t\s](?<widthOffset>\d+),(?<heightOffset>\d+):[\t\s](?<width>\d+)x(?<height>\d+)";
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

        public static string[,] ApplyClaimToFabric(string[,] map, Claim claim)
        {
            const string conflict = "x";
            var finalWidth = claim.WidthOffset + claim.Width;
            var finalHeight = claim.HeightOffset + claim.Height;

            for (var i = claim.HeightOffset + One; i <= finalHeight; i++)
            for (var j = claim.WidthOffset + One; j <= finalWidth; j++)
            {
                map[i, j] = map[i, j] != null && map[i, j] != conflict ? conflict : claim.Id;
            }

            return map;
        }

        public static int GetNumberOfConflicts(string path)
        {
            const int fabricSize = 1000;

            var fabric = new string[fabricSize, fabricSize];
            var claims = File.ReadAllLines(path).Select(Claim.Create);

            fabric = claims.Aggregate(fabric, ApplyClaimToFabric);

            var count = fabric.Cast<string>().ToArray().Count(s => s == "x");

            return count;
        }
    }
}
