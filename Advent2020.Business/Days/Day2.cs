using System;
using System.IO;
using System.Linq;
using Advent2020.Business.Interfaces;
using Advent2020.Business.Models;

namespace Advent2020.Business.Days
{
    public class Day2 : DayBase
    {
        private const int _expectedParts = 4;

        public Day2(IResources resources) : base(resources)
        {
        }

        public object GetPart1Answer()
        {
            var resources = _adventResources.GetDay2Resources();

            var parsedResources = resources.Select(Parse);

            return parsedResources.Count(IsPart1PasswordValid);
        }

        public int GetPart2Answer()
        {
            var resources = _adventResources.GetDay2Resources();

            var parsedResources = resources.Select(Parse);

            return parsedResources.Count(IsPart2PasswordValid);
        }
        
        public PasswordParts Parse(string parsableString)
        {
            var stringParts = parsableString.Split(new[] {"-", " ", ":"}, StringSplitOptions.RemoveEmptyEntries);

            if (stringParts.Length == _expectedParts)
            {
                return new PasswordParts
                {
                    MinimumCount = int.TryParse(stringParts[0], out var minimumCount) ? minimumCount : 0,
                    MaximumCount = int.TryParse(stringParts[1], out var maximumCount) ? maximumCount : 0,
                    FirstPosition = int.TryParse(stringParts[0], out var firstPosition) ? firstPosition : 0,
                    SecondPosition = int.TryParse(stringParts[1], out var secondPosition) ? secondPosition : 0,
                    StringToSearchFor = stringParts[2],
                    StringToBeSearched = stringParts[3]
                };
            }

            throw new InvalidDataException($"The string `{parsableString}` is in an incorrect format.  Received `{stringParts.Length}` parts, but expected `{_expectedParts}`.");
        }

        public bool IsPart1PasswordValid(PasswordParts passwordParts)
        {
            var characterCount = passwordParts.StringToBeSearched.Count(s => s.ToString().Equals(passwordParts.StringToSearchFor));

            return
                characterCount >= passwordParts.MinimumCount
                && characterCount <= passwordParts.MaximumCount;
        }

        public bool IsPart2PasswordValid(PasswordParts passwordParts)
        {
            var sequenceToCheckAgainst = 
                passwordParts.StringToBeSearched
                    .Select((Letter, Index) => new { Letter = Letter.ToString(), Index })
                    .Where(x => x.Letter == passwordParts.StringToSearchFor)
                    .Select(x => x.Index)
                    .OrderBy(x => x)
                    .ToArray();

            var sequenceToCheckFor = new int[] {passwordParts.FirstPositionIndex, passwordParts.SecondPositionIndex};

            return sequenceToCheckFor.Except(sequenceToCheckAgainst).Count() == 1;
        }
    }
}
