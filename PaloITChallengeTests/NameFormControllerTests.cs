using Moq;
using NUnit.Framework;
using PaloITChallenge.Controllers;
using PaloITChallenge.Data;
using PaloITChallenge.Model;
using PaloITChallenge.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaloITChallengeTests
{
    [TestFixture]
    class NameFormControllerTests
    {
        private Mock<IFullNameRepository> _fullNameRepository;

        [SetUp]
        public void SetUp() {
            _fullNameRepository = new Mock<IFullNameRepository>();

        }

        [Test]
        public void PostTests_InputNewName_ReturnValueWithoutError()
        {
            FullName fullName = new FullName
            {
                FirstName = "Ann",
                LastName = "Other",
                SumOfAsciiValue = 831,
                NumOfConsecutive0s = 2
            };
            _fullNameRepository.Setup(r => r.GetExistingRecordsByName(It.IsAny<string>(), It.IsAny<string>())).Returns((FullName)null);
            _fullNameRepository.Setup(r => r.InsertNewFullNameAsync(It.IsAny<FullName>())).Returns((string)null);
            NameFormController controller = new NameFormController(_fullNameRepository.Object);

            var result = controller.Post(fullName);

            Assert.That(result.NumOfConsecutive0s, Is.EqualTo("2"));
            Assert.That(result.ErrorMesg, Is.EqualTo(null));
        }

        [Test]
        public void PostTests_InputNewName_ReturnValueWithError()
        {
            FullName fullName = new FullName
            {
                FirstName = "Ann",
                LastName = "Other",
                SumOfAsciiValue = 831,
                NumOfConsecutive0s = 2
            };
            _fullNameRepository.Setup(r => r.GetExistingRecordsByName(It.IsAny<string>(), It.IsAny<string>())).Returns((FullName)null);
            _fullNameRepository.Setup(r => r.InsertNewFullNameAsync(It.IsAny<FullName>())).Returns("error");
            NameFormController controller = new NameFormController(_fullNameRepository.Object);

            var result = controller.Post(fullName);

            Assert.That(result.NumOfConsecutive0s, Is.EqualTo("2"));
            Assert.That(result.ErrorMesg, Is.EqualTo("error"));
        }

        [Test]
        public void PostTests_InputExistedName_ReturnValue()
        {
            FullName fullName = new FullName
            {
                FirstName = "Ann",
                LastName = "Other",
                SumOfAsciiValue = 831,
                NumOfConsecutive0s = 2
            };
            _fullNameRepository.Setup(r => r.GetExistingRecordsByName(It.IsAny<string>(), It.IsAny<string>())).Returns(fullName);
            NameFormController controller = new NameFormController(_fullNameRepository.Object);

            var result = controller.Post(fullName);

            Assert.That(result.NumOfConsecutive0s, Is.EqualTo("2"));
            Assert.That(result.ErrorMesg, Is.EqualTo(null));
        }
    }
}
