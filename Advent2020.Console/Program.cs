using System;
using Advent2020.Business;

namespace Advent2020.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var day1Resources = new AdventResources();
            var day1 = new Day1(day1Resources);

            var part1Answer = day1.GetPart1Answer(2020);
            WriteToConsole($"Day1 : Part1 = {part1Answer}", ConsoleColor.DarkMagenta);

            var part2Answer = day1.GetPart2Answer(2020);
            WriteToConsole($"Day1 : Part2 = {part2Answer}", ConsoleColor.Green);
        }

        private static void WriteToConsole(object message, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
