using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2020.Business.Interfaces;

namespace Advent2020.Business.Days
{
    public class Day4 : DayBase
    {
        private static readonly string[] _requiredFields = {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };

        public Day4(IResources adventResources) : base(adventResources)
        {
        }

        public int GetPart1Answer()
        {
            return
                _adventResources
                    .GetDay4Resources()
                    .Select(s => s.Keys.ToArray())
                    .Count(HasAllRequiredFields);
        }

        public bool HasAllRequiredFields(string[] fields)
        {
            return false == _requiredFields.Except(fields).Any();
        }
    }
}
