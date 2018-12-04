using NUnit.Framework;
using PaloITChallenge.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaloITChallengeTests
{
    [TestFixture]
    class NameConvertServiceTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("", null)]
        [TestCase(null, "")]
        public void GetSumOfAsciiValuesOfName_InputEmpty_ReturnsZero(string a, string b)
        {
            var nameConvertService = new NameConvertService();
            var result = nameConvertService.GetSumOfAsciiValuesOfName(a, b);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetSumOfAsciiValuesOfName_InputNotEmpty_ReturnsBiggerThanZero()
        {
            var nameConvertService = new NameConvertService();
            var result = nameConvertService.GetSumOfAsciiValuesOfName("Ann","Other");

            Assert.That(result, Is.EqualTo(831));
        }

    }
}
