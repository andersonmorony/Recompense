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
    internal class Challengetest
    {
        [Test]
        public void shouldCreateANewItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(nameof(shouldCreateANewItem)).Options;
            var dbContextApp = new DbContextApp(options);
            var challengeRepository = new ChallengeRepositoty(dbContextApp);

            var challenge = new CreateChallenge { Description = "any_description", isActive = false, Title = "any_title" };

            // Act
            var result = challengeRepository.Add(challenge);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
        [Test]
        public void shouldGetAllItems()
        {
            // Arrange
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(nameof(shouldGetAllItems)).Options;
            var dbContextApp = new DbContextApp(options);
            var challengeRepository = new ChallengeRepositoty(dbContextApp);

            // Act
            var result = challengeRepository.GetAll();

            // Assert
            Assert.IsEmpty(result);
        }
        [Test]
        public void shouldGetbyId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(nameof(shouldGetAllItems)).Options;
            var dbContextApp = new DbContextApp(options);
            var challengeRepository = new ChallengeRepositoty(dbContextApp);
            var challenge = new CreateChallenge { Description = "any_description", isActive = false, Title = "any_title" };

            // Act
            var challengeAdded = challengeRepository.Add(challenge);
            var result = challengeRepository.GetById(challengeAdded.Id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(challengeAdded.Id));
            Assert.That(result.Description, Is.EqualTo(challengeAdded.Description));
        }
    }
}
