using System;
using System.Collections.Generic;
using System.Linq;
using Advent2020.Business.Interfaces;

namespace Advent2020.Business
{
    public class AdventResources : IResources
    {
        public IEnumerable<int> GetDay1Resources()
        {
            return
                Resources.Day1.Split(Environment.NewLine)?
                    .Where(v => int.TryParse(v, out _))
                    .Select(int.Parse);
        }

        public IEnumerable<string> GetDay2Resources()
        {
            return Resources.Day2.Split(Environment.NewLine);
        }
    }
}
