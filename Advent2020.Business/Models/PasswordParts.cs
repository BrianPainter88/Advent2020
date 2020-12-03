namespace Advent2020.Business.Models
{
    public class PasswordParts
    {
        public int MinimumCount { get; set; }
        public int MaximumCount { get; set; }
        public int FirstPosition { get; set; }
        public int SecondPosition { get; set; }
        public string StringToSearchFor { get; set; }
        public string StringToBeSearched { get; set; }
        public int FirstPositionIndex => GetFirstPositionIndex();
        public int SecondPositionIndex => GetSecondPositionIndex();

        private int GetFirstPositionIndex()
        {
            return FirstPosition - 1;
        }

        private int GetSecondPositionIndex()
        {
            return SecondPosition - 1;
        }
    }
}