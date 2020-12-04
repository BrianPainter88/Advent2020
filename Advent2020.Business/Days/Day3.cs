using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2020.Business.Interfaces;

namespace Advent2020.Business.Days
{
    public class Day3 : DayBase
    {
        private const int _lateralMoves = 3;
        private const int _verticalMoves = 1;
        private const string _treeCharacter = "#";

        public Day3(IResources adventResources) : base(adventResources)
        {
        }

        public int GetPart1Answer()
        {
            var data = _adventResources.GetDay3Resources();
            var parsedData = Parse(data);

            var characters = TraverseThroughArray(parsedData, _lateralMoves, _verticalMoves);

            return characters.Count(c => c.Equals(_treeCharacter));
        }

        public IEnumerable<string> TraverseThroughArray(string[][] data, int lateralMoves, int verticalMoves)
        {
            var segmentWidth = 0;

            if (data.Length > 0)
            {
                segmentWidth = data[0].Count();
            }

            var characterList = new List<string>();

            for (
                int currentRowIndex = verticalMoves, currentColumnIndex = lateralMoves;
                currentRowIndex < data.Length;
                currentRowIndex += verticalMoves, currentColumnIndex = (currentColumnIndex + lateralMoves) % (segmentWidth)
            )
            {
                characterList.Add(data[currentRowIndex][currentColumnIndex]);
            }

            return characterList;
        }

        public string[][] Parse(IEnumerable<string> data)
        {
            return data.Select(r => r.Select(c => c.ToString()).ToArray()).ToArray();
        }
    }
}
