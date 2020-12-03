using System;
using Advent2020.Business;
using Advent2020.Business.Days;

namespace Advent2020.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var adventResources = new AdventResources();

            Console.Write(@"What day would you like to execute?: ");
            int.TryParse(Console.ReadLine(), out var dayNumber);

            if (dayNumber == 1)
            {
                var day1 = new Day1(adventResources);

                var part1Answer = day1.GetPart1Answer(2020);
                WriteAnswerToConsole("Day1 (Part1)", part1Answer, ConsoleColor.DarkMagenta);

                var part2Answer = day1.GetPart2Answer(2020);
                WriteAnswerToConsole("Day1 (Part2)", part2Answer, ConsoleColor.Green);
            }
            else if(dayNumber == 2)
            {
                var day2 = new Day2(adventResources);

                var part1Answer = day2.GetPart1Answer();
                WriteAnswerToConsole("Day2 (Part1)", part1Answer, ConsoleColor.Red);

                var part2Answer = day2.GetPart2Answer();
                WriteAnswerToConsole("Day2 (Part2)", part2Answer, ConsoleColor.Blue);
            }
        }

        private static void WriteAnswerToConsole(string label, object message, ConsoleColor foregroundColor)
        {
            var fullMessage = $"{(false == string.IsNullOrEmpty(label) ? $"{label}: " : string.Empty)}{message}";

            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(fullMessage);
            Console.ResetColor();
        }
    }
}
