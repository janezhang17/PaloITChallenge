
using NUnit.Framework;
using PaloITChallenge.Services;

namespace PaloITChallengeTests
{
    [TestFixture]
    public class BinaryArrayServiceTests
    {
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void GetLargestNumOfConsecutive0s_InputIsEmpty_ReturnsZero(string input)
        {
            var result = BinaryArrayService.GetLargestNumOfConsecutive0s(input);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetLargestNumOfConsecutive0s_InputLessThan1_ReturnsZero()
        {
            var result = BinaryArrayService.GetLargestNumOfConsecutive0s(-1);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void GetLargestNumOfConsecutive0s_InputBiggerThan1_ReturnsBiggerThanZero()
        {
            var result = BinaryArrayService.GetLargestNumOfConsecutive0s(831);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
