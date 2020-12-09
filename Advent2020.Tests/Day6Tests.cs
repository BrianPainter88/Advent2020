using System;
using System.Collections.Generic;
using System.Text;
using Advent2020.Business.Days;
using Advent2020.Business.Interfaces;
using Moq;
using NUnit.Framework;

namespace Advent2020.Tests
{
    public class Day6Tests
    {
        private Mock<IResources> _adventResourcesMock;
        private Day6 _day6;

        [SetUp]
        public void Setup()
        {
            _adventResourcesMock = new Mock<IResources>();
            _day6 = new Day6(_adventResourcesMock.Object);
        }

        [Test]
        public void GetGroupings_GivenData_SplitsIntoGroups()
        {
            _adventResourcesMock.Setup(a => a.GetDay6Resources())
                .Returns(_exampleData);

            var results = _day6.GetGroupings();

            Assert.That(results, Is.EquivalentTo(_exampleGroupings));
        }

        [Test]
        public void GetPart1Answer_GivenExampleData_ShouldBe11()
        {
            _adventResourcesMock.Setup(a => a.GetDay6Resources())
                .Returns(_exampleData);

            Assert.That(_day6.GetPart1Answer(), Is.EqualTo(11));
        }

        [Test]
        public void GetPart2Answer_GivenExampleData_ShouldBe6()
        {
            _adventResourcesMock.Setup(a => a.GetDay6Resources())
                .Returns(_exampleData);

            Assert.That(_day6.GetPart2Answer(), Is.EqualTo(6));
        }

        private static string[] _exampleData =
        {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b"
        };

        private static IEnumerable<(int GroupMembers, string[] Answers)> _exampleGroupings = new (int GroupMembers, string[] Answers)[]
        {
            (1, new [] {"a", "b", "c"}),
            (3, new [] {"a", "b", "c"}),
            (2, new [] {"a", "b", "a", "c"}),
            (4, new [] {"a", "a", "a", "a"}),
            (1, new [] {"b"})
        };
    }
}
