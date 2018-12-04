using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PaloITChallenge.Data;
using PaloITChallenge.Model;
using PaloITChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaloITChallengeTests
{
    [TestFixture]
    class FullNameRepositoryTests
    {
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;
        private ApplicationDBContext _context;
        [SetUp]
        public void SetUp()
        {
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PaloITChallenge;Trusted_Connection=True;MultipleActiveResultSets=true");
            _context = new ApplicationDBContext(_optionsBuilder.Options);
        }

        [Test]
        public void GetExistingRecordsByName_InputExistName_ReturnNotNull()
        {

            var mockNameConvertService = new Mock<INameConvertService>();
            mockNameConvertService.Setup(n => n.GetSumOfAsciiValuesOfName(It.IsAny<string>(), It.IsAny<string>())).Returns(831);

            var repository = new FullNameRepository(_context, mockNameConvertService.Object);

            var result = repository.GetExistingRecordsByName("Ann", "Other");

            Assert.That(result, Is.TypeOf<FullName>());

        }

        [Test]
        public void GetExistingRecordsByName_InputNewName_ReturnNull()
        {

            var mockNameConvertService = new Mock<INameConvertService>();
            mockNameConvertService.Setup(n => n.GetSumOfAsciiValuesOfName(It.IsAny<string>(), It.IsAny<string>())).Returns(831);

            var repository = new FullNameRepository(_context, mockNameConvertService.Object);

            var result = repository.GetExistingRecordsByName("Annabell", "Other");

            Assert.That(result, Is.EqualTo(null));

        }


        [Test]
        public void InsertNewFullNameTests_InsertNewNameSuccess_ReturnNull()
        {

            var mockNameConvertService = new Mock<INameConvertService>();
            mockNameConvertService.Setup(n => n.GetSumOfAsciiValuesOfName(It.IsAny<string>(), It.IsAny<string>())).Returns(831);
            var repository = new FullNameRepository(_context, mockNameConvertService.Object);
            var fullName = new FullName
            {
                FirstName = "Annabell",
                LastName = "Other",
            };

            var result = repository.InsertNewFullNameAsync(fullName);

            Assert.That(result, Is.EqualTo(null));

        }
    }


}
