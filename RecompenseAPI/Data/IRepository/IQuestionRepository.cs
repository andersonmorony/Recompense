using RecompenseAPI.Models;

namespace RecompenseAPI.Data.IRepository
{
    public interface IQuestionRepository
    {
        Question Add(CreateQuestion question);
        ICollection<Question> GetAll();
        Question GetById(int id);
    }
}
