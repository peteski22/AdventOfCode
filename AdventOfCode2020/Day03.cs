namespace AdventOfCode2020
{
    using System.IO;
    using System.Linq;

    public class Day03
    {
        private static readonly string inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day03.input";

        private static readonly char[][] map = File.ReadAllLines(inputPath).Select(line => line.Select(c => c).ToArray()).ToArray();
        
        public static int GetPart1Result()
        {
            return GetTrees(1, 3);
        }

        public static int GetPart2Result()
        {
            var slopes = new[] 
            {
                (h: 1, v: 1),
                (h: 3, v: 1), 
                (h: 5, v: 1) ,
                (h: 7, v: 1),
                (h: 1, v: 2)
            };

            return slopes.Select(s => GetTrees(s.v, s.h)).Aggregate((x, y) => x * y);
        }

        private static int GetTrees(int verticalStep, int horizontalStep)
        {
            var mapHeight = map.GetLength(0);
            var mapWidth = map[0].GetLength(0);
            var horizontalIndex = 0;
            var verticalIndex = 0;
            var trees = 0;            

            while (verticalIndex < mapHeight)
            {
                if (map[verticalIndex][horizontalIndex] == '#')
                    trees++;

                verticalIndex += verticalStep;
                horizontalIndex = (horizontalIndex + horizontalStep) % mapWidth;
            }

            return trees;
        }
    }
}
