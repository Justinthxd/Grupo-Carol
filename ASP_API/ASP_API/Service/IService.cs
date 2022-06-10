using ASP_API.Models;

namespace ASP_API.Service
{
    public interface IService
    {
        Task<List<State>> List();
        Task<State> Get(string cod);
    }
}
