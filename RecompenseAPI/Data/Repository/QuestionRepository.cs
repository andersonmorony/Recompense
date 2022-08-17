using Microsoft.EntityFrameworkCore;
using RecompenseAPI.Data.Db;
using RecompenseAPI.Data.IRepository;
using RecompenseAPI.Models;

namespace RecompenseAPI.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DbContextApp _dbContext;

        public QuestionRepository(DbContextApp dbContext)
        {
            _dbContext = dbContext;
        }

        public Question Add(CreateQuestion question)
        {
            var newQuestion = new Question
            {
                Title = question.Title,
                Description = question.Description,
                isActive = question.isActive,
                Order = question.Order,
                ChallengeId = question.ChallengeId,
            };
            _dbContext.Questions.Add(newQuestion);
            _dbContext.SaveChanges();
            return newQuestion;
        }

        public ICollection<Question> GetAll()
        {
            return _dbContext.Questions.Include(r => r.Responses).ToList();
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.Include(r => r.Responses).FirstOrDefault(x => x.Id == id);
        }
    }
}
