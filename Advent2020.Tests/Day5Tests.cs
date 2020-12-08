using System;
using System.Collections.Generic;
using System.Text;
using Advent2020.Business.Days;
using Advent2020.Business.Interfaces;
using Moq;
using NUnit.Framework;

namespace Advent2020.Tests
{
    public class Day5Tests
    {
        private Mock<IResources> _adventResourcesMock;
        private Day5 _day5;

        [SetUp]
        public void Setup()
        {
            _adventResourcesMock = new Mock<IResources>();
            _day5 = new Day5(_adventResourcesMock.Object);
        }

        [TestCase('b')]
        [TestCase('B')]
        [TestCase('r')]
        [TestCase('R')]
        public void ShouldTakeUpper_GivenValidUppers_ReturnsTrue(char testCharacter)
        {
            Assert.True(_day5.ShouldTakeUpper(testCharacter));
        }

        [TestCase('f')]
        [TestCase('F')]
        [TestCase('l')]
        [TestCase('L')]
        public void ShouldTakeUpper_GivenValidLowers_ReturnsFalse(char testCharacter)
        {
            Assert.False(_day5.ShouldTakeUpper(testCharacter));
        }

        [TestCase("FBFBBFFRLR", 44)]
        [TestCase("BFFFBBFRRR", 70)]
        [TestCase("FFFBBBFRRR", 14)]
        [TestCase("BBFFBBFRLL", 102)]
        public void GetRowIdFromPattern_GivenPattern_ShouldReturnRowId(string pattern, int expected)
        {
            Assert.That(_day5.GetRowIdFromPattern(pattern), Is.EqualTo(expected));
        }

        [TestCase("FBFBBFFRLR", 5)]
        [TestCase("BFFFBBFRRR", 7)]
        [TestCase("FFFBBBFRRR", 7)]
        [TestCase("BBFFBBFRLL", 4)]
        public void GetColumnIdFromPattern_GivenPattern_ShouldReturnRowId(string pattern, int expected)
        {
            Assert.That(_day5.GetColumnIdFromPattern(pattern), Is.EqualTo(expected));
        }

        [Test]
        public void GetPart1Answer_GivenSourceData_ReturnsHighestSeatId()
        {
            _adventResourcesMock.Setup(r => r.GetDay5Resources())
                .Returns(_patternsTest);

            Assert.That(_day5.GetPart1Answer(), Is.EqualTo(820));
        }

        [Test]
        public void GetPart2Answer_GivenSourceData_ReturnsMissingId()
        {
            _adventResourcesMock.Setup(r => r.GetDay5Resources())
                .Returns(_consecutivePatterns);

            Assert.That(_day5.GetPart2Answer(), Is.EqualTo(258));
        }

        private static string[] _patternsTest =
        {
            "FBFBBFFRLR",
            "BFFFBBFRRR",
            "FFFBBBFRRR",
            "BBFFBBFRLL"
        };

        private static string[] _consecutivePatterns = {
            "FBFFFFFLLL",
            "FBFFFFFLLR",
            "FBFFFFFLRR",
            "FBFFFFFRLL"
        };
    }
}
