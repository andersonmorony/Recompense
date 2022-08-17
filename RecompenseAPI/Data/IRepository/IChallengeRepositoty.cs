using RecompenseAPI.Models;

namespace RecompenseAPI.Data.IRepository
{
    public interface IChallengeRepositoty
    {
        Challenge Add(CreateChallenge challenge);
        ICollection<Challenge> GetAll();
        Challenge GetById(int id);
    }
}
