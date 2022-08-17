using Microsoft.EntityFrameworkCore;
using RecompenseAPI.Data;
using RecompenseAPI.Data.Db;
using RecompenseAPI.Data.Repository;
using System.Web.Mvc;

namespace RecompenseTest
{
    public class ResponseTest
    {
        [Test]
        public void ShouldCreateANewResponse()
        {
            // Arrange
            var response = new Response { Id = 1, Title = "any_title", Description = "any_description", isCorrect = true, Order = 1 };

            Assert.That(1, Is.EqualTo(response.Id));
            Assert.That("any_title", Is.EqualTo(response.Title));
            Assert.That("any_description", Is.EqualTo(response.Description));
            Assert.That(1, Is.EqualTo(response.Order));
            Assert.IsTrue(response.isCorrect);

        }

        [Test]
        public void ShouldGetAllResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldGetAllResponse)).Options;
            var _dbcontext = new DbContextApp(options);
            var _responseRepository = new ResponseRepository(_dbcontext);

            //Act
            var responses = _responseRepository.GetAll();

            // Assert
            Assert.IsEmpty(responses);
        }

        [Test]
        public void ShouldCreateAResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldCreateAResponse)).Options;
            var _dbcontext = new DbContextApp(options);
            var _responseRepository = new ResponseRepository(_dbcontext);
            var validResponse = new Response { Title = "any_title", Description = "any_description", isCorrect = false, Order = 1 };

            //Act
            var result = _responseRepository.Add(validResponse);

            // Assert
            Assert.NotNull(result.Id);
            Assert.That("any_title", Is.EqualTo(result.Title));
            Assert.That("any_description", Is.EqualTo(result.Description));
            Assert.That(false, Is.EqualTo(result.isCorrect));
            Assert.That(1, Is.EqualTo(result.Order));
        }

        [Test]
        public void ShouldNotCreateAResponseWithoutTitle()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldCreateAResponse)).Options;
            var _dbcontext = new DbContextApp(options);
            var _responseRepository = new ResponseRepository(_dbcontext);
            var invalidResponse = new Response { Description = "any_description", isCorrect = false, Order = 1 };
            var exMessage = "Required properties '{'Title'}' are missing for the instance of entity type 'Response'. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the entity key value.";
            
            //Act
            var result = Assert.Throws<DbUpdateException>(() => _responseRepository.Add(invalidResponse));


            // Assert
            Assert.That(result.Message, Is.EqualTo(exMessage));
        }

        [Test]
        public void ShouldReturnOneResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldReturnOneResponse)).Options;
            var _dbcontext = new DbContextApp(options);
            var _responseRepository = new ResponseRepository(_dbcontext);
            var validResponse = new Response { Title= "any_title", Description = "any_description", isCorrect = false, Order = 1 };

            //Act
            var newResponse = _responseRepository.Add(validResponse);
            var result = _responseRepository.Get(newResponse.Id);


            // Assert
            Assert.That(1, Is.EqualTo(result.Id));
            Assert.That("any_title", Is.EqualTo(result.Title));
        }
    }
}