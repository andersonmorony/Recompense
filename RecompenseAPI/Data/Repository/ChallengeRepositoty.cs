using Microsoft.EntityFrameworkCore;
using RecompenseAPI.Data.Db;
using RecompenseAPI.Data.IRepository;
using RecompenseAPI.Models;

namespace RecompenseAPI.Data.Repository
{
    public class ChallengeRepositoty : IChallengeRepositoty
    {
        private readonly DbContextApp _dbContext;
        public ChallengeRepositoty(DbContextApp dbContext)
        {
            _dbContext = dbContext;
        }
        public Challenge Add(CreateChallenge challenge)
        {
            var newChallenge = new Challenge
            {
                Description = challenge.Description,
                Title = challenge.Title,
                isActive = challenge.isActive
            };

            _dbContext.Add(newChallenge);
            _dbContext.SaveChanges();
            return newChallenge;
        }

        public Challenge GetById(int id)
        {
            return _dbContext.Challenges.Include(q => q.Questions).FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Challenge> GetAll()
        {
            return _dbContext.Challenges.Include(q => q.Questions).ToList();
        }

    }
}
