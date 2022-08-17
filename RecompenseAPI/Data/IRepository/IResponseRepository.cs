using RecompenseAPI.Models;

namespace RecompenseAPI.Data.IRepository
{
    public interface IResponseRepository
    {
        Response Get(int id);
        ICollection<Response> GetAll();
        Response Add(Response response);
    }
}
