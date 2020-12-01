namespace AdventOfCode2020
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var inputPath = @"C:\src\AdventOfCode\AdventOfCode2020\input\day01.input";

            var list = File.ReadAllLines(inputPath).Select(line => int.Parse(line)).ToList();

            var result = (from int i in list
                          from int j in list
                          where i + j == 2020
                          select i * j).Distinct().First();

            var result2 = (from int i in list
                           from int j in list
                           from int k in list
                           where i + j + k == 2020
                           select i * j * k).Distinct().First();
        }
    } 
}