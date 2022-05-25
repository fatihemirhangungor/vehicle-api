using CarProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public interface IVehicleRepository<T>
        where T : class
    {
        Task<T> GetByColor(string color);
        Task Delete(int id);

        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Create(T vehicle);
        Task Update(T vehicle);
        Task SetHeadLights(int id);
    }
}
