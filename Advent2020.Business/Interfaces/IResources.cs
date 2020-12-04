using System.Collections.Generic;

namespace Advent2020.Business.Interfaces
{
    public interface IResources
    {
        IEnumerable<int> GetDay1Resources();
        IEnumerable<string> GetDay2Resources();
        IEnumerable<string> GetDay3Resources();
        IEnumerable<IDictionary<string, string>> GetDay4Resources();
    }
}
