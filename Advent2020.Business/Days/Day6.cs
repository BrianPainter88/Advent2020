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
                .SelectMany(g => g.Distinct())
                .Count();
        }

        public IEnumerable<string[]> GetGroupings()
        {
            var resources = _adventResources.GetDay6Resources();

            var mainList = new List<string[]>();
            var records = new string[] { };

            foreach (var line in resources)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    mainList.Add(records);
                    records = Array.Empty<string>();
                    continue;
                }

                records = records.Concat(line.Select(l => l.ToString())).ToArray();
            }
            mainList.Add(records);

            return mainList;
        }
    }
}
