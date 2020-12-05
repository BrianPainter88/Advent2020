using System.Collections.Generic;
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

        [TestCase("2002", 4, 2000, 2005)]
        [TestCase("2003", 4, 1900, 3000)]
        public void ValidateYear_WithValidData_ShouldReturnTrue(string year, int digits, int minYear, int maxYear)
        {
            Assert.True(_day4.ValidateYear(year, digits, minYear, maxYear));
        }

        [TestCase("1999", 4, 2000, 2005)]
        [TestCase("20", 4, 10, 30)]
        [TestCase("3001", 4, 1900, 3000)]
        public void ValidateYear_WithInvalidData_ShouldReturnFalse(string year, int digits, int minYear, int maxYear)
        {
            Assert.False(_day4.ValidateYear(year, digits, minYear, maxYear));
        }

        [TestCase(" 166cm ")]
        [TestCase("60in")]
        [TestCase("166cm")]
        [TestCase(" 65in ")]
        public void ValidateHeight_WithValidData_ShouldReturnTrue(string height)
        {
            Assert.True(_day4.ValidateHeight(height));
        }

        [TestCase("1ft")]
        [TestCase("100 cm")]
        [TestCase("100cm")]
        [TestCase("abcin")]
        [TestCase(" abc in ")]
        [TestCase(" 123i n")]
        [TestCase(" 123in")]
        [TestCase("190")]
        [TestCase("190in")]
        [TestCase("145cm")]
        [TestCase("195cm")]
        [TestCase("55in")]
        [TestCase("80in")]
        [TestCase("11122233in ")]
        public void ValidateHeight_WithInvalidData_ShouldReturnFalse(string height)
        {
            Assert.False(_day4.ValidateHeight(height));
        }

        [TestCase("#DFFF00")]
        [TestCase("#ffff00")]
        [TestCase("#FFBF00")]
        [TestCase("#FF7F50")]
        [TestCase(" #DE3163")]
        [TestCase("#9FE2BF ")]
        [TestCase(" #40E0D0 ")]
        [TestCase("#123abc")]
        public void ValidateHairColor_WithValidData_ShouldReturnTrue(string hairColor)
        {
            Assert.True(_day4.ValidateHairColor(hairColor));
        }

        [TestCase("DFFF00")]
        [TestCase("#DFFG00")]
        [TestCase("#FFBF0")]
        [TestCase("#FF7 F50")]
        [TestCase("blue")]
        [TestCase("##40E0D0")]
        [TestCase("123abc")]
        [TestCase("#123abz")]
        public void ValidateHairColor_WithInvalidData_ShouldReturnFalse(string hairColor)
        {
            Assert.False(_day4.ValidateHairColor(hairColor));
        }

        [TestCase("amb")]
        [TestCase("blu")]
        [TestCase("brn")]
        [TestCase("gry")]
        [TestCase("grn")]
        [TestCase("hzl")]
        [TestCase("oth")]
        [TestCase(" grn")]
        [TestCase("hzl ")]
        [TestCase(" oth ")]
        public void ValidateEyeColor_WithValidData_ShouldReturnTrue(string eyeColor)
        {
            Assert.True(_day4.ValidateEyeColor(eyeColor));
        }

        [TestCase("blue")]
        [TestCase("brown")]
        [TestCase("a m b")]
        [TestCase("123")]
        [TestCase("")]
        [TestCase("test")]
        [TestCase("wat")]
        public void ValidateEyeColor_WithInvalidData_ShouldReturnFalse(string eyeColor)
        {
            Assert.False(_day4.ValidateEyeColor(eyeColor));
        }

        [TestCase("123456789")]
        [TestCase("122256789")]
        [TestCase(" 123456789")]
        [TestCase("123456789 ")]
        [TestCase(" 123456789 ")]
        [TestCase("000000001")]
        public void ValidatePassportId_WithValidData_ShouldReturnTrue(string passportId)
        {
            Assert.True(_day4.ValidatePassportId(passportId));
        }

        [TestCase("123a56789")]
        [TestCase("12225678")]
        [TestCase("aaaaaaaaa")]
        [TestCase("0123456789")]
        public void ValidatePassportId_WithInvalidData_ShouldReturnFalse(string passportId)
        {
            Assert.False(_day4.ValidatePassportId(passportId));
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
