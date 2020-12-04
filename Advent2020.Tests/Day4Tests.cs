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
    public class Day4Tests
    {
        private Mock<IResources> _adventResourcesMock;
        private Day4 _day4;

        [SetUp]
        public void Setup()
        {
            _adventResourcesMock = new Mock<IResources>();
            _day4 = new Day4(_adventResourcesMock.Object);
        }

        [TestCaseSource(nameof(ValidFieldSet))]
        public void HasAllRequiredFields_WithValidFields_ReturnsTrue(string[] fieldsToTest)
        {
            Assert.True(_day4.HasAllRequiredFields(fieldsToTest));
        }

        [TestCaseSource(nameof(InvalidFieldSet))]
        public void HasAllRequiredFields_WithInvalidFields_ReturnsFalse(string[] fieldsToTest)
        {
            Assert.False(_day4.HasAllRequiredFields(fieldsToTest));
        }

        [Test]
        public void GetPart1Answer_GivenTestData_ShouldReturn2Valid()
        {
            _adventResourcesMock
                .Setup(a => a.GetDay4Resources())
                .Returns(TestData);

            Assert.That(_day4.GetPart1Answer(), Is.EqualTo(2));
        }

        [Test]
        public void GetPart1Answer_GivenTestDataFromExample_ShouldReturn2Valid()
        {
            _adventResourcesMock
                .Setup(a => a.GetDay4Resources())
                .Returns(TestDataFromExample);

            Assert.That(_day4.GetPart1Answer(), Is.EqualTo(2));
        }

        private static IEnumerable<string[]> ValidFieldSet()
        {
            return new[]
            {
                new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"},
                new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"},
                new[] {"hgt", "hcl", "cid", "ecl", "byr", "iyr", "eyr", "pid"},
            };
        }

        private static IEnumerable<string[]> InvalidFieldSet()
        {
            return new[]
            {
                new[] {"byr", "eyr", "hgt", "hcl", "ecl", "pid"},
                new[] {"byr", "pid", "cid"},
                new[] {"hgt", "hcl", "cid", "ecl", "byr", "iyr", "pid"},
            };
        }

        private static IEnumerable<IDictionary<string, string>> TestData()
        {
            return
                new List<IDictionary<string, string>>()
                {
                    // valid
                    new Dictionary<string, string>()
                    {
                        {"byr", ""},
                        {"iyr", ""},
                        {"eyr", ""},
                        {"hgt", ""},
                        {"hcl", ""},
                        {"ecl", ""},
                        {"pid", ""}
                    },
                    // invalid
                    new Dictionary<string, string>()
                    {
                        {"byr", ""},
                        {"iyr", ""},
                        {"eyr", ""},
                        {"hgt", ""},
                        {"hcl", ""},
                        {"ecl", ""},
                        {"cid", ""}
                    },
                    // invalid
                    new Dictionary<string, string>()
                    {
                        {"byr", ""},
                        {"iyr", ""},
                        {"ecl", ""},
                        {"pid", ""}
                    },
                    // valid
                    new Dictionary<string, string>()
                    {
                        {"byr", ""},
                        {"iyr", ""},
                        {"eyr", ""},
                        {"hgt", ""},
                        {"hcl", ""},
                        {"ecl", ""},
                        {"pid", ""},
                        {"cid", ""}
                    },
                };
        }

        private static IEnumerable<IDictionary<string, string>> TestDataFromExample()
        {
            return
                new List<IDictionary<string, string>>()
                {
                    // valid
                    new Dictionary<string, string>()
                    {
                        {"ecl", ""},
                        {"pid", ""},
                        {"eyr", ""},
                        {"hcl", ""},
                        {"byr", ""},
                        {"iyr", ""},
                        {"cid", ""},
                        {"hgt", ""}
                    },
                    // invalid
                    new Dictionary<string, string>()
                    {
                        {"iyr", ""},
                        {"ecl", ""},
                        {"cid", ""},
                        {"eyr", ""},
                        {"pid", ""},
                        {"hcl", ""},
                        {"byr", ""}
                    },
                    // invalid
                    new Dictionary<string, string>()
                    {
                        {"hcl", ""},
                        {"eyr", ""},
                        {"pid", ""},
                        {"iyr", ""},
                        {"ecl", ""},
                        {"hgt", ""}
                    },
                    // valid
                    new Dictionary<string, string>()
                    {
                        {"hcl", ""},
                        {"iyr", ""},
                        {"eyr", ""},
                        {"ecl", ""},
                        {"pid", ""},
                        {"byr", ""},
                        {"hgt", ""}
                    },
                };
        }
    }
}
