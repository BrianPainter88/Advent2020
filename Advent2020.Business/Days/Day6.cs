using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2020.Business.Interfaces;

namespace Advent2020.Business.Days
{
    public class Day6 : DayBase
    {
        public Day6(IResources adventResources) : base(adventResources)
        {
        }

        public int GetPart1Answer()
        {
            var groupings = GetGroupings();

            return groupings
                .SelectMany(g => (g.Answers ?? Array.Empty<string>()).Distinct())
                .Count();
        }

        public int GetPart2Answer()
        {
            var groupings = GetGroupings();

            return
                groupings
                    .Select(g =>
                        new {
                            g.GroupMembers,
                            Answers =
                                g.Answers
                                    .GroupBy(a => a)
                                    .Select(a => new {a.Key, Count = a.Count() })
                        })
                    .Sum(g => g.Answers.Count(a => a.Count == g.GroupMembers));
        }

        public IEnumerable<(int GroupMembers, string[] Answers)> GetGroupings()
        {
            var resources = _adventResources.GetDay6Resources();

            var mainList = new List<(int GroupMembers, string[] Answers)>();
            var records = new string[] { };
            var groupMembers = 0;

            foreach (var line in resources)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    mainList.Add((groupMembers, records));
                    records = Array.Empty<string>();
                    groupMembers = 0;
                    continue;
                }

                groupMembers++;
                records = records.Concat(line.Select(l => l.ToString())).ToArray();
            }
            mainList.Add((groupMembers, records));

            return mainList;
        }
    }
}
