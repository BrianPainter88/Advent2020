using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        private static readonly string[] _validColors =
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
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

        public int GetPart2Answer()
        {
            return
                _adventResources
                    .GetDay4Resources()
                    .Count(IsValidData);
        }

        public bool HasAllRequiredFields(string[] fields)
        {
            return false == _requiredFields.Except(fields).Any();
        }

        public bool IsValidData(IDictionary<string, string> data)
        {
             Console.WriteLine($@"Debug: {string.Join(" ", data.Select(d => $"{d.Key}:{d.Value}").ToArray())}");

            var hasAllRequiredFields = HasAllRequiredFields(data.Keys.ToArray());

            if (false == hasAllRequiredFields)
            {
                Console.WriteLine($@"   Failed Requirement validation: hasAllRequiredFields({hasAllRequiredFields})");
            }

            if (hasAllRequiredFields)
            {
                return
                    ValidateYear(data["byr"], 4, 1920, 2002)
                    && ValidateYear(data["iyr"], 4, 2010, 2020)
                    && ValidateYear(data["eyr"], 4, 2020, 2030)
                    && ValidateHeight(data["hgt"])
                    && ValidateHairColor(data["hcl"])
                    && ValidateEyeColor(data["ecl"])
                    && ValidatePassportId(data["pid"]);
            }

            return false;
        }

        public bool ValidateYear(string year, int digitCount, int minimumYear, int maximumYear)
        {
            if (int.TryParse(year, out var convertedYear))
            {
                var result =
                    year.Length == 4
                    && convertedYear >= minimumYear
                    && convertedYear <= maximumYear;

                if (false == result)
                {
                    Console.WriteLine($@"   Failed Year validation: {convertedYear}, length({year.Length}), min({minimumYear}), max({maximumYear})");
                }

                return result;
            }

            return false;
        }

        public bool ValidateHeight(string height)
        {
            var match = Regex.Match(height.Trim(), @"^(\d{1,})(in|cm)$");

            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, out int parsedValue);
                var unit = match.Groups[2].Value;

                switch (unit)
                {
                    case "cm":
                        return ValidateSize(parsedValue, 150, 193);
                    case "in":
                        return ValidateSize(parsedValue, 59, 76);
                }
            }
            else
            {
                Console.WriteLine($@"   Failed Height validation: {height}");
            }

            return false;
        }

        private bool ValidateSize(int size, int minimumSize, int maximumSize)
        {
            var result =
                size >= minimumSize
                && size <= maximumSize;

            if (false == result)
            {
                Console.WriteLine($@"   Failed Size validation: {size}, min({minimumSize}), max({maximumSize})");
            }

            return result;
        }

        public bool ValidateHairColor(string color)
        {
            var result = Regex.IsMatch(color.Trim(), @"^#[0-9A-Fa-f]{6}$");

            if (false == result)
            {
                Console.WriteLine($@"   Failed Hair Color validation: {color.Trim()}");
            }

            return result;
        }

        public bool ValidateEyeColor(string color)
        {
            var result = _validColors.Contains(color.Trim());

            if (false == result)
            {
                Console.WriteLine($@"   Failed Eye Color validation: {color.Trim()}");
            }

            return result;
        }

        public bool ValidatePassportId(string passportId)
        {
            var result = Regex.IsMatch(passportId.Trim(), @"^\d{9}$");

            if (false == result)
            {
                Console.WriteLine($@"   Failed PassportId validation: {passportId.Trim()}");
            }

            return result;
        }
    }
}
