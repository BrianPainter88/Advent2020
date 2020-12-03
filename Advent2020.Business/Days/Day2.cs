using System;
using System.IO;
using System.Linq;
using Advent2020.Business.Interfaces;
using Advent2020.Business.Models;

namespace Advent2020.Business.Days
{
    public class Day2
    {
        private const int _expectedParts = 4;

        private readonly IResources _resources;

        public Day2(IResources resources)
        {
            _resources = resources;
        }

        public int GetAnswer()
        {
            var resources = _resources.GetDay2Resources();

            var parsedResources = resources.Select(Parse);

            return parsedResources.Count(IsPasswordValid);
        }
        
        public PasswordParts Parse(string parsableString)
        {
            var stringParts = parsableString.Split(new[] {"-", " ", ":"}, StringSplitOptions.RemoveEmptyEntries);

            if (stringParts.Length == _expectedParts)
            {
                return new PasswordParts
                {
                    FirstPosition = int.TryParse(stringParts[0], out var firstPosition) ? firstPosition : 0,
                    SecondPosition = int.TryParse(stringParts[1], out var secondPosition) ? secondPosition : 0,
                    StringToSearchFor = stringParts[2],
                    StringToBeSearched = stringParts[3]
                };
            }

            throw new InvalidDataException($"The string `{parsableString}` is in an incorrect format.  Received `{stringParts.Length}` parts, but expected `{_expectedParts}`.");
        }

        public bool IsPasswordValid(PasswordParts passwordParts)
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
