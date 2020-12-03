using System.Collections.Generic;
using System.IO;
using Advent2020.Business.Days;
using Advent2020.Business.Interfaces;
using Advent2020.Business.Models;
using Moq;
using NUnit.Framework;

namespace Advent2020.Tests
{
    public class Day2Tests
    {
        private Mock<IResources> _adventResourcesMock;
        private Day2 _day2;

        [SetUp]
        public void Setup()
        {
            _adventResourcesMock = new Mock<IResources>();
            _day2 = new Day2(_adventResourcesMock.Object);
        }

        [TestCase("1-3 a: abcde", 1, 3, "a", "abcde")]
        [TestCase("1-3 b: cdefg", 1, 3, "b", "cdefg")]
        [TestCase("2-9 c: ccccccccc", 2, 9, "c", "ccccccccc")]
        public void ParseInput_ShouldSplitStringParts(string parsableString, int expectedFirstPosition, int expectedSecondPosition, string expectedLetter, string expectedString)
        {
            var result = _day2.Parse(parsableString);

            Assert.That(result, Has.Property("FirstPosition").EqualTo(expectedFirstPosition));
            Assert.That(result, Has.Property("SecondPosition").EqualTo(expectedSecondPosition));
            Assert.That(result, Has.Property("StringToSearchFor").EqualTo(expectedLetter));
            Assert.That(result, Has.Property("StringToBeSearched").EqualTo(expectedString));
        }

        [TestCase("1-3 a: abc-de", 1, 3, "a", "abcde")]
        [TestCase("1-3 b: cdefg 1234", 1, 3, "b", "cdefg")]
        [TestCase("2-9c: ccccccccc", 2, 9, "c", "ccccccccc")]
        public void ParseInput_WithInvalidFormat_ShouldThrowException(string parsableString, int expectedMin, int expectedMax, string expectedLetter, string expectedString)
        {
            Assert.Throws<InvalidDataException>(() => _day2.Parse(parsableString));
        }

        [TestCaseSource(nameof(ValidPasswordParts))]
        public void IsPasswordValid_WithValidData_ValidationPasses(PasswordParts passwordParts)
        {
            Assert.True(_day2.IsPasswordValid(passwordParts));
        }

        [TestCaseSource(nameof(InvalidPasswordParts))]
        public void IsPasswordValid_WithInvalidData_ValidationFails(PasswordParts passwordParts)
        {
            Assert.False(_day2.IsPasswordValid(passwordParts));
        }

        [Test]
        public void GetAnswer_Given5PasswordsWith3Valid_Returns3()
        {
            _adventResourcesMock
                .Setup(a => a.GetDay2Resources())
                .Returns(Get3ValidAnd2InvalidTestPasswords());

            Assert.That(_day2.GetAnswer(), Is.EqualTo(3));
        }

        private IEnumerable<string> Get3ValidAnd2InvalidTestPasswords()
        {
            return new[]
            {
                "1-3 a: abgda", // valid
                "1-3 a: bbabb", // valid
                "2-4 a: aebetcddeeaa", // invalid
                "2-4 a: baaaaab", // invalid
                "5-10 a: abactdaeaafga" // valid
            };
        }

        private static IEnumerable<PasswordParts> ValidPasswordParts()
        {
            return new[]
            {
                new PasswordParts {FirstPosition = 1, SecondPosition = 3, StringToSearchFor = "a", StringToBeSearched = "abfda"},
                new PasswordParts {FirstPosition = 2, SecondPosition = 4, StringToSearchFor = "a", StringToBeSearched = "a4baccddeeaa"},
                new PasswordParts {FirstPosition = 5, SecondPosition = 10, StringToSearchFor = "a", StringToBeSearched = "abacadaeaofga"}
            };
        }

        private static IEnumerable<PasswordParts> InvalidPasswordParts()
        {
            return new[]
            {
                new PasswordParts {FirstPosition = 1, SecondPosition = 3, StringToSearchFor = "a", StringToBeSearched = "ababb"},
                new PasswordParts {FirstPosition = 2, SecondPosition = 4, StringToSearchFor = "b", StringToBeSearched = "aaa"},
                new PasswordParts {FirstPosition = 3, SecondPosition = 5, StringToSearchFor = "c", StringToBeSearched = "ggggggggg"}
            };
        }
    }
}
