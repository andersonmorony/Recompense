using RecompenseAPI.Data.Db;
using RecompenseAPI.Data.IRepository;
using System.Linq;

namespace RecompenseAPI.Data.Repository
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly DbContextApp _dbContext;

        public ResponseRepository(DbContextApp dbContext)
        {
            _dbContext = dbContext;
        }

        public Response Add(Response response)
        {
            _dbContext.Add(response);
            _dbContext.SaveChanges();
            return response;
        }

        public Response Get(int id)
        {
            var result = _dbContext.Responses.FirstOrDefault(resp => resp.Id == id);
            return result;
        }

        public ICollection<Response> GetAll()
        {
            var result = _dbContext.Responses.ToList();
            return result;
        }
    }
}
