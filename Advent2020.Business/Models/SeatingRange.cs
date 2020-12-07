namespace Advent2020.Business.Models
{
    public class SeatingRange
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public SeatingRange(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
