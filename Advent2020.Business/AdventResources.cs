using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public IEnumerable<string> GetDay3Resources()
        {
            return Resources.Day3.Split(Environment.NewLine);
        }

        public IEnumerable<IDictionary<string, string>> GetDay4Resources()
        {
            var lines = Resources.Day4.Split(Environment.NewLine);

            var rows = Regex.Split(string.Join(" ", lines), @"\s{2}").ToArray();;

            return
                rows
                    .Select(r =>
                        r.Split(" ")
                            .Select(r => r.Split(":"))
                            .ToDictionary(k => k[0], v => v[1])
                    );
        }

        public IEnumerable<string> GetDay5Resources()
        {
            return Resources.Day5.Split(Environment.NewLine);
        }
    }
}
