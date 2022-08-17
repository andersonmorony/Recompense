using Microsoft.EntityFrameworkCore;
using RecompenseAPI.Data;
using RecompenseAPI.Data.Db;
using RecompenseAPI.Data.Repository;
using RecompenseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecompenseTest
{
    public class QuestionTest
    {
        [Test]
        public void ShouldAddNewQuestion()
        {
            // Assert
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldAddNewQuestion)).Options;
            var dbContext = new DbContextApp(options);
            var _questionRepository = new QuestionRepository(dbContext);
            var challenge = new Challenge { Id = 1 , Description = "any_title", isActive = true, Title = "any_title" };
            var question = new CreateQuestion { Title = "any_title", Description = "any_description", isActive = true, Order = 1 };

            // Act
            var result = _questionRepository.Add(question);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldReturnAllQuestions()
        {
            // Assert
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldReturnAllQuestions)).Options;
            var dbContext = new DbContextApp(options);
            var _questionRepository = new QuestionRepository(dbContext);
            var challenge = new Challenge { Id = 1, Description = "any_title", isActive = true, Title = "any_title" };
            var question = new CreateQuestion { Title = "any_title", Description = "any_description", isActive = true, Order = 1 };

            // Act
            _questionRepository.Add(question);
            var result = _questionRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldReturnById()
        {
            // Assert
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldReturnById)).Options;
            var dbContext = new DbContextApp(options);
            var _questionRepository = new QuestionRepository(dbContext);
            var challenge = new Challenge { Id = 1, Description = "any_title", isActive = true, Title = "any_title" };
            var question = new CreateQuestion { Title = "any_title", Description = "any_description", isActive = true, Order = 1};

            // Act
            var response = _questionRepository.Add(question);
            var result = _questionRepository.GetById(response.Id);

            // Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void ShouldReturnNullWithInvalidId()
        {
            // Assert
            var options = new DbContextOptionsBuilder<DbContextApp>().UseInMemoryDatabase(nameof(ShouldReturnNullWithInvalidId)).Options;
            var dbContext = new DbContextApp(options);
            var _questionRepository = new QuestionRepository(dbContext);
            var invalidId = -1;
            // Act
            var result = _questionRepository.GetById(invalidId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
