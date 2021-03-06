﻿namespace AdventOfCode2020
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DAY 1");
            Console.WriteLine("Part 1: " + Day01.GetPart1Result());
            Console.WriteLine("Part 2: " + Day01.GetPart2Result());
            
            Console.WriteLine("DAY 2");
            Console.WriteLine("Part 1: " + Day02.GetPart1Result);
            Console.WriteLine("Part 2: " + Day02.GetPart2Result);

            Console.WriteLine("DAY 3");
            Console.WriteLine("Part 1: " + Day03.GetPart1Result());
            Console.WriteLine("Part 2: " + Day03.GetPart2Result());

            Console.WriteLine("DAY 4");
            Console.WriteLine("Part 1: " + Day04.GetPart1Result());
            Console.WriteLine("Part 2: " + Day04.GetPart2Result());

            Console.WriteLine("DAY 5");
            Console.WriteLine("Part 1: TODO"); //+ Day05.GetPart1Result());
            Console.WriteLine("Part 2: TODO"); //+ Day05.GetPart2Result());

            Console.WriteLine("DAY 6");
            Console.WriteLine("Part 1: " + Day06.GetPart1Result());
            Console.WriteLine("Part 2: " + Day06.GetPart2Result());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    } 
}