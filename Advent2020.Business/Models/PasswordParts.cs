namespace Advent2020.Business.Models
{
    public class PasswordParts
    {
        public int MinimumCount { get; set; }
        public int MaximumCount { get; set; }
        public string StringToSearchFor { get; set; }
        public string StringToBeSearched { get; set; }
    }
}