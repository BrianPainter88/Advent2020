﻿using System;
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
                WriteAnswerToConsole("Day1 (Part1)", part1Answer, ConsoleColor.DarkGreen);

                var part2Answer = day1.GetPart2Answer(2020);
                WriteAnswerToConsole("Day1 (Part2)", part2Answer, ConsoleColor.DarkRed);
            }
            else if(dayNumber == 2)
            {
                var day2 = new Day2(adventResources);

                var part1Answer = day2.GetPart1Answer();
                WriteAnswerToConsole("Day2 (Part1)", part1Answer, ConsoleColor.DarkGreen);

                var part2Answer = day2.GetPart2Answer();
                WriteAnswerToConsole("Day2 (Part2)", part2Answer, ConsoleColor.DarkRed);
            }
            else if (dayNumber == 3)
            {
                var day3 = new Day3(adventResources);

                var part1Answer = day3.GetPart1Answer();
                WriteAnswerToConsole("Day3 (Part1)", part1Answer, ConsoleColor.DarkGreen);

                var part2Answer = day3.GetPart2Answer();
                WriteAnswerToConsole("Day3 (Part2)", part2Answer, ConsoleColor.DarkRed);
            }
            else if (dayNumber == 4)
            {
                var day4 = new Day4(adventResources);

                var part1Answer = day4.GetPart1Answer();
                WriteAnswerToConsole("Day4 (Part1)", part1Answer, ConsoleColor.DarkGreen);

                var part2Answer = day4.GetPart2Answer();
                WriteAnswerToConsole("Day4 (Part2)", part2Answer, ConsoleColor.DarkRed);
            }
            else if (dayNumber == 5)
            {
                var day5 = new Day5(adventResources);

                var part1Answer = day5.GetPart1Answer();
                WriteAnswerToConsole("Day5 (Part1)", part1Answer, ConsoleColor.DarkGreen);

                var part2Answer = day5.GetPart2Answer();
                WriteAnswerToConsole("Day5 (Part2)", part2Answer, ConsoleColor.DarkRed);
            }
            else if (dayNumber == 6)
            {
                var day6 = new Day6(adventResources);

                var part1Answer = day6.GetPart1Answer();
                WriteAnswerToConsole("Day6 (Part1)", part1Answer, ConsoleColor.DarkGreen);

                var part2Answer = day6.GetPart2Answer();
                WriteAnswerToConsole("Day6 (Part2)", part2Answer, ConsoleColor.DarkRed);
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
