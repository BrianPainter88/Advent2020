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
                    MinimumCount = int.TryParse(stringParts[0], out var minimumCount) ? minimumCount : 0,
                    MaximumCount = int.TryParse(stringParts[1], out var maximumCount) ? maximumCount : 0,
                    StringToSearchFor = stringParts[2],
                    StringToBeSearched = stringParts[3]
                };
            }

            throw new InvalidDataException($"The string `{parsableString}` is in an incorrect format.  Received `{stringParts.Length}` parts, but expected `{_expectedParts}`.");
        }


        public bool IsPasswordValid(PasswordParts passwordParts)
        {
            var characterCount = passwordParts.StringToBeSearched.Count(s => s.ToString().Equals(passwordParts.StringToSearchFor));

            return
                characterCount >= passwordParts.MinimumCount
                && characterCount <= passwordParts.MaximumCount;
        }
    }
}
