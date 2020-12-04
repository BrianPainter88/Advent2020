using Advent2020.Business.Interfaces;

namespace Advent2020.Business.Days
{
    public class DayBase
    {
        protected readonly IResources _adventResources;

        public DayBase(IResources adventResources)
        {
            _adventResources = adventResources;
        }
    }
}
