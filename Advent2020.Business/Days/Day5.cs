using System;
using System.Collections.Generic;
using System.Linq;
using Advent2020.Business.Interfaces;
using Advent2020.Business.Models;

namespace Advent2020.Business.Days
{
    public class Day5 : DayBase
    {
        private static readonly string[] _charactersForUpper = new[] {"B","R"};

        public Day5(IResources adventResources) : base(adventResources)
        {
        }

        public int GetPart1Answer()
        {
            var highestSeatId = 0;

            foreach (var pattern in _adventResources.GetDay5Resources())
            {
                var rowId = GetRowIdFromPattern(pattern);
                var columnId = GetColumnIdFromPattern(pattern);

                var seatId = rowId * 8 + columnId;

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }

            return highestSeatId;
        }

        public int GetPart2Answer()
        {
            var seatList = new List<int>();
            foreach (var pattern in _adventResources.GetDay5Resources())
            {
                var rowId = GetRowIdFromPattern(pattern);
                var columnId = GetColumnIdFromPattern(pattern);

                var seatId = rowId * 8 + columnId;
                seatList.Add(seatId);
            }

            var seatRange = Enumerable.Range(seatList.Min(), seatList.Count());
            return seatRange.Except(seatList).Single();
        }

        public int GetRowIdFromPattern(string pattern)
        {
            var range = new SeatingRange(0, 127);
            var rowPattern = GetRowPattern(pattern);

            var characterArray = rowPattern.ToCharArray();

            range = characterArray
                .Select(ShouldTakeUpper)
                .Aggregate(range, GetRange);

            return ShouldTakeUpper(characterArray.Last())
                ? range.Max
                : range.Min;
        }

        public int GetColumnIdFromPattern(string pattern)
        {
            var range = new SeatingRange(0, 7);
            var columnPattern = GetColumnPattern(pattern);

            var characterArray = columnPattern.ToCharArray();

            range = characterArray
                .Select(ShouldTakeUpper)
                .Aggregate(range, GetRange);

            return ShouldTakeUpper(characterArray.Last())
                ? range.Max
                : range.Min;
        }

        public string GetRowPattern(string pattern)
        {
            return pattern.Substring(0, 7);
        }

        public string GetColumnPattern(string pattern)
        {
            return pattern.Substring(7, 3);
        }

        public SeatingRange GetRange(SeatingRange range, bool shouldTakeUpper)
        {
            var difference = range.Max - range.Min;
            var half = difference >> 1;
            var adjustment = range.Min + half;

            return shouldTakeUpper
                ? new SeatingRange(adjustment + 1, range.Max)
                : new SeatingRange(range.Min, adjustment);
        }

        public bool ShouldTakeUpper(char character)
        {
            return _charactersForUpper.Contains(character.ToString(), StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
