using System;
using System.Collections.Generic;
using Advent2020.Business;
using Advent2020.Business.Interfaces;
using Moq;
using NUnit.Framework;

namespace Advent2020.Tests
{
    public class Day1Tests
    {
        private Day1 _day1;
        private Mock<IResources> _resourcesMock;

        [SetUp]
        public void Setup()
        {
            _resourcesMock = new Mock<IResources>();
            _day1 = new Day1(_resourcesMock.Object);
        }

        [TestCase(10, new []{ 2, 4, 6 })]
        [TestCase(123, new[] { 8, 33, 122, 14, 53, 87, 71, 11, 70, 202, 100 })]
        public void GetPairToEqualValue_ReturnsPairThatEqualsValueToEqual(int valueToEqual, IEnumerable<int> valueSet)
        {
            _resourcesMock
                .Setup(r => r.GetDay1Resources())
                .Returns(valueSet);

            var (firstNumber, secondNumber) = _day1.GetPairToEqualValue(valueToEqual, valueSet);

            Console.WriteLine($@"First Number: {firstNumber}");
            Console.WriteLine($@"Second Number: {secondNumber}");
            Assert.That(firstNumber + secondNumber, Is.EqualTo(valueToEqual));
        }

        [TestCase(24, 10, new[] { 2, 4, 6 })]
        [TestCase(3710, 123, new[] { 8, 33, 122, 14, 53, 87, 71, 11, 70, 202, 100 })]
        public void GetPart1Answer_ReturnsPairThatEqualsValueToEqual(int expected, int valueToEqual, IEnumerable<int> valueSet)
        {
            _resourcesMock
                .Setup(r => r.GetDay1Resources())
                .Returns(valueSet);

            var result = _day1.GetPart1Answer(valueToEqual);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(14, new[] { 1, 2, 4, 8, 16 })]
        [TestCase(123, new[] { 8, 33, 122, 14, 53, 87,37, 71, 11, 70, 202, 100 })]
        public void GetTrioToEqualValue_ReturnsTrioThatEqualsValueToEqual(int valueToEqual, IEnumerable<int> valueSet)
        {
            _resourcesMock
                .Setup(r => r.GetDay1Resources())
                .Returns(valueSet);

            var (firstNumber, secondNumber, thirdNumber) = _day1.GetTrioToEqualValue(valueToEqual, valueSet);

            Console.WriteLine($@"First Number: {firstNumber}");
            Console.WriteLine($@"Second Number: {secondNumber}");
            Console.WriteLine($@"Third Number: {secondNumber}");
            Assert.That(firstNumber + secondNumber + thirdNumber, Is.EqualTo(valueToEqual));
        }

        [TestCase(64, 14, new[] { 1, 2, 4, 8, 16 })]
        [TestCase(64713, 123, new[] { 8, 33, 122, 14, 53, 87, 37, 71, 11, 70, 202, 100 })]
        public void GetPart2Answer_ReturnsTrioThatEqualsValueToEqual(int expected, int valueToEqual, IEnumerable<int> valueSet)
        {
            _resourcesMock
                .Setup(r => r.GetDay1Resources())
                .Returns(valueSet);

            var result = _day1.GetPart2Answer(valueToEqual);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}