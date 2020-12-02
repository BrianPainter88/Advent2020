using System.Collections.Generic;
using System.Linq;
using Advent2020.Business.Interfaces;

namespace Advent2020.Business
{
    public class Day1
    {
        private readonly IResources _resources;

        public Day1(IResources resources)
        {
            _resources = resources;
        }

        public int GetPart1Answer(int numberToEqual)
        {
            var values = _resources.GetDay1Resources();

            var (firstNumber, secondNumber) = GetPairToEqualValue(numberToEqual, values);

            return firstNumber * secondNumber;
        }

        public int GetPart2Answer(int numberToEqual)
        {
            var values = _resources.GetDay1Resources();

            var (firstNumber, secondNumber, thirdNumber) = GetTrioToEqualValue(numberToEqual, values);

            return firstNumber * secondNumber * thirdNumber;
        }

        public (int firstNumber, int secondNumber) GetPairToEqualValue(int valueToEqual, IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                var leftover = valueToEqual - value;

                if (values.Except(new [] { value }).Contains(leftover))
                {
                    return (leftover, value);
                }
            }

            return (0, 0);
        }

        public (int firstNumber, int secondNumber, int thirdNumber) GetTrioToEqualValue(int valueToEqual, IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                var initialLeftover = valueToEqual - value;
                var finalPair = GetPairToEqualValue(initialLeftover, values.Except(new []{ value }));

                if (finalPair != (0, 0))
                {
                    return (value, finalPair.firstNumber, finalPair.secondNumber);
                }
            }

            return (0, 0, 0);
        }
    }
}
