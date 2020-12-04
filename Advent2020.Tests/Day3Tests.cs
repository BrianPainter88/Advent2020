using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2020.Business.Days;
using Advent2020.Business.Interfaces;
using Moq;
using NUnit.Framework;

namespace Advent2020.Tests
{
    public class Day3Tests
    {
        private Mock<IResources> _adventResourcesMock;
        private Day3 _day3;

        [SetUp]
        public void Setup()
        {
            _adventResourcesMock = new Mock<IResources>();
            _day3 = new Day3(_adventResourcesMock.Object);
        }

        [Test]
        public void Parse_WhenGivenData_ReturnsMultiArray()
        {
            var result = _day3.Parse(SampleData());

            Assert.That(result, Has.Length.EqualTo(5));
            Assert.That(result[0], Has.Length.EqualTo(18));
        }

        [Test]
        public void TraverseThroughArray_WhenTraversingAtOver3AndDown1_GivesCorrectCharacters()
        {
            var data = _day3.Parse(SampleData());

            var results = _day3.TraverseThroughArray(data, 3, 1);

            CollectionAssert.AreEqual(new[] {"#", ".", "#", "#"}, results);
        }

        [Test]
        public void TraverseThroughArray_WhenTraversingAtOver3AndDown1_GivesCorrectCharactersAgain()
        {
            var data = _day3.Parse(SampleWithShowing3To1Ratio());

            var results = _day3.TraverseThroughArray(data, 3, 1);

            CollectionAssert.AreEqual(Enumerable.Repeat("X", 8), results);
        }

        [Test]
        public void GetPart1Answer_WhenGivenData_GivesCorrectTreeCount()
        {
            _adventResourcesMock
                .Setup(a => a.GetDay3Resources())
                .Returns(SampleData);

            var results = _day3.GetPart1Answer();

            Assert.That(results, Is.EqualTo(3));
        }

        [Test]
        public void GetPart2Answer_WhenGivenData_GivesCorrectTreeCount()
        {
            _adventResourcesMock
                .Setup(a => a.GetDay3Resources())
                .Returns(SampleData);

            var results = _day3.GetPart2Answer();

            Assert.That(results, Is.EqualTo(12));
        }

        private static string[] SampleData()
        {
            return new[]
            {
                "#..#.....#.#.....#",
                "##.#....##....##.#",
                "...#...#.#.......#",
                "...#.....#...###.#",
                "####...#.#..#....#",
            };
        }

        private static string[] SampleWithShowing3To1Ratio()
        {
            return new[]
            {
                "X____________________",
                "___X_________________",
                "______X______________",
                "_________X___________",
                "____________X________",
                "_______________X_____",
                "__________________X__",
                "X____________________",
                "___X_________________",
            };
        }
    }
}
